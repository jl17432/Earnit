using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPanelButton : MonoBehaviour
{
    private AudioSource click_sound;

    private void Start(){
        click_sound = transform.GetComponent<AudioSource>();
    }

    public void NextPageButton(){
        QuestManager.instance.nextPage();
        AudioManager.instance.playAudio(click_sound.clip);
    }

    public void LastPageButton(){
        QuestManager.instance.lastPage();
        AudioManager.instance.playAudio(click_sound.clip);

    }

    public void ExitButton(){
        QuestManager.instance.HideQuestPanel();
        AudioManager.instance.playAudio(click_sound.clip);

    }

    public void showQuestListPanel(){
        QuestManager.instance.backToQuestListPanel();
    }
}
