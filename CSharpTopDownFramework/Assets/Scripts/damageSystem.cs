using UnityEngine;
using UnityEngine.UI;

public class damageSystem : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100;

    private void Update()
    {
        if (healthAmount <= 0)
        {
            //Application.LoadLevel(Application.loadedLevel);
            Debug.Log("Level would restart here, make a screen for it");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Healing(10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage (float damagePoints)
    {
        healthAmount -= damagePoints;
        healthBar.fillAmount = healthAmount / 100;
        Debug.Log("Damage taken!");
    }

    public void Healing (float healthPoints)
    {
        healthAmount += healthPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100;
        Debug.Log("Healing!");
    }
}
