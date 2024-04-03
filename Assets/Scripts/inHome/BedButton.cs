using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedButton : MonoBehaviour
{
    public void clickYES(){
        FindObjectOfType<bed>().sleep();
    }

    public void clickNO(){
        FindObjectOfType<bed>().hidePanel();
    }
}
