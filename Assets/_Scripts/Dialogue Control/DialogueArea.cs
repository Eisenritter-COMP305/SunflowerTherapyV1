using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueArea : MonoBehaviour
{

    public GameObject dialogueTrigger;


    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            if (!other.GetComponent<PlayerMovement>().isTalking)
            {
                Destroy(dialogueTrigger);
            }
        }
    }
}
