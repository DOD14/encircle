using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    private int score;
    private int health;

	// Use this for initialization
	void Awake () {

        score = 0;
        health = 100;

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
            
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ModifyScoreAndHealth(int deltaScore, int deltaHealth)
    {
        score += deltaScore;
        health += deltaHealth;
    }

}
