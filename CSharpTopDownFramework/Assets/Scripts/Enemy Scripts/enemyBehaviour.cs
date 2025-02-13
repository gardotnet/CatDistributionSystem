using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class enemyBehaviour : MonoBehaviour
{
    #region Variables

    public Transform m_Player;
    public float m_speed;
    public float m_stoppingDistance;
    bool m_PlayerInSight = false;

    [Header("Health")]
    [SerializeField] enemyHealthBar healthBar;
    [SerializeField] float health, maxHealth = 3f;

    [Header("Friend Variations")]
    [SerializeField] GameObject CalicoFriend;
    //[SerializeField] GameObject GingerFriend;
    //[SerializeField] GameObject BombayFriend;
    //public string[] Variations; -> figure out how to list and use the different variations (listed above) interchangeably

    public UnityEvent<GameObject> OnEnemyDeath;
    public Transform enemyLocation;

    #endregion

    private void Awake()
    {
        healthBar = GetComponentInChildren<enemyHealthBar>();

        OnEnemyDeath.AddListener(HandleEnemyDefeated);
    }

    private void Start()
    {
        health = maxHealth;

        m_Player = FindAnyObjectByType<playerMovement>().transform;
    }

    void Update()
    {

        #region Enemy Vision Code 
        if (m_PlayerInSight && Vector2.Distance(transform.position, m_Player.position) >= m_stoppingDistance)
        {
            GetComponent<Rigidbody2D>().linearVelocity = (m_Player.position - transform.position) * (m_speed * Time.deltaTime);
        }
        else
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_PlayerInSight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_PlayerInSight = false;
        }
    }

    #endregion

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.UpdateHealthBar(health, maxHealth);

        if (health <= 0)
        {
            HandleEnemyDefeated(CalicoFriend);
        }
    }

    private void HandleEnemyDefeated(GameObject friend)
    {
        Instantiate(friend, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
