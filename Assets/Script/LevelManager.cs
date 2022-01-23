using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int coins;
    public Text coinText;
    public AudioSource soundSource;
    public AudioClip coinSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AddCoin() {
        coins++;
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
