using UnityEngine;

public class PetCtrlCombat : PetCtrl
{
    [SerializeField] protected PetCombat petCombat;
    public PetCombat PetCombat => petCombat;
    [SerializeField] protected PetCombatMovement petMovement;
    public PetCombatMovement PetMovement => petMovement;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPetCombat();
        LoadPetMovement();
    }
    private void LoadPetCombat()
    {
        if (petCombat != null) return;
        petCombat = GetComponentInChildren<PetCombat>();
        Debug.LogWarning(transform.name + ": LoadPetCombat()", gameObject);
    }
    private void LoadPetMovement()
    {
        if (petMovement != null) return;
        petMovement = GetComponentInChildren<PetCombatMovement>();
        Debug.LogWarning(transform.name + ": LoadPetMovement()", gameObject);
    }
}
