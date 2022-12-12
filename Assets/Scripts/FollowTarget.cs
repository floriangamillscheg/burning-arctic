using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class FollowTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public Vector3 offset;
   
    
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x + offset.x, transform.position.y, transform.position.z); // Camera follows the player with specified offset position
    }
}
