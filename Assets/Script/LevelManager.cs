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
    public int lives=0;
    public Text coinText;
    public Text timeText;
    public Text scoreText;
    public Text vidasText;
    public AudioSource soundSource;
    public AudioClip coinSound;
    public AudioClip bumpSound;
    public AudioClip setaUp;
    public AudioClip upLife;
    public AudioClip kickSound;
    public AudioClip stompSound;
    public AudioClip deadMario;
    
    public Vector2 stompBounceVelocity = new Vector2 (0, 1);
    
    private Character mario;
    private Rigidbody2D mario_Rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        AddTime();
        
        mario = FindObjectOfType<Character> ();
        mario_Rigidbody2D = mario.gameObject.GetComponent<Rigidbody2D> ();
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
        if (timeText.text == "0")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    
    
    public void AddCoin() {
        coins++;
        score += 100;
        soundSource.PlayOneShot (coinSound);
        if (coins == 100)
        { 
            AddLife (); 
            coins = 0;
        }

        if (coins >=100)
        {
            coins = 0;
            AddLife();
        }
        
        SetHudCoin ();
        // AddScore (coinBonus);
    }
    
    public void SetHudCoin() {
        coinText.text = "x" + coins.ToString ("D2");
    }
    
    public void AddLife() {
        lives++;
        soundSource.PlayOneShot (upLife);

        vidasText.text = lives.ToString();
    }
    
    public void MarioStompEnemy(Enemy enemy)
    {
        score = score + 1000;
        mario_Rigidbody2D.velocity = new Vector2(mario_Rigidbody2D.velocity.x + stompBounceVelocity.x, stompBounceVelocity.y);
        enemy.StompedByMario ();
        soundSource.PlayOneShot (stompSound);
        //AddScore (enemy.stompBonus, enemy.gameObject.transform.position);
    }
}
