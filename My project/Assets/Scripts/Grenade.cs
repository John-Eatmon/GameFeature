using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grenade : MonoBehaviour
{
    public GameObject spherePrefab;
    public string floorTag = "Floor";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(floorTag))
        {
            // Stick the current sphere to the floor
            Rigidbody sphereRb = spherePrefab.GetComponent<Rigidbody>();
            sphereRb.isKinematic = true;

            // Turn on the shield child object
            Transform shield = spherePrefab.transform.Find("Shield");
            if (shield != null)
            {
                shield.gameObject.SetActive(true);
            }
        }
    }
}

