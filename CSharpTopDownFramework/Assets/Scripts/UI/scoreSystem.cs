using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class scoreSystem : MonoBehaviour
{
    public int m_score;
    public UnityEvent onEnemyConverted;

    void Update()
    {
        if (m_score == 6.0)
        {
            SceneManager.LoadScene(4);
        }
    }

    private void OnEnable()
    {
        onEnemyConverted.AddListener(UpdateScore);
    }

    private void OnDisable()
    {
        onEnemyConverted.RemoveListener(UpdateScore);
    }

    public void AddScore(int scoreToAdd)
    {
        m_score += scoreToAdd;
    }

    private void UpdateScore()
    {
        AddScore(1);
    }
}