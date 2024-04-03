using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesExit : MonoBehaviour
{

    public string sceneName;
    [SerializeField] private string newScenePW;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Player"){
            // PlayerControllor.instance.canMove = false;
            PlayerControllor.instance.scenePW = newScenePW;
            // SceneManager.LoadScene(sceneName);
            FindObjectOfType<Fader>().FadeTo(sceneName);
        }
    }
}
