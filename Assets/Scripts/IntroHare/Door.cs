using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    List<int> foundInfoObjects = new List<int>();

    // Should be called after the rabbits enters the cave
    protected void Close()
    {
        Debug.Log("Falle zu");
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
        colliders[1].enabled = true;
    }

    // Should be called after the last Infobox is triggered
    protected void Open()
    {
        Debug.Log("Sesam oeffne dich");
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
        colliders[1].enabled = false;
    }

    // Should save which infoboxes are already found
    public void InfoBoxFound(Canvas infoBox)
    {
        int infoBoxID = infoBox.GetInstanceID();
        if(foundInfoObjects.Count == 0)
        {
            Close();
            
        }
        if (!foundInfoObjects.Contains(infoBoxID))
        {
            Debug.Log("Yey new info");
            foundInfoObjects.Add(infoBoxID);
        }
        if (foundInfoObjects.Count == 4)
        {
            Open();
        }
    }
}
