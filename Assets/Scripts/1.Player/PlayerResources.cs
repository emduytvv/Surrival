using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : SaiMonoBehaviour
{
    [SerializeField] private PlayerWallet playerWallet;
    public PlayerWallet PlayerWallet => playerWallet;
    [SerializeField] private PlayerEnergy playerEnergy;
    public PlayerEnergy PlayerEnergy => playerEnergy;
    [SerializeField] private PlayerExperience playerExperience;
    public PlayerExperience PlayerExperience => playerExperience;
    [SerializeField] private PlayerMovement playerMovement;
    public PlayerMovement PlayerMovement => playerMovement;
    [SerializeField] private PlayerStone playerStone;
    public PlayerStone PlayerStone => playerStone;

    [SerializeField] private PlayerBook playerBook;
    public PlayerBook PlayerBook => playerBook;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerWallet();
        LoadPlayerEnergy();
        LoadPlayerExperience();
        LoadPlayerMovement();
        LoadPlayerStone();
        LoadPlayerBook();
    }
    private void LoadPlayerWallet()
    {
        if (playerWallet != null) return;
        playerWallet = GetComponentInChildren<PlayerWallet>();
        Debug.LogWarning(transform.name + ": LoadPlayerWallet()", gameObject);
    }
    private void LoadPlayerEnergy()
    {
        if (playerEnergy != null) return;
        playerEnergy = GetComponentInChildren<PlayerEnergy>();
        Debug.LogWarning(transform.name + ": LoadPlayerEnergy()", gameObject);
    }
    private void LoadPlayerExperience()
    {
        if (playerExperience != null) return;
        playerExperience = GetComponentInChildren<PlayerExperience>();
        Debug.LogWarning(transform.name + ": LoadPlayerExperience()", gameObject);
    }
    private void LoadPlayerMovement()
    {
        if (playerMovement != null) return;
        playerMovement = GetComponentInChildren<PlayerMovement>();
        Debug.LogWarning(transform.name + ": LoadPlayerMovement()", gameObject);
    }

    private void LoadPlayerStone()
    {
        if (playerStone != null) return;
        playerStone = GetComponentInChildren<PlayerStone>();
        Debug.LogWarning(transform.name + ": LoadPlayerStone()", gameObject);
    }

    private void LoadPlayerBook()
    {
        if (playerBook != null) return;
        playerBook = GetComponentInChildren<PlayerBook>();
        Debug.LogWarning(transform.name + ": LoadPlayerBook()", gameObject);
    }
}
