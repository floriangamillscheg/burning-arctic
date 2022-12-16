using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Stats : MonoBehaviour
{
    // Start is called before the first frame update
    public IceBearMovement player;
    public TMP_Text m_TextComponent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_TextComponent.text = "Health: " + player.health;
    }
}
