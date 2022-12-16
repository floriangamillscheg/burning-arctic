using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    [SerializeField] private GameObject target_;
    [SerializeField] private Vector3 offset_;

    // Update is called once per frame
    private void Update() {
        // Camera follows the player with specified offset position
        transform.position = new Vector3(target_.transform.position.x + offset_.x, transform.position.y, transform.position.z);
    }

    public void SetTarget(GameObject target) {
        target_ = target;
    }
}
