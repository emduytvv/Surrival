using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MovementTextReduce : Movement
{
    [SerializeField] private TextMeshPro text;
    private Vector3 velocity;
    private float gravity = 4f;
    protected override void LoadComponents()
    {
        if (text != null) return;
        if (text == null) text = transform.parent.GetComponentInChildren<TextMeshPro>();
    }
    protected virtual void OnEnable()
    {
        // Random hướng trái hoặc phải
        float horizontalDirection = Random.Range(0, 2) == 0 ? -1f : 1f;
        // Tạo vận tốc ban đầu
        velocity = new Vector3(
        horizontalDirection * Random.Range(0.2f, 0.6f), // Tốc độ ngang
        Random.Range(1f, 1.5f), 0);                      // Tốc độ lên     
    }
    protected override void Moving()
    {
        velocity.y -= gravity * Time.fixedDeltaTime;
        transform.parent.position += velocity * moveSpeed * Time.fixedDeltaTime;
    }
}
