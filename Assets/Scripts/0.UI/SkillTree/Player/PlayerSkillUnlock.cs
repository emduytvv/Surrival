using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSkillUnlock : BaseSkillUnlock
{
    [SerializeField] protected Transform imageLock;
    [SerializeField] protected PlayerWallet playerWallet;
    [SerializeField] protected PlayerExperience playerExperience;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImageUnlock();
    }
    private void LoadImageUnlock()
    {
        if (imageLock != null) return;
        imageLock = transform.Find("Background");
        Debug.LogWarning(transform.name + ": LoadImageUnlock()", gameObject);
    }
    protected override void Start()
    {
        base.Start();
        LoadAbility();
    }
    private void LoadAbility()
    {
        playerWallet = ObjectReference.Instance.Player.GetComponentInChildren<PlayerWallet>();
        playerExperience = ObjectReference.Instance.Player.GetComponentInChildren<PlayerExperience>();
    }
    public override void CheckUnlock()
    {
        if (unLock) return;
        if (!CheckLevelRequire()) return;
        if (!CheckRequireSkillId()) return;
        if (!CheckSpendGold()) return;

        unLock = true;
        imageLock.gameObject.SetActive(false);
        ShowImageButtomRight();
        SetTextUnlock();
    }
    private bool CheckLevelRequire()
    {
        if (SkillTreePlayerManager.Instance.GetSkillStats().levelRequire > playerExperience.CurrentLevel)
        {
            OnNotEnough("Not enough level");
            return false;
        }
        return true;
    }
    private bool CheckSpendGold()
    {
        if (!playerWallet.TrySpendGold(SkillTreePlayerManager.Instance.GetSkillStats().Cost))
        {
            OnNotEnough("Not enough Gold");
            return false;
        }
        return true;
    }
    private bool CheckRequireSkillId()
    {
        int[] requireSkillId = SkillTreePlayerManager.Instance.GetSkillStats().requiredSkillId;
        if (requireSkillId.Length < 1) return true;
        foreach (int id in requireSkillId)
        {

            if (SkillTreePlayerManager.Instance.GetSkillUnlockById(id).unLock) continue;
            string nameSkill = SkillTreePlayerManager.Instance.GetSkillStatsById(id).nameSkill;
            OnNotEnough("You need to unlock skill " + nameSkill);
            return false;
        }
        return true;
    }
    public override void SetTextUnlock()
    {
        SkillTreePlayerManager.Instance.GetBtnSkillStats().TextCost.gameObject.SetActive(!unLock);
        SkillTreePlayerManager.Instance.GetBtnSkillStats().textUnlock.gameObject.SetActive(unLock);

    }
    protected virtual void ShowImageButtomRight()
    {
        int skillId = SkillTreePlayerManager.Instance.currentSkillId;
        if (skillId == 6)
        {
            ButtomRightCtrl.Instance.BtnSkillBuff1.gameObject.SetActive(true);
            ButtomRightCtrl.Instance.spriteBtnSkillBuff1.sprite = SkillTreePlayerManager.Instance.GetSkillStats().imageSkill.sprite;
        }
        if (skillId == 0 || skillId == 1 || skillId == 2)
        {
            ButtomRightCtrl.Instance.BtnSkillDamage1.gameObject.SetActive(true);
            ButtomRightCtrl.Instance.spriteBtnSkillDamage1.sprite = SkillTreePlayerManager.Instance.GetSkillStats().imageSkill.sprite;
            //Set name skill on ButtomRight
            string nameSkill = SkillTreePlayerManager.Instance.GetSkillStats().nameSkill;
            ButtomRightCtrl.Instance.spriteBtnSkillDamage1.GetComponent<BtnSkillDamage1>().SetNameSkill(nameSkill);
        }
        if (skillId == 3 || skillId == 4 || skillId == 5)
        {
            ButtomRightCtrl.Instance.BtnSkillDamage2.gameObject.SetActive(true);
            ButtomRightCtrl.Instance.spriteBtnSkillDamage2.sprite = SkillTreePlayerManager.Instance.GetSkillStats().imageSkill.sprite;
            //Set name skill on ButtomRight
            string nameSkill = SkillTreePlayerManager.Instance.GetSkillStats().nameSkill;
            ButtomRightCtrl.Instance.spriteBtnSkillDamage2.GetComponent<BtnSkillDamage2>().SetNameSkill(nameSkill);
        }
    }

}