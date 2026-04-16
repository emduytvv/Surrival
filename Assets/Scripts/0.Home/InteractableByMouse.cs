using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableByMouse : SaiMonoBehaviour
{
    [SerializeField] private MainHomeCtrl mainHomeCtrl;
    [SerializeField] protected LayerMask interactMask;
    [SerializeField] private SpriteRenderer topFXMainHome;
    [SerializeField] private SpriteRenderer baseMainHome;
    private Color originalColor = Color.white;
    private Color hoverColor = new Color(0xF3 / 255f, 0x97 / 255f, 0x97 / 255f);
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadLayerMask();
        LoadMainHomeCtrl();
        LoadTopFXMainHome();
        LoadBaseMainHome();

    }
    private void LoadMainHomeCtrl()
    {
        if (mainHomeCtrl != null) return;
        mainHomeCtrl = GetComponentInParent<MainHomeCtrl>();
        Debug.LogWarning(transform.name + ": LoadMainHomeCtrl()", gameObject);
    }
    private void LoadLayerMask()
    {
        if (interactMask != 0) return;
        interactMask = LayerMask.GetMask("InteractableByMouse");
        Debug.LogWarning(transform.name + ": LoadComponents()", gameObject);
    }
    private void LoadTopFXMainHome()
    {
        if (topFXMainHome != null) return;
        topFXMainHome = mainHomeCtrl.transform.Find("Model/TopFX").GetComponent<SpriteRenderer>();
        Debug.LogWarning(transform.name + ": LoadTopFXMainHome()", gameObject);
    }

    private void LoadBaseMainHome()
    {
        if (baseMainHome != null) return;
        baseMainHome = mainHomeCtrl.transform.Find("Model/Base").GetComponent<SpriteRenderer>();
        Debug.LogWarning(transform.name + ": LoadBaseMainHome()", gameObject);
    }
    void Update()
    {
        CheckMouseDown();
        CheckHover();
    }
    private void CheckMouseDown()
    {
        if (!InputManager.Instance.MouseDown) return;

        Vector2 pos = InputManager.Instance.MousePosition;
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f, interactMask);

        if (hit.collider == null) return;
        hit.collider.GetComponent<InteractableByMouse>()?.Interact();
    }

    private void Interact()
    {
        CenterCtrl.Instance.SkillTreeMainHomeManager.gameObject.SetActive(true);
    }
    // private void OnMouseEnter()
    // {
    //     if (gameObject.layer != LayerMask.NameToLayer("InteractableByMouse")) return;
    //     topFXMainHome.color = hoverColor;
    //     baseMainHome.color = hoverColor;
    // }

    // private void OnMouseExit()
    // {
    //     topFXMainHome.color = originalColor;
    //     baseMainHome.color = originalColor;
    // }
    private void CheckHover()
    {
        Vector2 pos = InputManager.Instance.MousePosition;
        RaycastHit2D[] hits = Physics2D.RaycastAll(pos, Vector2.zero, 0f);

        bool isHovering = false;
        foreach (var hit in hits)
        {
            if (hit.collider.GetComponent<InteractableByMouse>() != null)
            {
                isHovering = true;
                break;
            }
        }

        if (isHovering)
        {
            topFXMainHome.color = hoverColor;
            baseMainHome.color = hoverColor;
        }
        else
        {
            topFXMainHome.color = originalColor;
            baseMainHome.color = originalColor;
        }
    }
}
