using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour {

    [SerializeField] private Sprite newSprite_;
    private Transform child_;
    private GameObject info_;
    // Start is called before the first frame update
    private void Start() {
        child_ = transform.Find("Information");
        Debug.Assert(child_ != null, "Could not find the Information child");
        info_ = child_.gameObject;
    }

    // Update is called once per frame
    private void Update() {
        if (info_.activeSelf == true) {
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite_;
        }
    }
}
