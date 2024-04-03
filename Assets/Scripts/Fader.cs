using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{

    public Image fading_image;
    [SerializeField] private float alpha;

    public void Start(){
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string _sceneName){
        StartCoroutine(FadeOut(_sceneName));
    }

   
    IEnumerator FadeIn(){
        alpha = 1;

        while (alpha > 0){
            alpha -= Time.deltaTime;
            fading_image.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(0);
        }
        alpha = 0;
    }

    IEnumerator FadeOut(string sceneName){

        alpha = 0;
        while (alpha < 1){
            alpha += Time.deltaTime;
            fading_image.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(0);
        }
        alpha = 1;

        SceneManager.LoadScene(sceneName);
        
        // while (alpha > 0){
        //     alpha -= Time.deltaTime;
        //     fading_image.color = new Color(0, 0, 0, alpha);
        //     yield return new WaitForSeconds(0);
        // }

    }
}
