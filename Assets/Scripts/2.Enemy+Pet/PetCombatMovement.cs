
using System.Collections.Generic;
using UnityEngine;

public class PetCombatMovement : MovementToTarget
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float minDistance = 0.5f;
    [SerializeField] protected float currentDistance;
    public float CurrentDistance => currentDistance;
    protected Vector2 direction;
    public Vector2 Direction => direction;
    [SerializeField] protected PetCtrl petCtrl;
    [SerializeField] protected List<Transform> listPoints;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeToNextPoint = 5f;
    [SerializeField] protected float walkSpeed = 0.5f;
    [SerializeField] protected float runSpeed = 1.5f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadRigidbody2D();
        LoadPetCtrl();
        LoadPetData();
    }
    protected virtual void LoadPetData()
    {
        walkSpeed = petCtrl.PetDataSO.walkSpeed;
        runSpeed = petCtrl.PetDataSO.runSpeed;
        minDistance = petCtrl.PetDataSO.minDistance;
    }

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(LoadListPoints), 1f);
    }
    private void LoadListPoints()
    {
        this.listPoints = PointsPetForMove.Instance.ListPoints;
    }
    private void LoadPetCtrl()
    {
        if (petCtrl != null) return;
        petCtrl = transform.parent.GetComponent<PetCtrl>();
        Debug.LogWarning(transform.name + ": LoadPetCtrl()", gameObject);
    }
    private void LoadRigidbody2D()
    {
        if (rb != null) return;
        rb = transform.parent.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        Debug.LogWarning(transform.name + ": LoadRigidbody2D()", gameObject);
    }
    protected override void FixedUpdate()
    {
        GetTargetPoints();
        UpdateMoveSpeed();
        TransmitTargetToRotate();
        base.FixedUpdate();
    }
    protected virtual void UpdateMoveSpeed()
    {
        if (target == null)
        {
            moveSpeed = walkSpeed;
            return;
        }
        if (TargetIsEnemy(target))
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
    }
    protected virtual bool TargetIsEnemy(Transform target)
    {
        if (target == null) return false;
        if (target.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            return true;
        }
        return false;
    }
    protected virtual void GetTargetPoints()
    {
        timer += Time.fixedDeltaTime;
        if (timer < timeToNextPoint) return;
        timer = 0f;
        if (target != null) return;
        target = GetPointsRandom();
    }

    protected virtual Transform GetPointsRandom()
    {
        int index = Random.Range(0, listPoints.Count);
        return listPoints[index];
    }

    protected override void Moving()
    {
        if (petCtrl.PetDamageReceiver.isDead) { rb.velocity = Vector2.zero; return; }
        if (!target) return;

        currentDistance = Vector3.Distance(transform.position, target.position);
        if (currentDistance <= minDistance)
        {
            rb.velocity = Vector2.zero;
            if (!TargetIsEnemy(target))
            {
                target = null;
            }
            return;
        }

        direction = target.position - transform.position;
        direction.Normalize();
        rb.velocity = direction * moveSpeed;
    }
    protected virtual void TransmitTargetToRotate()
    {
        if (target == null)
        {
            petCtrl.ObjectLookAtTarget.SetTarget(null);
            return;
        }

        petCtrl.ObjectLookAtTarget.SetTarget(target);
    }
}
