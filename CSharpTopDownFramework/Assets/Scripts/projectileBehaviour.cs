using UnityEngine;

public class projectileBehaviour : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject Enemy;
    private AudioSource swoop;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Enemy Vision"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyBehaviour enemyComponent = collision.transform.GetComponentInParent<enemyBehaviour>();

            if (enemyComponent != null)
            {
                enemyComponent.TakeDamage(1);
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        GameObject projectileOrigin = GameObject.FindWithTag("Player");
        Collider2D projectileoriginCollider = projectileOrigin.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), projectileoriginCollider);
;
        swoop = GetComponent<AudioSource>();
        swoop.Play();

        Destroy(gameObject, 1.0f);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        Destroy(gameObject, 0.3f);
    }
}
