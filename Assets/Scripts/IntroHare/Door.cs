using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    List<int> foundInfoObjects = new List<int>();

    // Should be called after the rabbits enters the cave
    protected void Close()
    {
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
        colliders[1].enabled = true;
    }

    // Should be called after the last Infobox is triggered
    protected void Open()
    {
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
        colliders[1].enabled = false;
    }

    // Should save which infoboxes are already found
    public void InfoBoxFound(int infoBoxID)
    {
        if (!foundInfoObjects.Contains(infoBoxID))
        {
            if (foundInfoObjects.Count == 1)
            {
                Close();

            }
            Debug.Log(infoBoxID);
            foundInfoObjects.Add(infoBoxID);
        }
        if (foundInfoObjects.Count == 4)
        {
            Open();
        }
    }
}
