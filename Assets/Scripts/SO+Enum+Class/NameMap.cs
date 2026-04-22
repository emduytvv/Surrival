using System;
using UnityEngine;

[Serializable]
public enum NameMap
{
    Tutorial = 1,
    TheForest = 2,


}
public class NameMapToString
{
    public static NameMap ToString(string itemName)
    {
        return (NameMap)System.Enum.Parse(typeof(NameMap), itemName);
    }
}
public class GetPreviousMap
{
    public static string GetNamePreviousMap(string currentMap)
    {
        if (!Enum.TryParse(currentMap, out NameMap current)) return null;
        NameMap previous = current - 1;
        if (!Enum.IsDefined(typeof(NameMap), previous)) return null;
        return previous.ToString();
    }
}
