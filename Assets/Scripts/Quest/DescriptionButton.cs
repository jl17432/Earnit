using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionButton : MonoBehaviour
{
    [SerializeField] int index;

    public void showThisDescription_0(){
        QuestManager.instance.ShowDescriptionPanel(0);
    }

    public void showThisDescription_1(){
        QuestManager.instance.ShowDescriptionPanel(1);
    }

    public void showThisDescription_2(){
        QuestManager.instance.ShowDescriptionPanel(2);
    }

    public void showThisDescription_3(){
        QuestManager.instance.ShowDescriptionPanel(3);
    }

}
