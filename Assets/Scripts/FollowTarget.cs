using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    [SerializeField] private GameObject target_;
    [SerializeField] private Vector3 offset_;
    [SerializeField] private float ppy_;
    [SerializeField] private float cc_;
    [SerializeField] private float c_;
    // Update is called once per frame
    private void Update()
    {
        // Camera follows the player with specified offset position
        var player_pos = Camera.main.WorldToViewportPoint(target_.transform.position);
        ppy_ = player_pos.y;
        var y_pos = transform.position.y;
        cc_ = (player_pos.y + 0.25f);
        if (player_pos.y < 0.25) {
            y_pos = Camera.main.ViewportToWorldPoint(new Vector3(0, cc_, 0)).y;
        } else if (player_pos.y > 0.5f && target_.CompareTag("Player")) {
            y_pos += 0.02f;
        }
        c_ = y_pos;
        transform.position = new Vector3(target_.transform.position.x + offset_.x, y_pos, transform.position.z);
    }

    public void SetTarget(GameObject target)
    {
        target_ = target;
    }

    public GameObject GetTarget() {
        return target_;
    }
}
