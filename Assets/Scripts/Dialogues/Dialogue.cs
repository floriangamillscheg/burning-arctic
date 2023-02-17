using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    public List<DialogueLine> dialogueLines;
}

[System.Serializable]
public class DialogueLine
{
    public string speakerName;
    [TextArea(3, 6)]
    public string text;
    public Vector3 offset;
}
