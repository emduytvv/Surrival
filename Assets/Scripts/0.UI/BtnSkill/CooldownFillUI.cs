using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CooldownFillUI : SaiMonoBehaviour
{
    [SerializeField] protected float cooldown = 20f;
    [SerializeField] protected Image imageFill;
    [SerializeField] protected TextMeshProUGUI time;
    [SerializeField] protected float timer;
    protected void SetCooldown(float cooldown)
    {
        this.cooldown = cooldown;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImageFill();
        LoadTime();
    }

    private void LoadTime()
    {
        if (time != null) return;
        time = transform.Find("Time").GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadTime()", gameObject);
    }

    private void LoadImageFill()
    {
        if (imageFill != null) return;
        imageFill = transform.GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadImageFill()", gameObject);
    }
    void Update()
    {
        FillImage();
    }
    protected void FillImage()
    {
        if (imageFill.fillAmount >= 1)
        {
            SetactiveTimer(false);
            return;
        }
        UpdateTimer();
        SetactiveTimer(true);
        imageFill.fillAmount += Time.deltaTime / cooldown;
    }
    private void SetactiveTimer(bool check)
    {
        time.transform.gameObject.SetActive(check);
    }
    private void UpdateTimer()
    {
        timer -= Time.deltaTime;
        time.text = $"{timer:00}";
    }

    public void Active(float cooldown)
    {
        timer = cooldown;
        SetCooldown(cooldown);
        imageFill.fillAmount = 0f;
    }

}
