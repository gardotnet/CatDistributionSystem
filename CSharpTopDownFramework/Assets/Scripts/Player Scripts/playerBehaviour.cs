using UnityEngine;
using UnityEngine.InputSystem;

public class playerBehaviour : MonoBehaviour
{
    private InputAction m_moveAction;
    private InputAction m_attackAction;

    bool allyContact = false;

    #region Projectile Variables

    [Header("Projectile parameters")]
    [SerializeField] GameObject m_projectilePrefab;
    [SerializeField] Transform m_firepoint;
    [SerializeField] float m_projectileSpeed;
    [SerializeField] float m_fireRate;

    private float m_fireTimeout = 0;

    private Vector2 m_playerDirection;
    private Vector2 m_lastDirection;

    #endregion

    private void Awake()
    {
        //bind movement inputs to variables
        m_moveAction = InputSystem.actions.FindAction("Move");
        m_attackAction = InputSystem.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        if (m_attackAction.IsPressed() && Time.time > m_fireTimeout)
        {
            m_fireTimeout = Time.time + m_fireRate;
            Fire();
        }

        m_lastDirection = m_playerDirection;
    }

    void Fire()
    {
        // Get the mouse position on the screen and convert it to world position
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate direction from player to mouse position
        Vector2 fireDirection = (mousePosition - (Vector2)m_firepoint.position).normalized;

        // Instantiate the projectile at the firepoint's position with no rotation
        GameObject projectileToSpawn = Instantiate(m_projectilePrefab, m_firepoint.position, Quaternion.identity);

        // Set the velocity of the projectile to shoot in the calculated direction
        if (projectileToSpawn.GetComponent<Rigidbody2D>() != null)
        {
            projectileToSpawn.GetComponent<Rigidbody2D>().linearVelocity = fireDirection * m_projectileSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ally"))
        {
            allyContact = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ally"))
        {
            allyContact = false;
        }
    }
}
