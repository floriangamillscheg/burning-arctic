using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockfeller : MonoBehaviour {

    private double timer_ = -1;
    [SerializeField] private GameObject camera_;
    private FollowTarget follow_;
    [SerializeField] private GameObject rocks_;


    // Start is called before the first frame update
    private void Start() {
        follow_ = camera_.GetComponent<FollowTarget>();
    }

    // Update is called once per frame
    private void Update() {
        if (timer_ > 0) {
            timer_ -= Time.deltaTime;
            if (timer_ < 0) {
                follow_.enabled = true;
                Destroy(this);
            }
        } 
    }

    protected void OnTriggerEnter2D(Collider2D other) {
        follow_.enabled = false;
        camera_.transform.position = new Vector3(96, 3, camera_.transform.position.z);
        timer_ = 3.0;
        rocks_.SetActive(true);
    }


}
