using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questable : MonoBehaviour
{
    public Quest quest;
    public bool isFinished = false;

    public void DelegateQuest(){

        if (isFinished == false){
            if (quest.questStatus == Quest.QuestStatus.Waitting){
                //任务还没被领取，玩家可以领取
                PlayerControllor.instance.questList.Add(quest);
                quest.questStatus = Quest.QuestStatus.Accepted;
            }
            else{
                //任务已经被领取， 不能重复领取
                Debug.Log("Quest: " + quest.questName + "has been accepted already!");
            }
        }
        
    }
}
