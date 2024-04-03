using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;

    public GameObject dialogBox;
    public Text dialogContext, nameText;

    private AudioSource dialog_sound;

    private bool isScrolling;
    [SerializeField] float scrolling_speed;

    public Questable currentQuestable; //正在对话的NPC的委派任务的能力

    public QuestTarget questTarget;

    public Talkable talkable;
 



    [TextArea(1,3)]
    public string [] dialogLines;
    [SerializeField] private int currentLine;

    private void Awake(){
        if (instance == null){
            instance = this;
        }
        else{
            if(instance != this){
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start(){
        // dialog_sound = transform.GetComponent<AudioSource>();   
        dialog_sound = transform.GetChild(2).GetComponent<AudioSource>();

        dialogContext.text = dialogLines[currentLine];
    }
    
    private void Update(){
        
        if (dialogBox.activeInHierarchy){
            if (Input.GetMouseButtonUp(0)){
                if (isScrolling == false){
                    currentLine++;
                    AudioManager.instance.playAudio(dialog_sound.clip);
                    if (currentLine < dialogLines.Length){
                        CheckName();
                        // dialogContext.text = dialogLines[currentLine];     //这里是一行一行输出对话文字
                        StartCoroutine(ScrollingText());

                    }
                    else {
                        
                        // CheckQuestIsComplete();
                        // Debug.Log(CheckQuestIsComplete());
                        if (CheckQuestIsComplete() && currentQuestable.isFinished == false){
                            // Debug.Log("11111");
                            ShowDialog(talkable.congratsLines, talkable.hasName);
                            currentQuestable.isFinished = true;
                        }
                        else{
                            dialogBox.SetActive(false);
                            PlayerControllor.instance.canMove = true;
                            if (currentQuestable == null){
                                Debug.Log("No quest on this object!");
                            }
                            else{
                                currentQuestable.DelegateQuest();
                                // QuestManager.instance.UpdateQuestList();
                            }

                            if (questTarget != null){
                                //questTarget 不等于空， 说明该对象有任务目标
                                questTarget.hasTalked = true;
                                questTarget.QuestComplete();
                            }
                            else{
                                return;
                            }                       
                        }


                // BACK UP AERA!!!===============================================
                        // dialogBox.SetActive(false);
                        // PlayerControllor.instance.canMove = true;
                        // if (currentQuestable == null){
                        //     Debug.Log("No quest on this object!");
                        // }
                        // else{
                        //     currentQuestable.DelegateQuest();
                        //     // QuestManager.instance.UpdateQuestList();
                        // }

                        // if (questTarget != null){
                        //     //questTarget 不等于空， 说明该对象有任务目标
                        //     questTarget.hasTalked = true;
                        //     Debug.Log("111111");
                        //     questTarget.QuestComplete();
                        // }
                        // else{
                        //     return;
                        // }
                // BACK UP AERA!!!===============================================

                    }
                }

                
            }
        }
        
    }

    public void ShowDialog(string[] _newLines, bool _hasName){
        // if (dialogBox.activeInHierarchy == false){
            dialogLines = _newLines;
            currentLine = 0;
            CheckName();
            // dialogContext.text = dialogLines[currentLine];    //这里是一行一行输出对话文字
            StartCoroutine(ScrollingText());
            dialogBox.SetActive(true);
            nameText.gameObject.SetActive(_hasName);
            AudioManager.instance.playAudio(dialog_sound.clip);
            PlayerControllor.instance.canMove = false;
        // }
        
    }

    private void CheckName(){
        if (dialogLines[currentLine].StartsWith("n-")){
            nameText.text = dialogLines[currentLine].Replace("n-", "");
            currentLine++; 
        }
    }

    private IEnumerator ScrollingText(){
        isScrolling = true;
        dialogContext.text = "";

        foreach(char letter in dialogLines[currentLine].ToCharArray()){
            dialogContext.text += letter;
            yield return new WaitForSeconds(scrolling_speed);
        }

        isScrolling = false;
    }


    // 当和委派任务的NPC对话完成后，调用这个方法判断任务是否完成
    public bool CheckQuestIsComplete(){
        if (currentQuestable == null){
            return false;
        }

        for (int i = 0; i < PlayerControllor.instance.questList.Count; i++){
            if (currentQuestable.quest.questName == PlayerControllor.instance.questList[i].questName
                && PlayerControllor.instance.questList[i].questStatus == Quest.QuestStatus.Completed){
                    currentQuestable.quest.questStatus = Quest.QuestStatus.Completed;
                    return true;
                }
        }

        return false;
    }

}
