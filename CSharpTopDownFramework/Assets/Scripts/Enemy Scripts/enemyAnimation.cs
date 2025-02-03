using UnityEngine;

public class enemyAnimation : MonoBehaviour
{
    #region Variables

    private Animator m_animator;
    private Vector2 m_enemyDirection;
    private Rigidbody2D m_rigidbody;

    #endregion

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // ~~ handle animator ~~
        // Update the animator speed to ensure that we revert to idle if the player doesn't move.
        m_animator.SetFloat("Speed", m_rigidbody.linearVelocity.magnitude);

        // If there is movement, set the directional values to ensure the character is facing the way they are moving.
        m_enemyDirection = m_rigidbody.linearVelocity.normalized;

        if (m_enemyDirection.magnitude > 0)
        {
            m_animator.SetFloat("Horizontal", m_enemyDirection.x);
            m_animator.SetFloat("Vertical", m_enemyDirection.y);
        }
    }
}
