using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform destination;

    private void Start()
    {
        destination = GameObject.Find("Destination").transform;
    }

    public void PickedUp()
    {
        GetComponentInChildren<Rigidbody>().useGravity = false;
        GetComponent<Transform>().position = destination.position;
        this.transform.parent = GameObject.Find("Destination").transform;
    }

    public void PickedDown()
    {
        this.GetComponentInChildren<Rigidbody>().useGravity = true;
    }
}
