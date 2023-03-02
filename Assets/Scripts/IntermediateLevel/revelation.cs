using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revelation : MonoBehaviour {
    [SerializeField] private GameObject hiddingpaper_;

    protected void OnCollisionEnter2D(Collision2D other) {
        hiddingpaper_.SetActive(false);
        Destroy(this.gameObject);
    }
}
