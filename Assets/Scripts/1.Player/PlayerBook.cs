using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBook : SaiMonoBehaviour
{
    [SerializeField] protected int maxBook = 100000;
    [SerializeField] protected int currentBook = 0;
    public int CurrentBook => currentBook;
    public void AddBook(int amount)
    {
        if (amount < 0) return;
        if (currentBook > maxBook - amount) return;

        currentBook += amount;
        CheckMaxBook();
    }

    protected virtual void CheckMaxBook()
    {
        if (currentBook > maxBook) { currentBook = maxBook; }
        if (currentBook < 0) { currentBook = 0; }
    }

    public bool TrySpendBook(int amount)
    {
        if (currentBook >= amount)
        {
            currentBook -= amount;
            return true;
        }
        else { return false; }
    }
}
