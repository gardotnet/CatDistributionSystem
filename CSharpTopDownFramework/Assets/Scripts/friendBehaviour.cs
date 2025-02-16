using UnityEngine;

public class friendBehaviour : MonoBehaviour
{
    private AudioSource yippeeSFX;

    void Start()
    {
        yippeeSFX    = GetComponent<AudioSource>();
        yippeeSFX.Play();
    }
}
