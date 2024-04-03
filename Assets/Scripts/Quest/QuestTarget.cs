using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTarget : MonoBehaviour
{
    public string questName;
    public enum QuestType { Gathering, Talk, Reach };
    public QuestType questType;


    [Header("Gathering Type Quest")]
    public int amount = 1;

    [Header("Talk Type Quest")]
    public bool hasTalked;

    [Header("Reach Type Quest")]
    public bool hasReached;

    //用来判断时候完成任务
    //判断不同类型的任务是否完成
    public void QuestComplete(){
        for (int i = 0; i < PlayerControllor.instance.questList.Count; i++){
            if (questName == PlayerControllor.instance.questList[i].questName 
                && PlayerControllor.instance.questList[i].questStatus == Quest.QuestStatus.Accepted){

                    switch (questType){
                        case QuestType.Gathering:
                            //视频10：28处讲了这里，记得做完item部分要补上！！！
                            //=========================================================
                            break;

                        case QuestType.Talk:
                            if (hasTalked){
                                PlayerControllor.instance.questList[i].questStatus = Quest.QuestStatus.Completed;
                                QuestManager.instance.UpdateQuestList();
                            }
                            break;

                        case QuestType.Reach:
                            if (hasReached){
                                PlayerControllor.instance.questList[i].questStatus = Quest.QuestStatus.Completed;
                                QuestManager.instance.UpdateQuestList();
                            }
                            break;
                    }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other .CompareTag("Player")){
            
            if (questType == QuestType.Reach){
                hasReached = true;
                QuestComplete();
            }

        }
    }

}
