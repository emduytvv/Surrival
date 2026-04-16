using System;
using UnityEngine;

[Serializable]
public enum ItemCode
{
    NoItem = 0,
    Exp = 1,
    Coin = 2,
    Boots = 3,
    Energy = 4,
    Book = 5,
    Stone = 6,

}
public class ItemCodeToString
{
    public static ItemCode ToString(string itemName)
    {
        return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
    }
}