using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class Soli : MonoBehaviour
{
    [SerializeField] GameObject plane;
    [SerializeField] Button seedBtn;
    [SerializeField] AudioClip seedSE;
    [SerializeField] Button reapBtn;
    [SerializeField] AudioClip reapSE;
    [SerializeField] SpriteRenderer seedSprite;

    [HideInInspector] public int soliIndex = -1;

    //public Seed seed;
    public List<Seed> seeds;

    [HideInInspector] public SoliData data;

    private void Start()
    {
        seedBtn.onClick.AddListener(Seed);
        reapBtn.onClick.AddListener(Reap);

        if (data.state != soliState.None)
        {
            switch (data.state)
            {
                case soliState.None:
                    seedSprite.sprite = null;
                    break;
                case soliState.Wait:
                    if (data.seedTime + data.seed.growTime + data.seed.reapTime <= UI_manager.instance.date)
                    {
                        data.state = soliState.Reap;
                        seedSprite.sprite = data.seed.reap;
                    }
                    else if (data.seedTime + data.seed.growTime <= UI_manager.instance.date) 
                    {
                        data.state = soliState.Grow;
                        seedSprite.sprite = data.seed.grow;
                    }
                    else
                    {
                        seedSprite.sprite = data.seed.wait;
                    }
                    break;
                case soliState.Grow:
                    if (data.seedTime + data.seed.growTime + data.seed.reapTime <= UI_manager.instance.date)
                    {
                        data.state = soliState.Reap;
                        seedSprite.sprite = data.seed.reap;
                    }
                    else
                    {
                        seedSprite.sprite = data.seed.grow;
                    }
                    break;
                case soliState.Reap:
                    seedSprite.sprite = data.seed.reap;
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// </summary>
    void Seed()
    {
        Seed seed = seeds[Random.Range(0, seeds.Count)];
        if (UI_manager.instance.energy >= seed.energy && GameManager.instance.RemoveItem(seed.seedItem))
        {
            AudioManager.instance.PlayUISE(seedSE);
            data.seed = seed;
            data.state = soliState.Wait;
            data.seedTime = UI_manager.instance.date;
            seedSprite.sprite = data.seed.wait;

            UI_manager.instance.energy -= data.seed.energy;

            seedBtn.gameObject.SetActive(false);
        }
        else
        {
            string tip = "";
            if (UI_manager.instance.energy < seed.energy)
            {
                tip += "anenergia!  ";
            }
            if (!GameManager.instance.ContainItem(seed.seedItem))
            {
                tip += "There is no seed!";
            }
            UI_manager.instance.ShowTip(tip);
        }
    }

    /// <summary>
    ///
    /// </summary>
    void Reap()
    {
        AudioManager.instance.PlayUISE(reapSE);

        GameManager.instance.AddItem(data.seed.fruitItem);

        data.state = soliState.None;
        data.seed = null;

        seedSprite.sprite = null;

        reapBtn.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            plane.SetActive(true);

            seedBtn.gameObject.SetActive(false);
            reapBtn.gameObject.SetActive(false);

            switch (data.state)
            {
                case soliState.None:
                    seedBtn.gameObject.SetActive(true);
                    break;
                case soliState.Reap:
                    reapBtn.gameObject.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            plane.SetActive(false);
        }
    }
}

public enum soliState
{
    None, Wait, Grow, Reap 
}

[System.Serializable]
public class SoliData
{
    public int index;
    public soliState state = soliState.None;
    public Seed seed;
    public int seedTime = -1;

    public SoliData(int index)
    {
        this.index = index;
    }
}