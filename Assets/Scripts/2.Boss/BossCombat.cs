

using System.Collections;
using UnityEngine;

public class BossCombat : DamageSender
{
    // [SerializeField] protected float range = 3f;
    [SerializeField] protected Transform currentTarget;
    [SerializeField] protected float DistanceForAttack = 10f;
    // [SerializeField] protected float SpeedAttack = 0.5f;
    private Transform Point;
    [SerializeField] private Transform pointAttack;
    [SerializeField] protected LayerMask ObjectLayers;
    // [SerializeField] protected EnemyCtrl enemyCtrl;
    protected float currentDistance;
    protected Vector2 direction;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float coolDown = 10f;
    protected bool isStopMove = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadLayerMask();
        LoadPoint();
        LoadBossCtrl();

    }
    protected override void ResetValue()
    {
        base.ResetValue();
        damage = 10f;
    }
    [SerializeField] protected BossCtrl bossCtrl;
    protected override void Start()
    {
        base.Start();
        currentTarget = bossCtrl.BossMovement.Target;
    }
    private void LoadBossCtrl()
    {
        if (bossCtrl != null) return;
        bossCtrl = transform.parent.GetComponent<BossCtrl>();
        Debug.LogWarning(transform.name + ": LoadBossCtrl()", gameObject);
    }
    private void LoadPoint()
    {
        pointAttack = transform.Find("PointAttack");
    }
    private void LoadLayerMask()
    {
        ObjectLayers = LayerMask.GetMask("Player", "MainHome");
    }
    protected virtual void Update()
    {
        GetDistance();
        GetPoint();
        isAttackPreparing();
    }

    private void isAttackPreparing()
    {
        if (!CanAttack()) return;
        int i = Random.Range(1, 4);
        // int i = 2;
        switch (i)
        {
            case 1:
                CallAnimationAttack();
                break;
            case 2:
                CallAnimationLaze();
                break;
            case 3:
                CallAnimationSummon();
                SummonEnemy();
                break;
        }
    }

    private void SummonEnemy()
    {
        bossCtrl.transform.Find("BossAbility").GetComponentInChildren<AbilitySummon>().SetActivated();
    }

    private void CallAnimationAttack()
    {
        bossCtrl.BossAnimation.PlayAttack();
    }
    private void CallAnimationSummon()
    {
        bossCtrl.BossAnimation.PlaySummon();
    }
    private void CallAnimationLaze()
    {
        bossCtrl.BossAnimation.PlayLaze();
        StartCoroutine(StopMovement());
    }
    private IEnumerator StopMovement()
    {
        float oldSpeed = bossCtrl.BossMovement.MoveSpeed;
        bossCtrl.BossMovement.SetSpeedMove(0f);
        // isStopMove = true;

        yield return new WaitForSeconds(6f);

        bossCtrl.BossMovement.SetSpeedMove(oldSpeed);
        // isStopMove = false;
    }
    private bool CanAttack()
    {
        timer += Time.deltaTime;
        if (timer < coolDown) return false;
        timer = 0f;

        if (currentDistance <= DistanceForAttack) return true;
        return false;
    }

    private void GetDistance()
    {
        this.currentDistance = bossCtrl.BossMovement.CurrentDistance;
    }

    private void GetPoint()
    {
        Point = pointAttack;
    }
    // private void Laze()
    // {
    //     Quaternion quaternion = Quaternion.Euler(0f, 0f, 0f);
    //     if (bossCtrl.BossMovement.Direction.x < 0)
    //     {
    //         quaternion = Quaternion.Euler(0f, 0f, 180f);
    //     }
    //     // BossSkillSpawner.Instance.SpawnOnCalled(pointLaze.position, "HandGolemLaze");
    // }
    public virtual void Attack()
    {
        DamageReceiver receiver = currentTarget.GetComponentInChildren<DamageReceiver>();
        BulletSpawner.Instance.SpawnBulletFollowTarget(pointAttack.position, receiver.transform, "HandGolemStone", damage);
    }
    public override void Send()
    {

    }
    //Call ở animation attack
    // public override void Send()
    // {
    //     Collider2D[] Targets = Physics2D.OverlapCircleAll(Point.position, attackRange, ObjectLayers);
    //     foreach (Collider2D target in Targets)
    //     {
    //         DamageReceiver receiver = target.GetComponent<DamageReceiver>();
    //         if (receiver == null) continue;
    //         receiver.Receiver(damage);
    //     }
    // }
    // private void OnDrawGizmosSelected()
    // {
    //     if (Point == null) return;
    //     Gizmos.DrawWireSphere(Point.position, attackRange);
    // }
}
