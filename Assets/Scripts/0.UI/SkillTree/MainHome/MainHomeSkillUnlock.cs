using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class MainHomeSkillUnlock : BaseSkillUnlock
{
    [SerializeField] protected Transform imageLock;
    [SerializeField] protected PlayerStone playerStone;
    [SerializeField] protected PlayerBook playerBook;
    [SerializeField] protected PlayerExperience playerExperience;
    [SerializeField] protected Transform mainHome;
    [SerializeField] protected AbilityBulletFire abilityBulletFire;
    [SerializeField] protected AbilityBulletIce abilityBulletIce;
    [SerializeField] protected AbilityBulletLight abilityBulletLight;
    [SerializeField] protected AbilityBulletWind abilityBulletWind;
    [SerializeField] protected AbilityBulletEarth abilityBulletEarth;
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
        LoadStatsPlayer();
        LoadAbilityMainHome();
    }
    private void LoadStatsPlayer()
    {
        playerStone = ObjectReference.Instance.Player.GetComponentInChildren<PlayerStone>();
        playerBook = ObjectReference.Instance.Player.GetComponentInChildren<PlayerBook>();
        playerExperience = ObjectReference.Instance.Player.GetComponentInChildren<PlayerExperience>();
    }
    private void LoadAbilityMainHome()
    {
        mainHome = ObjectReference.Instance.MainHome.transform;
        abilityBulletFire = ObjectReference.Instance.MainHome.transform.Find("MainHomeAbility").GetComponentInChildren<AbilityBulletFire>();
        abilityBulletIce = ObjectReference.Instance.MainHome.transform.Find("MainHomeAbility").GetComponentInChildren<AbilityBulletIce>();
        abilityBulletLight = ObjectReference.Instance.MainHome.transform.Find("MainHomeAbility").GetComponentInChildren<AbilityBulletLight>();
        abilityBulletWind = ObjectReference.Instance.MainHome.transform.Find("MainHomeAbility").GetComponentInChildren<AbilityBulletWind>();
        abilityBulletEarth = ObjectReference.Instance.MainHome.transform.Find("MainHomeAbility").GetComponentInChildren<AbilityBulletEarth>();
    }
    public override void CheckUnlock()
    {
        if (unLock) return;
        if (!CheckLevelRequire()) return;
        if (!CheckRequireSkillId()) return;
        if (!CheckSpendBook()) return;
        if (!CheckSpendStone()) return;

        unLock = true;
        imageLock.gameObject.SetActive(false);
        ActivatedSkill();
        // ShowImageButtomRight();
        SetTextUnlock();
    }

    private void ActivatedSkill()
    {
        string nameSkill = SkillTreeMainHomeManager.Instance.GetSkillStats().nameSkill;
        switch (nameSkill)
        {
            case "BulletFire":
                abilityBulletFire.SetActivated(true);
                break;
            case "BulletIce":
                abilityBulletIce.SetActivated(true);
                break;
            case "BulletLight":
                abilityBulletLight.SetActivated(true);
                break;
            case "BulletWind":
                abilityBulletWind.SetActivated(true);
                break;
            case "BulletEarth":
                abilityBulletEarth.SetActivated(true);
                break;
            case "Dog":
                PetSpawner.Instance.SpawnOnCall("Dog", mainHome.position + Vector3.right * 2);
                break;
            case "Bird":
                PetSpawner.Instance.SpawnOnCall("Bird", mainHome.position + Vector3.right * 2);
                break;
            case "Bear":
                PetSpawner.Instance.SpawnOnCall("Bear", mainHome.position + Vector3.right * 2);
                break;
            case "Angel":
                PetSpawner.Instance.SpawnOnCall("Angle", mainHome.position + Vector3.right * 2);
                break;
        }
    }
    private bool CheckLevelRequire()
    {
        if (SkillTreeMainHomeManager.Instance.GetSkillStats().levelRequire > playerExperience.CurrentLevel)
        {
            OnNotEnough("Not enough level");
            return false;
        }
        return true;
    }
    private bool CheckSpendBook()
    {
        if (!playerBook.TrySpendBook(SkillTreeMainHomeManager.Instance.GetSkillStats().RequiredBook))
        {
            OnNotEnough("Not enough Book");
            return false;
        }
        return true;
    }
    private bool CheckSpendStone()
    {
        if (!playerStone.TrySpendStone(SkillTreeMainHomeManager.Instance.GetSkillStats().RequiredStone))
        {
            OnNotEnough("Not enough Stone");
            return false;
        }
        return true;
    }
    private bool CheckRequireSkillId()
    {
        int[] requireSkillId = SkillTreeMainHomeManager.Instance.GetSkillStats().requiredSkillId;
        if (requireSkillId.Length < 1) return true;
        foreach (int id in requireSkillId)
        {

            if (SkillTreeMainHomeManager.Instance.GetSkillUnlockById(id).unLock) continue;
            string nameSkill = SkillTreeMainHomeManager.Instance.GetSkillStatsById(id).nameSkill;
            OnNotEnough("You need to unlock skill " + nameSkill);
            return false;
        }
        return true;
    }
    public override void SetTextUnlock()
    {
        SkillTreeMainHomeManager.Instance.GetBtnSkillStats().TransformBook.gameObject.SetActive(!unLock);
        SkillTreeMainHomeManager.Instance.GetBtnSkillStats().TransformStone.gameObject.SetActive(!unLock);
        SkillTreeMainHomeManager.Instance.GetBtnSkillStats().textUnlock.gameObject.SetActive(unLock);

    }
    // protected virtual void ShowImageButtomRight()
    // {
    //     int skillId = SkillTreePlayerManager.Instance.currentSkillId;
    //     if (skillId == 6)
    //     {
    //         ButtomRightCtrl.Instance.BtnSkillBuff1.gameObject.SetActive(true);
    //         ButtomRightCtrl.Instance.spriteBtnSkillBuff1.sprite = SkillTreePlayerManager.Instance.GetSkillStats().imageSkill.sprite;
    //     }
    //     if (skillId == 0 || skillId == 1 || skillId == 2)
    //     {
    //         ButtomRightCtrl.Instance.BtnSkillDamage1.gameObject.SetActive(true);
    //         ButtomRightCtrl.Instance.spriteBtnSkillDamage1.sprite = SkillTreePlayerManager.Instance.GetSkillStats().imageSkill.sprite;
    //         //Set name skill on ButtomRight
    //         string nameSkill = SkillTreePlayerManager.Instance.GetSkillStats().nameSkill;
    //         ButtomRightCtrl.Instance.spriteBtnSkillDamage1.GetComponent<BtnSkillDamage1>().SetNameSkill(nameSkill);
    //     }
    //     if (skillId == 3 || skillId == 4 || skillId == 5)
    //     {
    //         ButtomRightCtrl.Instance.BtnSkillDamage2.gameObject.SetActive(true);
    //         ButtomRightCtrl.Instance.spriteBtnSkillDamage2.sprite = SkillTreePlayerManager.Instance.GetSkillStats().imageSkill.sprite;
    //         //Set name skill on ButtomRight
    //         string nameSkill = SkillTreePlayerManager.Instance.GetSkillStats().nameSkill;
    //         ButtomRightCtrl.Instance.spriteBtnSkillDamage2.GetComponent<BtnSkillDamage2>().SetNameSkill(nameSkill);
    //     }
    // }

}