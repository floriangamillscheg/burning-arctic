using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public int currentLineIndex = 0;
    private GameObject activeSpeechBubble;
    private bool isStarted = false;
    public UnityEvent endEvent;

    [Header("Dialogue References")]
    public Dialogue currentDialogue;
    public GameObject speechBubblePf;
    public TextMeshProUGUI dialogueText;
    public Canvas dialogueCanvas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        // dialogueText = speechBubblePf.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextLine();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("start Dialogue");
        if (currentDialogue == null)
        {
            Debug.Log("No dialogue is set!");
            return;
        }
        Debug.Log("start dialogue");

        if (isStarted) return;

        currentDialogue = dialogue;
        isStarted = true;

        currentLineIndex = 0;

        activeSpeechBubble = Instantiate(speechBubblePf, dialogueCanvas.transform);
        dialogueText = activeSpeechBubble.GetComponentInChildren<TextMeshProUGUI>();

        GameObject speaker = GetGameObjectByName(currentDialogue.dialogueLines[currentLineIndex].speakerName);
        activeSpeechBubble.transform.position = speaker.transform.position + currentDialogue.dialogueLines[currentLineIndex].offset;
        dialogueText.text = currentDialogue.dialogueLines[currentLineIndex].text;
    }

    private void NextLine()
    {

        if (!isStarted) return;

        if (currentLineIndex < currentDialogue.dialogueLines.Count - 1)
        {
            currentLineIndex++;
            GameObject speaker = GetGameObjectByName(currentDialogue.dialogueLines[currentLineIndex].speakerName);
            activeSpeechBubble.transform.position = speaker.transform.position + currentDialogue.dialogueLines[currentLineIndex].offset;
            dialogueText.text = currentDialogue.dialogueLines[currentLineIndex].text;
        }
        else
        {
            ResetDialogue();
        }
    }

    private void ResetDialogue()
    {
        // if (endEvent != null)
        // {
        endEvent.Invoke();
        // }

        isStarted = false;
        currentDialogue = null;
        Destroy(activeSpeechBubble);
        currentLineIndex = 0;
    }

    private GameObject GetGameObjectByName(string name)
    {
        GameObject go = GameObject.Find(name);
        return go;
    }
}

public enum DialogueState
{
    Playing,
    Waiting,
    Ended
}
