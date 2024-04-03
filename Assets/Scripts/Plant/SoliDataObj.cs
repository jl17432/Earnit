using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SoliData"), System.Serializable]
public class SoliDataObj : ScriptableObject
{
    public List<SoliData> data = new List<SoliData>();
}
