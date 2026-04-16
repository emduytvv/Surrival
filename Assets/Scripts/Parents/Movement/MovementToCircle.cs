using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementToCircle : MovementByDirection
{
    public float radialSpeed = 1f;     // ra ngoài (unit/s)
    public float angularSpeed = 3f;    // quay (rad/s)
    float r;
    float a;
    Vector3 center;
    void OnEnable()
    {
        StartCoroutine(InitNextFrame());
        r = 0f;
        a = 0f;
    }
    protected override void Moving()
    {
        float dt = Time.fixedDeltaTime;

        r += radialSpeed * dt;
        a += angularSpeed * dt;

        Vector3 targetPos = new Vector3(Mathf.Cos(a), Mathf.Sin(a), 0f) * r;
        transform.parent.position = targetPos + center;
    }
    IEnumerator InitNextFrame()
    {
        yield return null; // đợi spawner set position xong
        center = transform.parent.position;
    }
}
