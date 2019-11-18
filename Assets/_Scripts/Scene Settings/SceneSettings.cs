/*****************************
* CREATED BY: George Zhou   *
* LAST MODIFIED: 11/11/2019 *
*****************************/

//This script contains data for scene setting
using UnityEngine;

[CreateAssetMenu(fileName = "SceneSettings", menuName = "Scene/Settings")]
[System.Serializable]
public class SceneSettings : ScriptableObject
{
    [Header("Scene Configuration")]
    public Scene scene;

    [Header("Player UI")]
    public bool HPBarEnabled;

    [Header("Scoreboard Labels")]
    public bool scoreLabelEnabled;

    [Header("Scene Labels")]
    public bool startLabelActive;
    public bool endLabelActive;

    [Header("MENU UI")] 
    public bool MenuUIActive;

    [Header("GAME UI")]
    public bool GameUIActive;

    [Header("Menu Panels")] 
    public bool buttonPanelEnabled;
    [Header(("Scene Buttons"))]
    public bool restartButtonActive;
    public bool startButtonActive;
    public bool quitButtonActive;
}