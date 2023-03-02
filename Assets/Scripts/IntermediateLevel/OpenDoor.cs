using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    private bool open_;
    [SerializeField] private GameObject door_;

    [SerializeField] private GameObject camera_;
    private bool cameraSwitch_ = true;
    private GameObject player_;
    private FollowTargetI follow_;

    protected void Start() {
        follow_ = camera_.GetComponent<FollowTargetI>();
    }

    protected void Update () {
        if (open_ && door_.transform.position.y < 5) {
            door_.transform.position += new Vector3(0, Time.deltaTime, 0);
            if (door_.transform.position.y > 2 && cameraSwitch_) {
                follow_.SetTarget(player_);
                cameraSwitch_ = false;
            }
        }
    }

    protected void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Interactable")) {
            if (!open_) {
                player_ = follow_.GetTarget();
                follow_.SetTarget(door_);
            }
            open_ = true;
        }
    }
}
