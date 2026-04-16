using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetFindEnemy : FindTargetObject
{
    [SerializeField] protected PetCtrlCombat petCtrl;
    protected virtual void Update()
    {
        if (CheckCurrentTarget())
        {
            petCtrl.PetCombat.SetFoundTarget(true);
            return;
        }
        petCtrl.PetCombat.SetFoundTarget(false);
        FindEnemyInRange();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPetCtrl();
    }
    protected override void LoadLayerMaskName()
    {
        LayerMaskName = "Enemy";
    }
    private void LoadPetCtrl()
    {
        if (petCtrl != null) return;
        petCtrl = transform.parent.GetComponent<PetCtrlCombat>();
        Debug.LogWarning(transform.name + ": LoadPetCtrl()", gameObject);
    }
    protected virtual void FixedUpdate()
    {
        TransmitTargetToMovement();
    }
    protected virtual void TransmitTargetToMovement()
    {
        if (currentTarget == null)
        {
            petCtrl.PetMovement.SetTarget(null);
            return;
        }
        petCtrl.PetMovement.SetTarget(currentTarget);
    }
}
