using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class allyBehaviour : MonoBehaviour
{
    bool playerContact = false;
    public UnityEvent onPlayerInteraction;

    private DialogueSystem dialogueSystem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerContact == true)
            {
                TriggerConversation();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerContact = false;
        }
    }

    void TriggerConversation()
    {
        onPlayerInteraction.Invoke();
    }
}