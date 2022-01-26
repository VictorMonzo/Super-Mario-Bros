using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Texture2D cursor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart()
    {
        switch (GameManager.level)
        {
            case 1:
                SceneManager.LoadScene("Nivel1");
                break;
            case 2:
                SceneManager.LoadScene("Nivel2");
                break;
            default:
                SceneManager.LoadScene("MainMenu");
                break;
        }
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
