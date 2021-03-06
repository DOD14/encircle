﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    [Header("UI")]
    public Text scoreText;
    public Text healthText;
    public Text gameOverText;
    public Button resetButton;

    private int score;
    private int health;

	// Use this for initialization
	void Awake () {

        Time.timeScale = 1f;
        score = 0;
        health = 10;

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
            
        DontDestroyOnLoad(gameObject);
	}

    public void ModifyScore(int deltaScore)
    {
        score += deltaScore;
        scoreText.text = score.ToString();
    }

    public void ModifyHealth(int deltaHealth)
    {
        health += deltaHealth;
        healthText.text = health.ToString();

        if (health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f;
        gameOverText.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(true);
    }

}
