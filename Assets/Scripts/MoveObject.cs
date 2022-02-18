using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Des;


    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        // use gravity for take up gameobject
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        this.transform.position = Des.transform.position;
        this.transform.parent = GameObject.Find("Up").transform;
    }
    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
