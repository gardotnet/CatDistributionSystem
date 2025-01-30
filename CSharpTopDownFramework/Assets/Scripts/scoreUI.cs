using UnityEngine;

public class scoreUI : MonoBehaviour
{
    public scoreSystem m_scoreSystem;

    public TMPro.TextMeshProUGUI m_ScoreLabel;

    void Update()
    {
        m_ScoreLabel.text = "Score: " + m_scoreSystem.m_score;
    }
}
