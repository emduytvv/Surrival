using System;
using UnityEngine;
using System.Collections;
public class PlayerMovement : Movement
{
    [SerializeField] private Rigidbody2D rb;
    protected Vector2 direction;
    public Vector2 Direction => direction;
    [SerializeField] protected PlayerCtrl playerCtrl;
    protected PlayerCtrl PlayerCtrl => playerCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadRigidbody();
        LoadPlayerCtrl();
    }
    private void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        playerCtrl = GetComponentInParent<PlayerCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerCtrl()", gameObject);
    }
    private void LoadRigidbody()
    {
        if (rb != null) return;
        rb = GetComponentInParent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        Debug.LogWarning(transform.name + ": LoadRigidbody()", gameObject);
    }
    //Call ở animationPlayer
    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }
    protected override void Moving()
    {
        rb.velocity = direction * moveSpeed;
    }
    //ADD Speed
    //Move after
    [Header("Add Speed")]
    [SerializeField] protected int MaxStackBoots = 10;
    [SerializeField] protected int currentStackBoots = 0;
    [SerializeField] protected float speedPerStack = 0.1f;
    [SerializeField] protected float baseMoveSpeed = 5f;
    [SerializeField] protected float percent = 0f;
    protected override void Start()
    {
        base.Start();
        SetTotalSpeed();
    }
    public void AddStackBoots()
    {
        if (CheckMaxStackBoots()) return;
        currentStackBoots++;
        SetTotalSpeed();
    }
    protected virtual bool CheckMaxStackBoots()
    {
        if (currentStackBoots > MaxStackBoots)
        {
            currentStackBoots = MaxStackBoots;
        }
        return currentStackBoots == MaxStackBoots;
    }
    public void BaseBuffTempSpeed(int percent, float duration)
    {
        StartCoroutine(BuffTempSpeed(percent, duration));
    }
    public IEnumerator BuffTempSpeed(int percent, float duration)
    {
        AddPercentSpeed(percent);
        SetTotalSpeed();

        yield return new WaitForSeconds(duration);

        AddPercentSpeed(percent * (-1));
        SetTotalSpeed();
    }
    protected virtual void SetTotalSpeed()
    {
        moveSpeed = (baseMoveSpeed + speedPerStack * currentStackBoots) * (1 + percent / 100);
    }
    public void AddPercentSpeed(int percent)
    {
        this.percent += percent;
        SetTotalSpeed();
    }
    public virtual void AddSpeed(float amount)
    {
        baseMoveSpeed += amount;
        SetTotalSpeed();
    }
}
