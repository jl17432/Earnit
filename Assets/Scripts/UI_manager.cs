using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{

    public static UI_manager instance { get; private set; }

    public Text budgetText;
    public int budget;
    // public Text savingText;

    public Text dateText;
    public int date;
    private string[] weekDays = new string[] { "周一", "周二", "周三", "周四", "周五", "周六", "周日" };

    public Image energyBar;
    public int energy;


    public GameObject inventoryMenu;

    void Awake(){
        if (instance == null){
            instance = this;
            budget = 250;
            date = 1;
            energy = 100;
            updateBudgetText(budget);
            updateDate();
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        inventoryMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        InventoryControl();
        updateEnergy();
        updateBudgetText(budget);
    }

    public void nextDay(){
        FindObjectOfType<Fader>().Start();
        date += 1;
        updateDate();
    }

    public void updateBudgetText(int amount){
        budgetText.text = amount.ToString();
    }

    public void updateDate(){
        int dayName = date % 7;
        if (dayName == 0) {
            dateText.text = weekDays[6] + ", 第" + date.ToString() + "天";
        }
        else{
            dateText.text = weekDays[dayName - 1] + ", 第" + date.ToString() + "天";
        }

        //精力回复
        energy = 100;
    }

    public void updateEnergy(){
        energyBar.fillAmount = (float) energy / 100f;
    }

    // public void updateSavingText(int amount){
    //     savingText.text = amount.ToString();
    // }

    private void InventoryControl(){
        if (Input.GetKeyDown(KeyCode.B)){
            if (GameManager.instance.isPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }


    public void Resume(){
        inventoryMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        GameManager.instance.isPaused = false;
    }

    public void Pause(){
        inventoryMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
        GameManager.instance.isPaused = true;
    }

    [SerializeField] Text tipText;
    Coroutine _lastCoroutine;
    /// <summary>
    /// 显示提示
    /// </summary>
    /// <param name="tip"></param>
    public void ShowTip(string tip) 
    {
        tipText.text = tip;

        if (_lastCoroutine != null)
        {
            StopCoroutine(_lastCoroutine);
        }

        _lastCoroutine =  StartCoroutine(HideTip());
    }

    IEnumerator HideTip()
    {
        yield return new WaitForSeconds(2f);
        tipText.text = "";
    }
}
