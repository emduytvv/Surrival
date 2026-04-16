using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MovementTextToUp : Movement
{
    [SerializeField] private TextMeshPro text;
    private Vector3 velocity;
    private float gravity = 2f;
    protected override void LoadComponents()
    {
        if (text != null) return;
        if (text == null) text = transform.parent.GetComponentInChildren<TextMeshPro>();
    }
    protected virtual void OnEnable()
    {
        velocity = new Vector3(0, Random.Range(1f, 1.5f), 0);                      // Tốc độ lên     
    }
    protected override void Moving()
    {
        velocity.y -= gravity * Time.fixedDeltaTime;
        transform.parent.position += velocity * moveSpeed * Time.fixedDeltaTime;
    }
}
