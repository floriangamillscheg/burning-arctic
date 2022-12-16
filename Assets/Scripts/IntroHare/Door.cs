using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    List<int> foundInfoObjects = new List<int>();
    [SerializeField] private GameObject goal_;

    // Should be called after the rabbits enters the cave
    protected void Close()
    {
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
        colliders[1].enabled = true;
    }

    // Should be called after the last Infobox is triggered
    protected void Open()
    {
        gameObject.SetActive(false);
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
            goal_.SetActive(true);
        }
    }
}
