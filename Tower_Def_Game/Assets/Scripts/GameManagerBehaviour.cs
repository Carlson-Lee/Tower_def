using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour
{
    public Text goldLabel;
    public Text waveLabel;
    public GameObject[] nextWaveLabels;
    public bool gameOver = false;
    private int wave;
    public Text healthLabel;
    public GameObject[] healthIndicator;

    public int Wave
    {
    get { return wave; }
    set
    {
        wave = value;
        if (!gameOver)
        {
        for (int i = 0; i < nextWaveLabels.Length; i++)
        {
            nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
        }
        }
        waveLabel.text = "WAVE: " + (wave + 1);
    }
    }

    private int gold;
    public int Gold {

        get { return gold; }
        set
        {
            gold = value;
            goldLabel.GetComponent<Text>().text = "GOLD: " + gold;
        }
    
    }
    // Start is called before the first frame update
    void Start()
    {
        Wave = 0;
        Gold = 1000;
        Health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int health;
    public int Health
    {
    get { return health; }
    set
    {
        if (value < health)    
        Camera.main.GetComponent<CameraShake>().Shake();
        
        health = value;
        healthLabel.text = "HEALTH: " + health;

        if (health <= 0 && !gameOver)
        {
        gameOver = true;
        GameObject gameOverText = GameObject.FindGameObjectWithTag("GameOver");
        gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
        }

        for (int i = 0; i < healthIndicator.Length; i++)
        {
        if (i < Health)
            healthIndicator[i].SetActive(true);
        else
            healthIndicator[i].SetActive(false);
        }
    }
    }
}
