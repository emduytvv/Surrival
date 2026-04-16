
using System.Collections.Generic;
using UnityEngine;

public class PetBuffMovement : MovementToTarget
{
    [SerializeField] protected float minDistance = 0.5f;
    [SerializeField] protected float currentDistance;
    public float CurrentDistance => currentDistance;
    protected Vector2 direction;
    public Vector2 Direction => direction;
    [SerializeField] protected PetCtrl petCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPetCtrl();
        LoadPetData();
    }
    protected virtual void LoadPetData()
    {
        moveSpeed = petCtrl.PetDataSO.walkSpeed;
        minDistance = petCtrl.PetDataSO.minDistance;
    }
    private void LoadPetCtrl()
    {
        if (petCtrl != null) return;
        petCtrl = transform.parent.GetComponent<PetCtrl>();
        Debug.LogWarning(transform.name + ": LoadPetCtrl()", gameObject);
    }
    protected override void FixedUpdate()
    {
        TransmitTargetToRotate();
        base.FixedUpdate();
    }
    protected override void Moving()
    {
        if (!target) return;
        currentDistance = Vector3.Distance(transform.position, target.position);
        if (currentDistance <= minDistance) { return; }

        Vector3 desired = target.position;
        transform.parent.position = Vector3.Lerp(transform.position, desired, moveSpeed * Time.deltaTime);
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
