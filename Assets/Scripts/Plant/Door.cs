using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject plane;
    public Button buyBtn;

    public int money = 50;

    bool _isOpen = false;
    public bool isOpen { get
        {
            return _isOpen;
        }
        set 
        { 
            _isOpen = value;
            gameObject.SetActive(!value);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            plane.SetActive(true); 
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            plane.SetActive(false); 
        }
    }
}
