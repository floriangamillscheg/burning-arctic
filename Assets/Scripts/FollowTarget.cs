using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offset;

    // Update is called once per frame
    private void Update() {
        // Camera follows the player with specified offset position
        transform.position = new Vector3(target.transform.position.x + offset.x, transform.position.y, transform.position.z);
    }
}
