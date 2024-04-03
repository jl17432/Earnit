using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remove_button : MonoBehaviour
{
   public int buttonID;
   private Item currentItem;

   private Item GetCurrentItem(){
       for (int i = 0; i < GameManager.instance.items.Count; i++){
           if (buttonID == i){
               currentItem = GameManager.instance.items[i];
           }
       }
       return currentItem;
   }
   
   
   public void RemoveButtonOnClick(){
       GameManager.instance.RemoveItem(GetCurrentItem());
   }
}
