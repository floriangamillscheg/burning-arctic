using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDummy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Vector2 speed_;

    public Vector2 GetSpeed() {
        return speed_;
    }
}
