using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxCollision : MonoBehaviour
{
    public GameObject target; // Reference to the target GameObject
    public bool isActive = false;
    // This function is called when a collision occurs between the colliders of the two objects
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the target
        if (collision.gameObject == target)
        {
            // Bounce the target up
            Rigidbody targetRigidbody = target.GetComponent<Rigidbody>();
            if (targetRigidbody != null)
            {
                targetRigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
                isActive = true;
            }
        }
    }
}
