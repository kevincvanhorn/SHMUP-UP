using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class HighScorePanel : MonoBehaviour
{
    public GameObject mainMenuPanel;

    private Options options;

    public void Awake()
    {
        options = Options.Instance();
    }

    public void Start()
    {

    }

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
