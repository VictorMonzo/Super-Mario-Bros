using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int coins;
    public int score;
    public float time;
    public int lives;
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
        ChangeValues();
        
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

    public void ChangeValues()
    {
        /*coins = GameManager.coins;
        score = GameManager.score;
        lives = GameManager.lives;*/
        
        AddTime();
        SetHubScore();
        SetHudCoin();
        SetHubLives();
    }
    
    public void SetHubScore()
    {
        scoreText.text = GameManager.score.ToString();
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
        GameManager.coins++;
        GameManager.score += 100;
        
        soundSource.PlayOneShot (coinSound);
        
        if (GameManager.coins >= 100)
        {
            GameManager.coins = 0;
            AddLife();
        }
        
        SetHudCoin();
    }
    
    public void SetHudCoin() {
        coinText.text = "x" + GameManager.coins.ToString ("D2");
    }

    public void SetHubLives()
    {
        vidasText.text = GameManager.lives.ToString();
    }
    
    public void AddLife() {
        GameManager.lives++;
        soundSource.PlayOneShot(upLife);

        SetHubLives();
    }
    
    public void MarioStompEnemy(Enemy enemy)
    {
        GameManager.score += 1000;
        mario_Rigidbody2D.velocity = new Vector2(mario_Rigidbody2D.velocity.x + stompBounceVelocity.x, stompBounceVelocity.y);
        enemy.StompedByMario ();
        soundSource.PlayOneShot (stompSound);
    }
}
