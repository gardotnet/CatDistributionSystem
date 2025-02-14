using UnityEngine;
using UnityEngine.Events;

public class allyBehaviour : MonoBehaviour
{
    bool playerContact = false;
    public UnityEvent onPlayerInteraction;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) TriggerConversation();

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

    }
}
