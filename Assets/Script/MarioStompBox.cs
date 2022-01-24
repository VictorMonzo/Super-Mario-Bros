using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioStompBox : MonoBehaviour {
	private LevelManager t_LevelManager;

	// Use this for initialization
	void Start () {
		t_LevelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Enemy")) {
			Enemy enemy = other.gameObject.GetComponent<Enemy> ();
			t_LevelManager.MarioStompEnemy (enemy);
		}
	}
}
