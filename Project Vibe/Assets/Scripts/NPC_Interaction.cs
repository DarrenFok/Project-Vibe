using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPC_Interaction : MonoBehaviour
{
    public Transform Player;
    public Transform NPC;
    public float InteractionDistance = 5;
    //public UI DialogueUI; was causing compilation errors
    public InputAction interactionControls;
    public Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Player.position, NPC.position) < InteractionDistance)
        {
            if (Input.GetButtonDown("Interact"))
            {
                DialogueTrigger();
            }
        }

    }

    public void DialogueTrigger()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}