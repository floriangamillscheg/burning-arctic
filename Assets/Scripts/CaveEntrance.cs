using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveEntrance : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            Debug.Log("Entered cave.");

            other.transform.parent.GetComponent<PenguinMovement>().enabled = true;
            other.transform.parent.GetComponent<XYMovement>().enabled = false;
            other.transform.parent.Find("Bubbles").gameObject.SetActive(false);
        }
    }
}
