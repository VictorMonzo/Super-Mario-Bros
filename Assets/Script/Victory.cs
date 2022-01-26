using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public Texture2D cursor;
    public Text lifes;

    private LevelManager _levelManager;
    // Start is called before the first frame update
    void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        lifes.text = "Score: " + GameManager.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartMain()
    {
        SceneManager.LoadScene("MainMenu");
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
