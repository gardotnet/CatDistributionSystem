using UnityEngine;
using System.Collections;
using TMPro;

public class TypingText : MonoBehaviour
{
    [Header ("Components")]
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index = 0;
    private bool isTyping = false; // -> This will throw a 'is assigned but its value is never used' warning, despite being used (?)

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        yield return new WaitForSeconds(1);

        foreach (char letter in lines[index].ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text += string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}