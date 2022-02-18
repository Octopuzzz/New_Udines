using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    bool IsInside;
    GameObject Food;
    PlayerMovement Player;
    public bool IsTrigger;
    private float count = 0;    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            IsTrigger = true;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            IsInside = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (IsTrigger && IsInside)
        {
            if (other.gameObject.CompareTag("Food"))
            {
                if (other.gameObject.tag == "Food")
                {
                    count += 1f;
                }
                Food = other.gameObject;
                Food.SetActive(false);
                Player.DropObject();
                count = 0f;
                Destroy(Food);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            IsTrigger = false;
        }      
        if (other.gameObject.CompareTag("Player"))
        {
            IsInside = false;
        }
    }
}
