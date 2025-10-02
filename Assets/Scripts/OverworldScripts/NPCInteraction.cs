using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCInteraction : MonoBehaviour
{
    //Elements in scene
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public GameObject interactPrompt;
    public GameObject enterPrompt;
    public GameObject player;

    public string[] lines;
    private int lineNum;

    public bool playerIsNearby { get; private set; }
    public bool inDialogue { get; private set; }

    // Update is called once per frame
    void Update()
    {
        //If NPC is interacted with: sets up UI and first line, freezes player
        if (playerIsNearby && !inDialogue && Input.GetKeyDown(KeyCode.E))
        {
            inDialogue = true;
            lineNum = 0;

            interactPrompt.SetActive(false);
            dialogueBox.SetActive(true);
            enterPrompt.SetActive(true);
            dialogueText.gameObject.SetActive(true);
            dialogueText.text = lines[0];

            SpriteMovement movement = player.GetComponent<SpriteMovement>();
            movement.isFrozen = true;
        }

        //Displays next line of dialogue and end dialogue when all lines read
        if (inDialogue && Input.GetKeyDown(KeyCode.Return))
        {
            ++lineNum;
            if (lineNum == lines.Length)
            {
                dialogueText.gameObject.SetActive(false);
                enterPrompt.SetActive(false);
                dialogueBox.SetActive(false);

                SpriteMovement movement = player.GetComponent<SpriteMovement>();
                movement.isFrozen = false;
                inDialogue = false;
            }
            else
            {
                dialogueText.text = lines[lineNum];
            }
        }
    }

    //Enter NPC hitbox
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNearby = true;
            interactPrompt.SetActive(true);
        }
    }

    //Leave NPC hitbox
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNearby = false;
            interactPrompt.SetActive(false);
        }
    }
}