using UnityEngine;

public class test : MonoBehaviour
{
    private AudioSource playerdamaged;

    void Start()
    {

        playerdamaged = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))  // Replace with any input to trigger the sound
        {
            playerdamaged.Play();
        }
    }
}
