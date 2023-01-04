using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepellPlayer : MonoBehaviour
{
    public Vector3 direction;
    private void OnTriggerStay(Collider collision)
    {
        // Check if the colliding objects have the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            // Apply a force to the other collider
            Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            otherRigidbody.isKinematic = false;
            //Vector3 forceDirection = otherRigidbody.transform.position - transform.position;
            otherRigidbody.AddForce(direction * 5f, ForceMode.Impulse);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody otherRigidbody = other.gameObject.GetComponent<Rigidbody>();
            otherRigidbody.isKinematic = true;
        }
    }
}
