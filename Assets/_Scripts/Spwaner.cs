using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwaner : MonoBehaviour
{

    public GameObject[] objs;

    public void SetActive(bool active)
    {
        for (int i = 0; i < objs.Length; i++)
        {
            Debug.Log("setting: " + objs[i]);
            objs[i].SetActive(active);
        }
    }
}
