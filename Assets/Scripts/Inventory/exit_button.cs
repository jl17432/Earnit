using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit_button : MonoBehaviour
{
   public void ExitButtonOnClick(){
       UI_manager.instance.Resume();
   }
}
