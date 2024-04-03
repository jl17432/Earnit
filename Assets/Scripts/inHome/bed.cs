using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bed : MonoBehaviour
{

    // 有一个2D collider， 如果player面向collider并按E建，应该弹出聊天框询问是否要结束今天
    // 如果结束今天，要更新日期，并添加一个fade效果

    [SerializeField] private bool isEntered;
    // [SerializeField] private bool goSleep = false;
    public GameObject dialogBox;

    

    private AudioSource wakeup_sound;

    // Start is called before the first frame update
    void Start()
    {
        wakeup_sound = transform.GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(isEntered && Input.GetKeyDown(KeyCode.E)){
            dialogBox.SetActive(true);
        }
    }


    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            isEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            isEntered = false;
        }
    }

    // public void SetGoSleepPos(){
    //     goSleep = true;
    // }

    // public void SetGoSleepNeg(){
    //     goSleep = false;
    // }
    
    public void hidePanel(){
        dialogBox.SetActive(false);
    }


    public void sleep(){
        AudioManager.instance.playAudio(wakeup_sound.clip);
        UI_manager.instance.nextDay();
        hidePanel();
    }

}
