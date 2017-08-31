using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class HighScorePanel : MonoBehaviour
{
    public GameObject mainMenuPanel;

    public List<int> highScores;
    public List<string> names;

    public Text ScoreText, NameText;
    public Text InputText;
    public GameObject SubmitButton, HighScoreDisplay;
    public string newName;

    private string scoreStr, nameStr;
    private Options options;
    private int newScore;
    private string fileScores, fileNames;
    private int newIndex;

    public void Awake()
    {
        options = Options.Instance();
    }

    public void Start()
    {
        HighScoreDisplay.gameObject.SetActive(false);
    }

    public void ApplyName()
    {
        SubmitButton.gameObject.SetActive(false);
        HighScoreDisplay.gameObject.SetActive(true);

        newIndex = -1;
        scoreStr = "";
        nameStr = "";

        newScore = options.playerScore;

        setName();

        names = new List<string>();
        highScores = new List<int>();

        ReadString();
        PopulateScores();
        DisplayScores();
    }

    public void PopulateScores()
    {
        //newName = "You";
        string[] namesArr = fileNames.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        string[] scoresArr = fileScores.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        
        bool isAdded = false;
        bool nameAppended = false;

        //print("Scores Length: " + scoresArr.Length);
        for(int i = 0; i < scoresArr.Length; i++)
        {
            if(!isAdded && newScore > int.Parse(scoresArr[i]))
            {
                highScores.Add(newScore);
                newIndex = i;
                isAdded = true;
                //print("Added: " + scoresArr[i]);
            }
            highScores.Add(int.Parse(scoresArr[i]));
            //print("Added: " + scoresArr[i]);
        }
        if (!isAdded && highScores.Count < 10)
        {
            highScores.Add(newScore);
            nameAppended = true;
        }

        isAdded = false;
        for (int e = 0; e < namesArr.Length; e++)
        {
            if (!isAdded && e == newIndex)
            {
                isAdded = true;
                names.Add(newName);
            }
                
            names.Add(namesArr[e]);
        }
        if (nameAppended)
            names.Add(newName);

    }

    public void DisplayScores()
    {
        nameStr = "";
        scoreStr = "";

        for(int i = 0; i < highScores.Count; i++)
        {
            scoreStr += highScores[i].ToString() + "\r\n";
            if(i < names.Count)
                nameStr += names[i].ToString() + "\r\n";
        }
        ScoreText.text = scoreStr.ToString();
        NameText.text = nameStr.ToString();
    }

    public void refreshList()
    {
        names[newIndex] = newName;
        DisplayScores();
    }

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Quit()
    {
        newName = NameText.text.ToString();
        if (newIndex >= 0)
            refreshList();
        WriteString(); // Writes nameStr and scoreStr to files.
        Application.Quit();
    }

     void WriteString()
    {
        string pathNames = "Assets/Resources/HighScore_Names.txt";
        string pathScores = "Assets/Resources/HighScore_Scores.txt";

        //Write some text to the test.txt file
        StreamWriter nameWriter = new StreamWriter(pathNames, false);
        StreamWriter scoreWriter = new StreamWriter(pathScores, false);

        nameWriter.Write(nameStr);
        scoreWriter.Write(scoreStr);

        nameWriter.Close();
        scoreWriter.Close();
    }

    void ReadString()
    {
        string pathNames = "Assets/Resources/HighScore_Names.txt";
        string pathScores = "Assets/Resources/HighScore_Scores.txt";

        //Read the text from directly from the test.txt file
        StreamReader nameReader = new StreamReader(pathNames);
        StreamReader scoreReader = new StreamReader(pathScores);
        fileNames = nameReader.ReadToEnd();
        fileScores = scoreReader.ReadToEnd();

        nameReader.Close();
        scoreReader.Close();
    }

    public void setName()
    {
        newName = InputText.text.ToString();
        if (newName == "" || newName == " ")
            newName = "Player 1";
        //PopulateScores();
       // DisplayScores();
    }

    void OnDisable()
    {
        
    }
}
