using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Vector2 speed_;
    private Rigidbody2D rigidbody_;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody_ = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // get the game object who is the current active animal
        GameObject animalGO = gameObject.GetComponent<SwitchAnimals>().GetCurrentAnimal();
        speed_ = animalGO.GetComponent<AnimalDummy>().GetSpeed();


        float inputX = Input.GetAxis("Horizontal");
        rigidbody_.velocity = new Vector2(speed_.x * inputX, rigidbody_.velocity.y);
    }
}
