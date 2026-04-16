using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtomRightCtrl : SaiMonoBehaviour
{
    protected static ButtomRightCtrl instance;
    public static ButtomRightCtrl Instance => instance;
    [SerializeField] protected Transform btnSkillBuff1;
    public Transform BtnSkillBuff1 => btnSkillBuff1;
    [SerializeField] protected Transform btnSkillDamage1;
    public Transform BtnSkillDamage1 => btnSkillDamage1;
    [SerializeField] protected Transform btnSkillDamage2;
    public Transform BtnSkillDamage2 => btnSkillDamage2;
    public Image spriteBtnSkillDamage1;
    public Image spriteBtnSkillDamage2;
    public Image spriteBtnSkillBuff1;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBtnSkillBuff1();
        LoadBtnSKillDamage1();
        LoadBtnSKillDamage2();
    }
    private void LoadBtnSkillBuff1()
    {
        if (btnSkillBuff1 != null) return;
        btnSkillBuff1 = transform.Find("BtnSkillBuff1");
        spriteBtnSkillBuff1 = btnSkillBuff1.transform.Find("BtnSkillBuff1").GetComponentInChildren<Image>();
        btnSkillBuff1.gameObject.SetActive(false);
        Debug.LogWarning(transform.name + ": LoadBtnSkillBuff1()", gameObject);
    }
    private void LoadBtnSKillDamage1()
    {
        if (btnSkillDamage1 != null) return;
        btnSkillDamage1 = transform.Find("BtnSkillDamage1");
        spriteBtnSkillDamage1 = btnSkillDamage1.transform.Find("BtnSkillDamage1").GetComponentInChildren<Image>();
        btnSkillDamage1.gameObject.SetActive(false);
        Debug.LogWarning(transform.name + ": LoadBtnSKillDamage1()", gameObject);
    }
    private void LoadBtnSKillDamage2()
    {
        if (btnSkillDamage2 != null) return;
        btnSkillDamage2 = transform.Find("BtnSkillDamage2");
        spriteBtnSkillDamage2 = btnSkillDamage2.transform.Find("BtnSkillDamage2").GetComponentInChildren<Image>();
        btnSkillDamage2.gameObject.SetActive(false);
        Debug.LogWarning(transform.name + ": LoadBtnSKillDamage2()", gameObject);
    }
    protected override void Awake()
    {
        ButtomRightCtrl.instance = this;
        base.Awake();
    }
}
