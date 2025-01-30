using UnityEngine;

public class projectileBehaviour : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject Enemy;
    private GameObject projectileInstance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("it is 1am if its this im gonna cry");
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectileInstance.tag = "Hairball";

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
        Destroy(gameObject, 0.4f);
    }
}
