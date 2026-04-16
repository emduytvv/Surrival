using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/ObjectDropDataSO")]
public class ObjectDropDataSO : ScriptableObject
{
    public List<DropTable> DropTable;
}
