using UnityEngine;

public class MusicDontDestroy : MonoBehaviour
{
    static bool musicPlaying = false;

    void Awake()
    {
        if (musicPlaying)
        {
            Destroy(gameObject);
        }
        else
        {
            musicPlaying = true;
            DontDestroyOnLoad(gameObject);
        }
    }
}