﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Score : MonoBehaviour
{
    private float score = 0.0f;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 10;

    public Text scoreText;

    public DeathMenu deathMenu;

    private bool isDead;

	void Start ()
    {
	}
	
	void Update ()
    {
        if (isDead)
            return;

        if (score >= scoreToNextLevel)
            LevelUp();

        score += Time.deltaTime;
        scoreText.text = ((int) score).ToString() + " sec";
        

    }

    void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;

        scoreToNextLevel *= 2;
        difficultyLevel++;

        Debug.Log(difficultyLevel);
    }

    public void OnDeath()
    {
        isDead = true;
        if (PlayerPrefs.GetFloat("Highscore") < score)
            PlayerPrefs.SetFloat("Highscore", score);
        deathMenu.ToggleEndMenu(score);
    }
}
