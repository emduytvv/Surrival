using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBook : BaseText
{
    [SerializeField] protected float currentBook;
    [SerializeField] protected PlayerBook playerBook;

    protected override void Start()
    {
        LoadPlayerBook();
    }

    protected override void Update()
    {
        base.Update();
        GetBook();
    }

    private void LoadPlayerBook()
    {
        playerBook = ObjectReference.Instance.Player.transform.GetComponentInChildren<PlayerBook>();
    }

    public void GetBook()
    {
        currentBook = playerBook.CurrentBook;
    }

    protected override void ShowText()
    {
        textMeshProUGUI.text = currentBook.ToString();
    }
}
