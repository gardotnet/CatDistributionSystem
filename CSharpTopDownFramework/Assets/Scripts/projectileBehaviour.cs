using UnityEngine;

public class projectileBehaviour : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject Enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Enemy Vision"))
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        GameObject projectileOrigin = GameObject.FindWithTag("Player");
        Collider2D projectileoriginCollider = projectileOrigin.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), projectileoriginCollider);

        Destroy(gameObject, 1.0f);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 0.6f);
    }
}
