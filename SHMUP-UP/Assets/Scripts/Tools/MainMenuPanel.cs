﻿using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : MonoBehaviour {
    public GameObject mainMenuPanel;
    public GameObject optionPanel;
    public Text difficultyText;

    public Image diff2, diff3;

    private int difficulty;
    private string[] diffArray;

    private Options options;

    public void Awake()
    {
        options = Options.Instance();
    }

    public void Start()
    {
        diff2.gameObject.SetActive(false);
        diff3.gameObject.SetActive(false);
        //options.difficulty = 0;
        diffArray = new string[] { "Beginner", "Advanced", "Ungodly" };
        difficulty = 0;

        optionPanel.gameObject.SetActive(false);
    }

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ReturnToTitle()
    {
        mainMenuPanel.gameObject.SetActive(true);
        optionPanel.gameObject.SetActive(false);
    }

    public void ToOptions()
    {
        mainMenuPanel.gameObject.SetActive(false);
        optionPanel.gameObject.SetActive(true);
    }

    public void CycleDifficulty()
    {
        difficulty++;
        if (difficulty >= diffArray.Length)
            difficulty = 0;

        if(difficulty == 0)
        {
            diff2.gameObject.SetActive(false);
            diff3.gameObject.SetActive(false);
        }
        else if(difficulty == 1)
        {
            diff2.gameObject.SetActive(true);
            diff3.gameObject.SetActive(false);
        }
        else if(difficulty == 2)
        {
            diff2.gameObject.SetActive(true);
            diff3.gameObject.SetActive(true);
        }

        //options.difficulty = difficulty;
        difficultyText.text = diffArray[difficulty];

        options.difficulty = difficulty;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
