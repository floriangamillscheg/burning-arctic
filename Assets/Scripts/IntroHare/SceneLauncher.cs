using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLauncher : MonoBehaviour
{

    [SerializeField] private GameObject script_;

    void OnCollisionEnter2D(Collision2D collision)
    {
        script_.GetComponent<HareLevelCutScene>().StartAnimation();
        Destroy(gameObject);
    }
}
