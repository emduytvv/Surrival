using System;
using UnityEngine;

[Serializable]
public enum FXName
{
    Summon = 1,

}
public class NameFXNameToString
{
    public static FXName ToString(string itemName)
    {
        return (FXName)System.Enum.Parse(typeof(FXName), itemName);
    }
}