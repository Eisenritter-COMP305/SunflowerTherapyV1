/***********************************
 * CREATED BY: Vincent Tse         *
 * CREATED ON:                     *
 * LAST MODIFIED BY: George Zhou   *
 * LAST MODIFIED: 11/13/2019       *
 ***********************************/
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> names;
    private Queue<string> sentences;
    private GameObject caller;

    
    public Animator animator;

    public TextMeshProUGUI ActorName;
    public Image portrait;
    public TextMeshProUGUI dialogueText;

    // public Animator animator;
    // private bool isTalking;
    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        names = new Queue<string>();
        sentences = new Queue<string>();

    }

    void Update()
    {
        if (player.isTalking && Input.anyKeyDown)
            DisplayNextSentence();
    }

    public void StartDialogue(DialogueEvent dialogueEvent, GameObject caller)
    {
        sentences.Clear();
        this.caller = caller;

        animator.SetBool("isOpen", true);
        player.isTalking = true;

        
        //foreach (Dialogue dialogue in dialogueEvent)
        //    sentences.Enqueue(sentence);
        foreach (Dialogue d in dialogueEvent.dialogues)
        {
            names.Enqueue(d.actor.name);
            sentences.Enqueue(d.sentences);
        }
        DisplayNextSentence();
        //Debug.Log("starting Dialogue");
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        // dialogueText.text = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence( names.Dequeue(),sentences.Dequeue()));
    }

    IEnumerator TypeSentence(string name, string sentence)
    {
        ActorName.text = name;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        Debug.Log("Closeing Dialogue");
        player.isTalking = false;
        ResetDialogue();
        animator.SetBool("isOpen", false);
        if (caller && caller.tag == "Tutorial")
        {
            caller.GetComponent<Spwaner>().SetActive(true);
            Destroy(caller);
        }
        Debug.Log(caller.GetComponent<DialogueTrigger>().fireOnce);
        if (caller.GetComponent<DialogueTrigger>().fireOnce)
        { 
            Destroy(caller.GetComponent<DialogueTrigger>());
        }

        Time.timeScale = 1;
    }

    public void ResetDialogue()
    {
        ActorName.text = "";
        dialogueText.text = "";
    }

}
