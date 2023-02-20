using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SwitchAnimals : MonoBehaviour
{
    public static SwitchAnimals instance;

    public List<GameObject> animals_ = new List<GameObject>();
    private int currentAnimal_;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Transform child in transform)
        {
            if (child.CompareTag("Animal"))
            {
                animals_.Add(child.gameObject);
            }
        }
        currentAnimal_ = 0;
        foreach (GameObject animal in animals_)
        {
            if (animal.activeSelf)
            {
                break;
            }
            ++currentAnimal_;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            SwitchAnimal();
        }
    }

    private int NumberOfAnimals()
    {
        int count = 0;
        foreach (GameObject animal in animals_)
        {
            ++count;
        }
        return count;
    }

    public void SwitchAnimal()
    {
        animals_[currentAnimal_].SetActive(false);
        ++currentAnimal_;
        currentAnimal_ %= NumberOfAnimals();
        animals_[currentAnimal_].SetActive(true);
    }

    public void AddAnimal(GameObject animal)
    {
        GameObject checkAnimal = animals_.Where(obj => obj.GetComponent<Animal>().name_ == animal.name).SingleOrDefault();

        if (!animals_.Contains(checkAnimal))
        {
            GameObject animalInst = Instantiate(animal, transform);
            animals_.Add(animalInst);
            animalInst.SetActive(false);
        }
        else
        {
            Debug.Log("Already have this animal!");
        }
    }

    public GameObject GetCurrentAnimal()
    {
        return animals_[currentAnimal_];
    }

}
