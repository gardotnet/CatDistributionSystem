using UnityEngine;

public class scoreUI : MonoBehaviour
{
    public scoreSystem m_scoreSystem;

    public TMPro.TextMeshProUGUI m_ScoreLabel;

    void Update()
    {
        if (m_scoreSystem != null)
        {
            m_ScoreLabel.text = m_scoreSystem.m_score + "/6";
        }
    }

}
