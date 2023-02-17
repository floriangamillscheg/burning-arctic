using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageScene : MonoBehaviour
{

    [Header("Managed Objects")]
    [SerializeField] private GameObject foxTrapped_;
    [SerializeField] private GameObject startingPlayer_;
    [SerializeField] private GameObject newPlayer_;
    //[SerializeField] private GameObject speech_;
    private float extPos_ = -5.5f;

    //States
    private bool start_ = false;
    private bool speaking_ = false;
    private bool switch_ = false;



    // Update is called once per frame
    private void Update()
    {
        if (start_)
        {
            if (!speaking_)
            {
                foxTrapped_.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
               // speech_.SetActive(true);
                speaking_ = true;
            }
            else
            {
                if (Input.anyKey)
                {
                   // speech_.SetActive(false);
                    gameObject.SetActive(false);
                }
            }
        }
    }

    public void StartAnimation()
    {
        start_ = true;
        foxTrapped_.GetComponentInChildren(typeof(Canvas)).gameObject.SetActive(false);
        newPlayer_.transform.position = startingPlayer_.transform.position;
        newPlayer_.SetActive(true);
        startingPlayer_.SetActive(false);
        Camera.main.GetComponent<FollowTarget>().SetTarget(newPlayer_);
        MonoBehaviour[] scripts = newPlayer_.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour m in scripts)
        {
            m.enabled = false;
        }
    }

    private void OnDisable()
    {
        foxTrapped_.SetActive(false);
        MonoBehaviour[] scripts = newPlayer_.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour m in scripts)
        {
            m.enabled = true;
        }
        if (switch_)
        {
            newPlayer_.gameObject.GetComponent<SwitchAnimals>().SwitchAnimal();
        }
    }
}
