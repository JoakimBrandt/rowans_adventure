using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameHandler gameHandler = FindObjectOfType<GameHandler>();

        if (gameObject.CompareTag("EndGame") && collision.CompareTag("Player") && collision is CircleCollider2D && gameHandler.doesPlayerHaveParchment())
        {
            TriggerDialogue();
            gameHandler.LoadNextLevel();
        }
        else
        {
            TriggerDialogue();
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
