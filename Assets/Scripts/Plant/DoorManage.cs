using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DoorManage : MonoBehaviour
{
    public static bool isOne = true;

    public DoorData data;

    Door[] doors;

    [SerializeField] AudioClip buySE;

    private void Awake()
    {
        doors = GetComponentsInChildren<Door>();

        if (isOne)
        {
            isOne = false;

            data.data = new List<bool>();
            for (int i = 0; i < doors.Length; i++)
            {
                data.data.Add(false);
            }
        }   
    }

    private void Start()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            int temp = i;
            doors[i].isOpen = data.data[i];
            doors[i].buyBtn.onClick.AddListener(() => Buy(temp));
        }

        EditorUtility.SetDirty(data);

    }

    void Buy(int i)
    {
        if (UI_manager.instance.budget >= doors[i].money)
        {
            UI_manager.instance.budget -= doors[i].money;
            AudioManager.instance.PlayUISE(buySE);

            
            doors[i].isOpen = true;
            data.data[i] = true;
        }
        else
        {
            string tip = "lack of money!";
            UI_manager.instance.ShowTip(tip);
        }
    }
}
