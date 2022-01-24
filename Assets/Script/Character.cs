using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public AudioSource sonidoJump;
    public AudioSource sonidoFinal;
    public float Speed = 0.0f;
    private LevelManager levelManager;
    public float lateralMovement = 2.0f;

    public float jumpMovement = 400.0f;

    public Transform groundCheck;

    private Animator animator;

    private Rigidbody2D rigidBody2D;

    public bool grounded = true;
    
    private float tiempoStart;

    private float tiempoEnd=5f;

    private Boolean movimiento = true;
    
    //Botones UI
    private float movementButton=0.0f;
    private Boolean tipoPC = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //sonidoJump = sonidoJump.GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        
        levelManager = FindObjectOfType<LevelManager> ();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, LayerMask.GetMask("Ground"));
        if (movimiento)
        {
            if (tipoPC)
            {
                if (grounded && Input.GetButton("Jump"))
                {
                    rigidBody2D.AddForce(Vector2.up * jumpMovement);
                    sonidoJump.Play();
                }
        
                if (grounded && Input.GetButton("Vertical")) 
                {
                    animator.SetTrigger("Down");
                }

                animator.SetTrigger(grounded ? "Ground" : "Jump");

                Speed = lateralMovement * Input.GetAxis("Horizontal");
                transform.Translate(Vector2.right * Speed * Time.deltaTime);
        
                animator.SetFloat("Speed", Mathf.Abs(Speed));

                if (Speed < 0) transform.localScale = new Vector3(-1, 1, 1);
                else transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                animator.SetTrigger(grounded ? "Ground" : "Jump");
                Speed = lateralMovement * movementButton;
                transform.Translate(Vector2.right * Speed * Time.deltaTime);
        
                animator.SetFloat("Speed", Mathf.Abs(Speed));

                if (Speed < 0) transform.localScale = new Vector3(-1, 1, 1);
                else transform.localScale = new Vector3(1, 1, 1);
            }
        }
        
       

        //Verificar si cae

        if (transform.position.y < -1f)
        {
            levelManager.soundSource.PlayOneShot(levelManager.deadMario);
            levelManager.lives--;
            Invoke("comprobarMuerte", 5f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zoom"))
        {
            GameObject.Find("MainVirtual").GetComponent<CinemachineVirtualCamera>().enabled = false;
        }
        
        if (other.gameObject.CompareTag("FinalBandera"))
        {
            movimiento = false;
            animator.Play("idle");
            sonidoFinal.Play();
            Invoke("changeScene",5f);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Zoom"))
        {
            GameObject.Find("MainVirtual").GetComponent<CinemachineVirtualCamera>().enabled = true;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MobilePlatform"))
        {
            transform.SetParent(other.transform);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            levelManager.soundSource.PlayOneShot(levelManager.deadMario);
            levelManager.lives--;
           comprobarMuerte();
          
            
        }
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MobilePlatform"))
        {
            transform.SetParent(null);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy> ();

            // TODO Comprobar donde le golpea y matar al Enemy
        }
    }

    private void changeScene()
    {
        SceneManager.LoadScene("Nivel2");
    }

    private void comprobarMuerte()
    {
        SceneManager.LoadScene(levelManager.lives < 0 ? "MainMenu" : "GameOver");

    }
    
    //Funciones botones UI

    public void Jump()
    {
        if (grounded)
        {
           rigidBody2D.AddForce(Vector2.up * 200.0f);
            sonidoJump.Play();
        }
    }

    public void Move(float amount)
    {
        movementButton = amount;
    }
}
