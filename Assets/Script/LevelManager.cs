using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int coins;
    public int score=0;
    public float time;
    public Text coinText;
    public Text timeText;
    public Text scoreText;
    public AudioSource soundSource;
    public AudioClip coinSound;

    // Start is called before the first frame update
    void Start()
    {
        AddTime();
    }

    // Update is called once per frame
    void Update()
    {
        time-=Time.deltaTime;
        SetHubTime();
        SetHubScore();
    }

    public void SetHubScore()
    {
        scoreText.text = score.ToString();
    }
    
    public void AddTime()
    {
        time = 300;
        SetHubTime();
    }

    public void SetHubTime()
    {
        timeText.text = time.ToString("F0");
        if (timeText.text =="0")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    
    
    public void AddCoin() {
        coins++;
        score += 100;
        soundSource.PlayOneShot (coinSound);
        // if (coins == 100) {
        //     AddLife ();
        //     coins = 0;
        // }
        SetHudCoin ();
        // AddScore (coinBonus);
    }
    
    public void SetHudCoin() {
        coinText.text = "x" + coins.ToString ("D2");
    }
    
}
