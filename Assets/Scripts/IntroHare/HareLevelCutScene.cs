using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareLevelCutScene : MonoBehaviour {

    [Header("Managed Objects")]
    [SerializeField] private GameObject hareTrapped_;
    [SerializeField] private GameObject startingPlayer_;
    [SerializeField] private GameObject newPlayer_;
    [SerializeField] private GameObject speech_;
    [SerializeField] private float extPos_ = -5.5f;

    //States
    private bool start_ = false;
    private bool isOut_ => hareTrapped_.transform.position.x <= extPos_;
    private bool speaking_ = false;
    private bool switch_ = false;



    // Update is called once per frame
    private void Update() {
        if (start_) {
            if (!isOut_) {
                hareTrapped_.GetComponent<Rigidbody2D>().velocity = new Vector2(-2,0);
            } else if (!speaking_) {
                hareTrapped_.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                speech_.SetActive(true);
                speaking_ = true;
            }

            if (speaking_) {
                if (Input.GetButtonDown("Fire1")) {
                    speech_.SetActive(false);
                    gameObject.SetActive(false);
                }
                if (Input.GetKeyDown("x")) {
                    switch_ = true;
                    speech_.SetActive(false);
                    gameObject.SetActive(false);
                }
            }
        }
    }

    public void StartAnimation() {
        start_ = true;
        hareTrapped_.GetComponentInChildren(typeof(Canvas)).gameObject.SetActive(false);
        newPlayer_.transform.position = startingPlayer_.transform.position;
        newPlayer_.SetActive(true);
        startingPlayer_.SetActive(false);
        MonoBehaviour[] scripts = newPlayer_.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour m in scripts) {
            m.enabled = false;
        }
    }

    private void OnDisable() {
        hareTrapped_.SetActive(false);
        MonoBehaviour[] scripts = newPlayer_.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour m in scripts) {
            m.enabled = true;
        }
        if (switch_) {
            newPlayer_.gameObject.GetComponent<SwitchAnimals>().SwitchAnimal();
        }
    }
}
