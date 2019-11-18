using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [CanBeNull] public GameObject portal;
    public GameObject player;
    public GameObject cm;
    public bool sceneChange;
    public bool sceneChange2;



    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.T))
        {
            if (sceneChange)
            {
                SceneManager.LoadScene("Level2");
            }
            if (sceneChange2)
            {
                SceneManager.LoadScene("Level3");
            }
                // StartCoroutine(Teleport());
                Teleport();
        }
    }




    public void Teleport()
    {
        cm.GetComponent<CinemachineVirtualCamera>().Follow = null;
        cm.GetComponent<CinemachineVirtualCamera>().LookAt = null;
        player.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
        StartCoroutine(UpdateCameraFrameLater());
        GetComponent<Spwaner>().SetActive(true);

    }


    //IEnumerator Teleport()
    //{
    //    cm.GetComponent<CinemachineVirtualCamera>().Follow = null;
    //    cm.GetComponent<CinemachineVirtualCamera>().LookAt = null;
    //    // Camera.main.GetComponent<CinemachineBrain>();
    //    yield return new WaitForSeconds(0.5f);
    //    player.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
    //    // yield return new WaitForSeconds(2f);
    //    // Camera.main.GetComponent<CinemachineBrain>().enabled = true;
    //}


    IEnumerator UpdateCameraFrameLater()
    {
        yield return null;

        cm.GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
        cm.GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
    }
}
