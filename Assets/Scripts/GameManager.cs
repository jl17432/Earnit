using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isPaused;

    public List<Item> items = new List<Item>();
    public List<int>  itemAmount = new List<int>();

    public GameObject[] slots;

    public Item testAddItem;
    public Item testRemoveItem;

    private void Awake(){
        if (instance == null){
            instance = this;
        }
        else {
            if (instance != this){
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start(){
        DisplayItems();
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.K)){
            AddItem(testAddItem);
        }
        if (Input.GetKeyDown(KeyCode.L)){
            RemoveItem(testRemoveItem);
        }
    }

    private void DisplayItems(){
        
        //============back up area===================
        // for (int i = 0; i < items.Count; i++){
        //     slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,1);
        //     slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

        //     slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1,1,1,1);
        //     slots[i].transform.GetChild(1).GetComponent<Text>().text = itemAmount[i].ToString();
            
        //     slots[i].transform.GetChild(2).gameObject.SetActive(true);
        // }
        //============back up area===================


        for(int i = 0; i < slots.Length; i++){
            if (i < items.Count){
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1,1,1,1);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = itemAmount[i].ToString();
            
                slots[i].transform.GetChild(2).gameObject.SetActive(true);
            }

            else{
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,0);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;

                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1,1,1,0);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = null;
            
                slots[i].transform.GetChild(2).gameObject.SetActive(false);                
            }
        }

    }

    public void AddItem(Item _item){

        //新物品，直接在物品清单追加然后数量list里面设置数量为1
        if (!items.Contains(_item)){
            items.Add(_item);
            itemAmount.Add(1);
        }

        //已经拥有同类物品，直接寻找该物品在list的位置，数量+1
        else{
            for (int i = 0; i < items.Count; i++){
                if (_item == items[i]){
                    itemAmount[i]++;
                }
            }
        }

        DisplayItems();
    }

    public bool RemoveItem(Item _item){
        //已经拥有同类物品， 直接寻找该物品位置，数量-1
        // 注意！ 如果数量为0， 需要删除该slot里的和该物品相关的内容

        bool result = items.Contains(_item);

        if (items.Contains(_item)){
            for (int i = 0; i < items.Count; i++){
                if (_item == items[i]){
                    itemAmount[i]--;
                    if (itemAmount[i] == 0){
                        items.Remove(_item);
                        itemAmount.Remove(itemAmount[i]);
                    }
                }
            }
        }
        else{
            Debug.Log("trying to remove a item which the play do not have!!!!");
        }

        DisplayItems();

        return result;
    }

    public bool ContainItem(Item _item)
    {
        return items.Contains(_item);
    }
}
