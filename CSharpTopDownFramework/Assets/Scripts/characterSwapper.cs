using UnityEngine;
using UnityEngine.Events;

public class characterSwapper : MonoBehaviour
{
    public UnityEvent<bool> OnEnemyDefeated;

    public GameObject Enemy;
    public GameObject Friend;

    private characterLocator locator;

    private void Awake()
    {
        locator = GetComponent<characterLocator>();
        OnEnemyDefeated.AddListener(HandleEnemyDefeated);
    }

    public void OnHealthZero()
    {
        OnEnemyDefeated?.Invoke(true);
    }

    private void HandleEnemyDefeated(bool isDefeated)
    {
        if (isDefeated)
        {
            SwapCharacter();
        }
    }

    private void SwapCharacter()
    {
        Instantiate(Friend, locator.characterLocation.position, Quaternion.identity);

        Enemy.SetActive(false);
    }

    private void OnDestroy()
    {
        OnEnemyDefeated.RemoveListener(HandleEnemyDefeated);
    }
}
