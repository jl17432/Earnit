using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using System;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    
    public GameObject[] questUIArray;

    public GameObject questPanel;
    public GameObject descriptionPanel;
    public GameObject questListPanel;

    public int currentFlag = 0;

    [TextArea(1,3)]
    public string [] DescriptionList;

    // private bool hasNextPage;

    private void Awake(){
        if (instance == null){
            instance = this;
        }
        else{
            if (instance != this){
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateQuestList(){
        // Debug.Log(currentFlag);
        for (int i = currentFlag ; i < currentFlag + 4; i++){
            int j = i % 4;
            if (i < PlayerControllor.instance.questList.Count){
                questUIArray[j].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = PlayerControllor.instance.questList[i].questName;
                if (PlayerControllor.instance.questList[i].questStatus == Quest.QuestStatus.Accepted){
                    questUIArray[j].transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "<color=red>" + "未完成" + "</color>";
                }
                else if (PlayerControllor.instance.questList[i].questStatus == Quest.QuestStatus.Completed){
                    questUIArray[j].transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "<color=green>" + "已完成" + "</color>";

                }

                DescriptionList[j] = PlayerControllor.instance.questList[i].questDescription[0];

            }
            else{
                questUIArray[j].transform.GetChild(0).GetChild(0).GetComponent<Text>().text ="";
                questUIArray[j].transform.GetChild(0).GetChild(1).GetComponent<Text>().text ="";
                DescriptionList[j] = "";
            }
        }
    }

    public void Update(){
        if (Input.GetKeyDown(KeyCode.Q) && PlayerControllor.instance.canMove == true){
            QuestManager.instance.ShowQuestPanel();
            // questPanel.SetActive(!questPanel.activeInHierarchy);
        }
    }

    public void nextPage(){
        int count = PlayerControllor.instance.questList.Count;
        int offset = 4 - count % 4;
        if ( currentFlag + 4 < count + offset){
            currentFlag += 4;
            UpdateQuestList();
        }
    }
    public void lastPage(){
        if (currentFlag >= 4){
            currentFlag -= 4;
            UpdateQuestList();
        }
    }

    public void HideQuestPanel(){
        questPanel.SetActive(false);
    }

    public void ShowQuestPanel(){
        currentFlag = 0;
        questPanel.SetActive(true);
        questListPanel.SetActive(true);
        descriptionPanel.SetActive(false);
        UpdateQuestList();
    }

    public void ShowDescriptionPanel(int index){
        descriptionPanel.SetActive(true);
        questListPanel.SetActive(false);
        // Debug.Log(index);
        descriptionPanel.transform.GetChild(0).GetComponent<Text>().text = DescriptionList[index];
        
    }

    public void backToQuestListPanel(){
        descriptionPanel.SetActive(false);
        UpdateQuestList();
        questListPanel.SetActive(true);
    }

}
