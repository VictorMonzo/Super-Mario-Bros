using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text textLives;
    public Text textCoins;

    public Texture2D cursor;

    private LevelManager _levelManager;

    // Start is called before the first frame update
    void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        textCoins.text = "x" + _levelManager.coins.ToString("D2");
        textLives.text = _levelManager.lives.ToString("D2");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void startGame()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void StartInfo()
    {
        SceneManager.LoadScene("Info");
    }

    public void OnMouseHover(Button button)
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnMouseHoverExit(Button button)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}