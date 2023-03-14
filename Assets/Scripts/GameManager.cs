using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //singleton part

    private static GameManager _instance = null;

    public void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
    }
    public static GameManager instance()
    {
        return _instance;
    }

    public PlayerPlatformerController player;
    public Canvas gameOverCanvas;
    public Text healthText;

    private HealthSpawner healthSpawner;


    public void Start()
    {
        GameObject go2 = GameObject.FindGameObjectWithTag("Spawner2");
        healthSpawner = go2.GetComponent<HealthSpawner>();
        onRestartClick();
    }
    
    public void onRestartClick()
    {
        //player.Reset();
        healthSpawner.Reset();
        //healthText.text = "x" + player.maxHealth;
        gameOverCanvas.gameObject.SetActive(false);
    }

    public void updateHealth(int value)
    {
        healthText.text = "x" + value;
    }
    public void onMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void gameOverCanvasSwitch(bool status)
    {
        gameOverCanvas.gameObject.SetActive(status);
    }
}
