using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : MonoBehaviour
{
    [SerializeField] private bool isEntered;
    [TextArea(1,5)]
    public string[] lines;

    public Questable questable; //委派任务的能力

    public bool hasName = true;

    public QuestTarget questTarget;

    [TextArea(1,4)]
    public string[] congratsLines;

    [TextArea(1,4)]
    public string[] newLines;

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            isEntered = true;
            DialogManager.instance.currentQuestable = questable;
            DialogManager.instance.questTarget = questTarget;
            DialogManager.instance.talkable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player")){
            isEntered = false;
            DialogManager.instance.currentQuestable = null;
        }
    }

    private void Update(){
        if (isEntered && Input.GetKeyDown(KeyCode.E) && DialogManager.instance.dialogBox.activeInHierarchy == false){
            if (questable == null){
                DialogManager.instance.ShowDialog(lines, hasName);
            }
            else{
                if (questable.quest.questStatus == Quest.QuestStatus.Completed && questable.isFinished){
                    DialogManager.instance.ShowDialog(newLines, hasName);
                }
                else{
                    DialogManager.instance.ShowDialog(lines, hasName);
                }
            }
        }
    }
}
