/***********************************
 * CREATED BY: Vincent Tse         *
 * CREATED ON:                     *
 * LAST MODIFIED BY: George Zhou   *
 * LAST MODIFIED: 11/13/2019       *
 ***********************************/

using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [Header("Scene Settings")]
    public SceneSettings activeSceneSettings;
    public List<SceneSettings> sceneSettings;


    [Header("UI Control")] 
    [Header("Menu UI")]
    public GameObject menuUI;

    [Header("Game UI")] 
    public GameObject gameUI;
    public GameObject mainLabel;
    public GameObject buttonPanel;
    public GameObject startButton;
    public GameObject restartButton;
    public GameObject quitButton;

 
    // Start is called before the first frame update
    void Start()
    {
        UIObjectInitialization();
        UIConfiguration();
    }

    private void UIObjectInitialization()
    {
        mainLabel = GameObject.Find("Title Label");
        buttonPanel = GameObject.Find("Button Panel");
        startButton = GameObject.Find("Start Button");
        quitButton = GameObject.Find("Quit Button");
    }

    private void UIConfiguration()
    {
        var query = from settings in sceneSettings
            where settings.scene == (Scene)Enum.Parse(typeof(Scene), SceneManager.GetActiveScene().name.ToUpper())
            select settings;

        activeSceneSettings = query.ToList().First();
        Debug.Log(activeSceneSettings);

        
        buttonPanel.SetActive(activeSceneSettings.buttonPanelEnabled);
        mainLabel.SetActive(activeSceneSettings.startLabelActive);
        startButton.SetActive(activeSceneSettings.startButtonActive);
        //restartButton.SetActive(activeSceneSettings.restartButtonActive);
        quitButton.SetActive(activeSceneSettings.quitButtonActive);
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Level1");
    }

    public void onRestartButtonClick()
    {
        SceneManager.LoadScene("Start");
    }

    public void onQuitButtonClick()
    {
        UnityEditor.EditorApplication.isPlaying = false; //Close the Unity Editor mode
        Application.Quit();
    }
}
