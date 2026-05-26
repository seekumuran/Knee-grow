using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public string[] dialogueLines;

    private int currentLine;

    public void StartDialogue()
    {
        currentLine = 0;

        dialogueText.text =
            dialogueLines[currentLine];
    }

    public void NextLine()
    {
        currentLine++;

        if (currentLine >= dialogueLines.Length)
        {
            EndDialogue();

            return;
        }

        dialogueText.text =
            dialogueLines[currentLine];
    }

    void EndDialogue()
    {
        dialogueText.text = "";
    }
}
