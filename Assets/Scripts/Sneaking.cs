using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sneaking : MonoBehaviour
{
    public bool stealthActive = false;
    public GameObject stealthBar;
    private float stealthTimer = 2;
    private bool timerIsRunning = false;

    // Update is called once per frame
    void Update()
    {
        Vector3 stealthValue = stealthBar.transform.localScale;
        if (timerIsRunning)
        {
            if (stealthTimer > 0)
            {
                stealthTimer -= Time.deltaTime;
                stealthValue.x =  stealthTimer/2;
                stealthBar.transform.localScale = stealthValue;


            }
            else
            {
                stealthActive = false;
                Color newColor = gameObject.GetComponent<SpriteRenderer>().color;
                newColor.a = 1.0f;
                gameObject.GetComponent<SpriteRenderer>().color = newColor;
                timerIsRunning = false;
            }
        }
        else if (stealthTimer < 2)
        {
            stealthTimer += Time.deltaTime*2;
            if (stealthTimer > 2)
            {
                stealthTimer = 2;
            }
            stealthValue.x = stealthTimer / 2;
            stealthBar.transform.localScale = stealthValue;
        }
        else
        {
            if (Input.GetKey(KeyCode.R))
            {
                stealthActive = true;
                Color newColor = gameObject.GetComponent<SpriteRenderer>().color;
                newColor.a = 0.1f;
                gameObject.GetComponent<SpriteRenderer>().color = newColor;
                timerIsRunning = true;
            }
        }
    }
}
