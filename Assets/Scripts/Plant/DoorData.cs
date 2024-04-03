using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DoorData"), System.Serializable]
public class DoorData : ScriptableObject
{
    public List<bool> data = new List<bool>();
}
