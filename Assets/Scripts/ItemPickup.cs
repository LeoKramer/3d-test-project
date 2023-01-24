using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Movement>().score ++;
        other.gameObject.GetComponent<Movement>().timeLeft += 2;
    }
}
