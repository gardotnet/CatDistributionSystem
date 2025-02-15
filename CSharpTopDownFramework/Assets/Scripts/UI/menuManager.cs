using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    [SerializeField] private GameObject m_panelControls;
    [SerializeField] private GameObject m_panelMenu;
    private bool m_controlsPanelOpen = false;
    
    public void ToggleControlsPanel()
    {
        if (m_controlsPanelOpen)
        {
            m_panelMenu.SetActive(true);
            m_panelControls.SetActive(false);
        } else {
            m_panelMenu.SetActive(false);
            m_panelControls.SetActive(true);
        }
        m_controlsPanelOpen = !m_controlsPanelOpen;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
