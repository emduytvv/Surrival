using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    protected static InputManager instance;
    public static InputManager Instance => instance;
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool LeftMouse { get; private set; }   // chuột trái
    public bool RightMouse { get; private set; }   // chuột phải
    public bool MouseDown { get; private set; }
    protected Vector2 mousePosition;
    public Vector2 MousePosition => mousePosition;

    protected void Start()
    {
        InputManager.instance = this;
    }
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        LeftMouse = Input.GetMouseButtonDown(0);
        RightMouse = Input.GetMouseButtonDown(1);
        GetMousePosition();
        MouseDown = Input.GetMouseButtonDown(0);
    }
    private void GetMousePosition()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
