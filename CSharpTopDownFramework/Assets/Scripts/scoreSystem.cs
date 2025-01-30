using UnityEngine;

public class scoreSystem : MonoBehaviour
{
    public int m_score;

    public void AddScore(int scoreToAdd)
    {
        m_score += scoreToAdd;
    }
}
