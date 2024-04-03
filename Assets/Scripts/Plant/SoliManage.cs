using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SoliManage : MonoBehaviour
{
    public static bool isOne = true;

    public SoliDataObj dataObj;

    Soli[] solis;

    private void Awake()
    {
        solis = GetComponentsInChildren<Soli>();

        if (isOne)
        {
            isOne = false;

            dataObj.data = new List<SoliData>();
            for (int i = 0; i < solis.Length; i++)
            {
                SoliData data = new SoliData(i);
                dataObj.data.Add(data);
                solis[i].data = data;
            }
        }
        else
        {
            for (int i = 0; i < solis.Length; i++)
            {
                solis[i].data = dataObj.data[i];
            }
        }

        EditorUtility.SetDirty(dataObj);
    }
}
