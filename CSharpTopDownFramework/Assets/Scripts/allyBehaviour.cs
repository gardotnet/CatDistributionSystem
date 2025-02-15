using UnityEngine;
using UnityEngine.Events;

public class allyBehaviour : MonoBehaviour
{
    bool playerContact = false;
    public UnityEvent onPlayerInteraction;

    private DialogueSystem dialogueSystem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerContact)
        {
            TriggerConversation();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerContact = true;
        }
    }

    void TriggerConversation()
    {
        onPlayerInteraction.Invoke();
    }
}
