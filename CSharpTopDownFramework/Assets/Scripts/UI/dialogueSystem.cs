using UnityEngine;
using System.Collections;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueBox;
    public GameObject dialogueLines;
    public GameObject dialoguePortrait;
    public TextMeshProUGUI textComponent;
    public float textSpeed;

    public string[] lines;

    private int index = 0;
    private bool isTyping = false;

    void Start()
    {
        dialogueBox.GetComponent<CanvasRenderer>().SetAlpha(0f);
        dialogueLines.GetComponent<CanvasRenderer>().SetAlpha(0f);
        dialoguePortrait.GetComponent<CanvasRenderer>().SetAlpha(0f);
        textComponent.text = string.Empty;
    }

    public void HandleDialogue()
    {
        if (dialogueBox.GetComponent<CanvasRenderer>().GetAlpha() == 0f)
        {
            dialogueBox.GetComponent<CanvasRenderer>().SetAlpha(1f);
            dialogueLines.GetComponent<CanvasRenderer>().SetAlpha(1f);
            dialoguePortrait.GetComponent<CanvasRenderer>().SetAlpha(1f);
            StartCoroutine(TypeLine());
        }
        else if (!isTyping)
        {
            if (index < lines.Length - 1)
            {
                index++;
                StartCoroutine(TypeLine());
            }
            else
            {
                CloseDialogue();
            }
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        textComponent.text = string.Empty;

        foreach (char letter in lines[index].ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    void CloseDialogue()
    {
        dialogueBox.GetComponent<CanvasRenderer>().SetAlpha(0f);
        dialogueLines.GetComponent<CanvasRenderer>().SetAlpha(0f);
        dialoguePortrait.GetComponent<CanvasRenderer>().SetAlpha(0f);
    }
}