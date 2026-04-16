using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MovementToTarget
{
    protected static CameraMovement instance;
    public static CameraMovement Instance => instance;

    private Vector3 shakeOffset = Vector3.zero;
    private float shakeTimer = 0f;
    [SerializeField] private float shakeDuration = 0.02f;
    [SerializeField] private float shakeMagnitude = 0.01f;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    protected override void FixedUpdate()
    {

    }
    private void LateUpdate()
    {
        Moving();
    }
    public void Shake()
    {
        shakeTimer = shakeDuration;
        Debug.Log("shake");
    }
    protected override void Start()
    {
        base.Start();
        target = ObjectReference.Instance.Player.transform;
    }

    protected override void Moving()
    {
        if (!target) return;

        if (shakeTimer > 0)
        {
            shakeOffset = (Vector3)Random.insideUnitCircle * shakeMagnitude;
            shakeTimer -= Time.fixedDeltaTime;
        }
        else
        {
            shakeOffset = Vector3.zero;
        }

        // Follow player dùng Lerp (mịn)
        Vector3 desired = target.position + offset;

        Vector3 smoothPos = Vector3.Lerp(transform.position, desired, moveSpeed * Time.deltaTime);
        // Shake cộng trực tiếp — không qua Lerp
        transform.position = smoothPos + shakeOffset;

    }
}
