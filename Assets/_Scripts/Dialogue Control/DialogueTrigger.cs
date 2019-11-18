using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    public DialogueEvent dialogueEvent;
    public bool fireOnce;

    public void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("#####################");
        if (other.gameObject.tag == "Player")
            TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueEvent, this.gameObject);
    }
    
}
