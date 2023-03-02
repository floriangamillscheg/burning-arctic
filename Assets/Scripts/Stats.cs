using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
public class Stats : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public TMP_Text m_TextComponent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string animal = player.GetComponent<SwitchAnimals>().GetCurrentAnimal().GetComponent<Animal>().name;
        animal = Regex.Replace(animal, @" ?\(.*?\)", string.Empty);
        m_TextComponent.text = animal;
    }
}
