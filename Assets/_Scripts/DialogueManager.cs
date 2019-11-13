using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private GameObject caller;
    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    // private bool isTalking;
    public PlayerMovement player;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {
        if (player.isTalking && Input.anyKeyDown)
            DisplayNextSentence();
    }

    public void StartDialogue(Dialogue dialogue, GameObject caller)
    {
        sentences.Clear();
        this.caller = caller;

        animator.SetBool("isOpen", true);
        player.isTalking = true;

        nameText.text = dialogue.name;

        foreach (string sentence in dialogue.sentences)
            sentences.Enqueue(sentence);

        DisplayNextSentence();
        Debug.Log("starting Dialogue");
        
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
        StartCoroutine(TypeSentence(sentences.Dequeue()));
    }


    IEnumerator TypeSentence(string sentence)
    {
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
        animator.SetBool("isOpen", false);
        if (caller && caller.tag == "Tutorial") {
            caller.GetComponent<Spwaner>().SetActive(true);
            Destroy(caller);
        }


    }





}
