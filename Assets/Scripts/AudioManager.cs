using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance {get; private set;}

    [SerializeField] AudioSource _UISE;//ui音效

    private AudioSource audios;

    // Start is called before the first frame update
    void Awake(){
        if (instance == null){
            instance = this;
            audios = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAudio(AudioClip sound){
        audios.PlayOneShot(sound);
    }

    public void PlayUISE(AudioClip sound)
    {
        _UISE.PlayOneShot(sound);
    }

    // public void play(AudioClip sound){

    // }
}
