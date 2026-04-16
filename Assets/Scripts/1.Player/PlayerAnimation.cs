using System;
using UnityEngine;
public enum PlayerState
{
    Idle,
    Move,
    Attack
}
public class PlayerAnimation : SaiMonoBehaviour
{
    [SerializeField] protected PlayerState currentState;
    [SerializeField] Animator animator;
    protected Vector2 direction;
    public Vector2 Direction => direction;
    protected bool PressLeftMouse;
    protected bool chooseAttack = true;
    [SerializeField] private float coolDown = 0.3f;
    [SerializeField] private float timerOfCoolDown = 0.3f;
    protected float timerOfAttackFinish = 0f;
    protected float TimeAnimationAttackFinish = 0.3f;
    [SerializeField] protected PlayerCtrl playerCtrl;
    protected PlayerCtrl PlayerCtrl => playerCtrl;
    [SerializeField] protected PlayerMovement playerMovement;
    protected PlayerMovement PlayerMovement => playerMovement;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAnimator();
        LoadPlayerCtrl();
        LoadPlayerMovement();
    }
    private void LoadAnimator()
    {
        if (animator != null) return;
        animator = GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnimator()", gameObject);
    }
    private void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        playerCtrl = GetComponentInParent<PlayerCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerCtrl()", gameObject);
    }
    private void LoadPlayerMovement()
    {
        if (playerMovement != null) return;
        playerMovement = PlayerCtrl.GetComponentInChildren<PlayerMovement>();
        Debug.LogWarning(transform.name + ": LoadPlayerMovement()", gameObject);
    }
    protected virtual void Update()
    {
        GetInPut();
        CheckCoolDown();
        CheckState();
    }
    private void CheckState()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                HandleIdle();
                break;
            case PlayerState.Move:
                HandleMove();
                break;
            case PlayerState.Attack:
                HandleAttack();
                break;
        }
    }
    private void GetInPut()
    {
        if (InputManager.Instance == null) return;

        float h = InputManager.Instance.Horizontal;
        float v = InputManager.Instance.Vertical;

        direction = new Vector2(h, v).normalized; // không nhanh hơn khi đi chéo
        SetMove();

        PressLeftMouse = InputManager.Instance.LeftMouse;
    }
    private void OnChangeState(PlayerState state)
    {
        if (currentState == state) return; // đang ở state đó rồi thì bỏ qua

        currentState = state;

        switch (currentState)
        {
            case PlayerState.Idle:
                animator.SetBool("isMoving", false);
                PlayerMovement.SetDirection(Vector2.zero);
                break;

            case PlayerState.Move:
                animator.SetBool("isMoving", true);
                break;

            case PlayerState.Attack:
                chooseAttack = !chooseAttack;
                animator.SetBool("chooseAttack", chooseAttack);
                animator.SetTrigger("attack");
                AudioManager.Instance.PlaySFX(AudioManager.Instance.knifeCut);
                PlayerCtrl.PlayerDamageSender.Send();
                SetTimerOfCoolDown(0f);
                break;
        }
    }
    protected void SetMove()
    {
        PlayerMovement.SetDirection(direction);
    }
    private void HandleIdle()
    {
        if (direction != Vector2.zero)
            OnChangeState(PlayerState.Move);

        if (PressLeftMouse && timerOfCoolDown >= coolDown)
            OnChangeState(PlayerState.Attack);
    }
    private void HandleMove()
    {

        if (direction == Vector2.zero)
        {
            OnChangeState(PlayerState.Idle);
            return;
        }

        if (PressLeftMouse && timerOfCoolDown >= coolDown)
        {
            OnChangeState(PlayerState.Attack);
            return;
        }
        // Cập nhật animation hướng đi (thay đổi liên tục)
        animator.SetFloat("moveX", direction.x);
        animator.SetFloat("moveY", direction.y);
    }
    private void HandleAttack()
    {
        if (CheckDoneAttackFinish())
        {
            if (direction != Vector2.zero)
                OnChangeState(PlayerState.Move);
            else
                OnChangeState(PlayerState.Idle);

            SetTimerOfAttackFinish(0f);
        }
    }
    public bool CheckDoneAttackFinish()
    {
        timerOfAttackFinish += Time.deltaTime;
        return timerOfAttackFinish >= TimeAnimationAttackFinish;

    }
    private bool CheckCoolDown()
    {
        timerOfCoolDown += Time.deltaTime;
        return timerOfCoolDown >= coolDown;
    }
    private void SetTimerOfCoolDown(float timer)
    {
        this.timerOfCoolDown = timer;
    }
    private void SetTimerOfAttackFinish(float timer)
    {
        this.timerOfAttackFinish = timer;
    }
}
