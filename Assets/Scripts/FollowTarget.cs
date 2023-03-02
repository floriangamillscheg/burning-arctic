using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    [SerializeField] private GameObject target_;
    [SerializeField] private Vector3 offset_;

    public bool isXY = false;

    // Update is called once per frame
    private void Update()
    {
        // Camera follows the player with specified offset position
        if (isXY)
        {
            transform.position = new Vector3(target_.transform.position.x + offset_.x, target_.transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(target_.transform.position.x + offset_.x, transform.position.y, transform.position.z);
        }
    }

    public void SetTarget(GameObject target)
    {
        target_ = target;
    }

    public GameObject GetTarget() {
        return target_;
    }
}
