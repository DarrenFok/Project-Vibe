using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //text mesh pro

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public bool isDialogue = false;

    public Animator animator; //for animating dialogue box in and out of screen

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        if(isDialogue == false) //only allow them to open new dialogue if no box is open
        {
            isDialogue = true;
            animator.SetBool("IsOpen", true);
            //Debug.Log("Starting conversation with " + dialogue.name);

            nameText.text = dialogue.name;

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0) //no sentences left, then end
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines(); //in case user goes to next sentence faster than finish animating 
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence (string sentence) //for letters to get "typed" onto screen
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null; //wait a frame to add next letter
        }
    }

    void EndDialogue()
    {
        isDialogue = false;
        animator.SetBool("IsOpen", false);
    }
}
