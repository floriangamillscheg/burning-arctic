using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimals : MonoBehaviour
{
    [Header("Animals")]
    [SerializeField] private List<GameObject> animals_;
    private int currentAnimal_;

    // Start is called before the first frame update
    private void Start() {
        foreach(Transform child in transform) {
            if (child.CompareTag("Animal")) {
                animals_.Add(child.gameObject);
            }
        }
        currentAnimal_ = 0;
        foreach(GameObject animal in animals_) {
            if (animal.activeSelf) {
                break;
            }
            ++currentAnimal_;
        }
    }

    // Update is called once per frame
    private void Update() {
        if (Input.GetKeyDown("x")) {
            SwitchAnimal();
        }
    }

    private int NumberOfAnimals() {
        int count = 0;
        foreach (GameObject animal in animals_) {
            ++count;
        }
        return count;
    }

    public void SwitchAnimal() {
        animals_[currentAnimal_].SetActive(false);
        ++currentAnimal_;
        currentAnimal_%=NumberOfAnimals();
        animals_[currentAnimal_].SetActive(true);
        Debug.Log("Switch done");
    }

    public GameObject GetCurrentAnimal() {
        return  animals_[currentAnimal_];
    }

}
