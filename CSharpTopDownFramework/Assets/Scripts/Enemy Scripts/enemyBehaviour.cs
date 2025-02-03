using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    #region Variables

    public Transform m_Player;
    public float m_speed;
    public float m_stoppingDistance;
    bool m_PlayerInSight = false;

    #endregion

    void Start()
    {
        m_Player = FindAnyObjectByType<playerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_PlayerInSight && Vector2.Distance(transform.position, m_Player.position) >= m_stoppingDistance)
        {
            //transform.position = Vector2.MoveTowards(transform.position, m_Player.position, m_speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().linearVelocity = (m_Player.position - transform.position) * (m_speed * Time.deltaTime);
        }
        else
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        }

    }

    private void OnTriggerEnter2D (Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            m_PlayerInSight = true;
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_PlayerInSight = false;
        }
    }
}
