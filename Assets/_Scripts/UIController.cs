using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameController gameController;

    // public GameObject startLabel;
    public GameObject startButton;
    public GameObject restartButton;
    //public GameObject endLabel;


    // Start is called before the first frame update
    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Start":
                // gameController.defaultSoundClip = SoundClip.BACKGOUND;
                //gameController.livesLabel.enabled = false;
                //gameController.scoreLabel.enabled = false;
                restartButton.SetActive(false);
                // endLabel.SetActive(false);
                Debug.Log("Start Scene Loaded");
                break;
            case "Main":
                // gameController.defaultSoundClip = SoundClip.BACKGOUND;
                // startLabel.SetActive(false);
                startButton.SetActive(false);
                restartButton.SetActive(false);
                // endLabel.SetActive(false);
                Debug.Log("Main Scene Loaded");
                break;
            case "End":
                // gameController.defaultSoundClip = SoundClip.BACKGOUND;
                //gameController.livesLabel.enabled = false;
                //gameController.scoreLabel.enabled = false;
                //startLabel.SetActive(false);
                startButton.SetActive(false);
                Debug.Log("End Scene Loaded");
                break;
        }
    }


    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Main");
    }

    public void onRestartButtonClick()
    {
        SceneManager.LoadScene("Main");
    }
}
