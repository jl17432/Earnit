using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntrance : MonoBehaviour
{

    public string entrancePW;

    // private AudioClip audio;
    private AudioSource exit_audio;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerControllor.instance.scenePW == entrancePW){
            PlayerControllor.instance.transform.position = transform.position;
            exit_audio = transform.GetComponent<AudioSource>();
            AudioManager.instance.playAudio(exit_audio.clip);
        }
        // else{
        //     Debug.Log("wrong PW!");
        // }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
