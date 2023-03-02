using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPrefabHolder : MonoBehaviour
{
    public static AnimalPrefabHolder instance;

    public GameObject player;

    // [Header("Current Stats")]
    // public GameObject currentAnimal;
    // public List<GameObject> controllableAnimals;

    [Header("Animal Prefabs")]
    public GameObject hare;
    public GameObject polarBear;
    public GameObject fox;
    public GameObject penguin;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void AddHareToPlayer()
    {
        GameObject playerHare = player.transform.Find(hare.name).gameObject;
        if (playerHare == null)
        {
            Instantiate(hare, player.transform);
        }
        else
        {
            Debug.Log("Player already has Hare as a playable animal!");
        }
    }

    public void AddBearToPlayer()
    {
        GameObject playerBear = player.transform.Find(polarBear.name).gameObject;
        if (playerBear == null)
        {
            Instantiate(polarBear, player.transform);
        }
        else
        {
            Debug.Log("Player already has Polar Bear as a playable animal!");
        }
    }

    public void AddPenguinToPlayer()
    {
        var playerPenguin = player.transform.Find(penguin.name);
        if (!playerPenguin)
        {
            Instantiate(penguin, player.transform);
        }
        else
        {
            Debug.Log("Player already has Hare as a playable animal!");
        }
    }

    public void AddFoxToPlayer()
    {
        GameObject playerFox = player.transform.Find(fox.name).gameObject;
        if (playerFox == null)
        {
            Instantiate(fox, player.transform);
        }
        else
        {
            Debug.Log("Player already has Fox as a playable animal!");
        }
    }
}
