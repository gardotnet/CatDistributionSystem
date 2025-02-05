using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class playerHealth : MonoBehaviour
{
    public Image healthBar;

    [SerializeField] public float healthAmount;
    [SerializeField] public float damageDelay;

    bool enemyContact = false;
    bool canTakeDamage = true;

    private void Update()
    {
        if (healthAmount <= 0)
        {
            SceneManager.LoadScene(1);
            Debug.Log("Level would restart here, make a screen for it");
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
    }

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
