using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class playerHealth : MonoBehaviour
{
    public Image healthBar;
    private AudioSource playerdamagedsfx;

    [SerializeField] public float healthAmount;
    [SerializeField] public float damageDelay;

    bool enemyContact = false;
    bool canTakeDamage = true;

    void Start()
    {
        playerdamagedsfx = GetComponents<AudioSource>()[1];
    }

    private void Update()
    {
        if (healthAmount <= 0)
        {
            SceneManager.LoadScene(3);
        }

        if (enemyContact && canTakeDamage)
        {
            StartCoroutine(DamageDelay());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyContact = false;
        }
    }

    public void TakeDamage(float damagePoints)
    {
        healthAmount -= damagePoints;
        healthBar.fillAmount = healthAmount / 100;

        if (playerdamagedsfx != null && !playerdamagedsfx.isPlaying)
        {
            playerdamagedsfx.Play();
        }
    }

    //This doesn't get used anywhere, but still nice to have
    public void Healing(float healthPoints)
    {
        healthAmount += healthPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100;
    }

    private IEnumerator DamageDelay()
    {
        canTakeDamage = false;
        TakeDamage(5);
        yield return new WaitForSeconds(damageDelay);
        canTakeDamage = true;
    }
}
