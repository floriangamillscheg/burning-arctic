using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushController : MonoBehaviour
{
    // Start is called before the first frame update#

    [SerializeField]
    private float forceMagnitude;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody2D rigidbody = hit.collider.gameObject.GetComponent<Rigidbody2D>();

        Debug.Log("hello!");
        if (Input.GetKey(KeyCode.F))
            Debug.Log("Key down!");
        if(rigidbody != null && Input.GetKey(KeyCode.F))
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode2D.Impulse);
        }
    }
}
