using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public float atkRange;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        if (distanceToTarget > atkRange)
        {
            TryMove(transform.position);
        }
        else
        {
            TryAttack();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TryMove(Vector3 currentPos)
    {
        //Current position of traget
        Vector3 tragetPosition = target.transform.position;
        //Distance to the traget
        Vector3 displacement = tragetPosition - currentPos;
        //Normalized the distance
        displacement = displacement.normalized;

        //Moves enemy to target
        rigidbody.MovePosition(currentPos += displacement * speed * Time.fixedDeltaTime * atkRange);
    }

    private void TryAttack()
    {
        //create a newobject to be the hitbox
        GameObject HitBox = new GameObject("HitBox");

        // Add components to the new GameObject
        HitBox.AddComponent<MeshRenderer>();
        HitBox.AddComponent<MeshFilter>();
        HitBox.AddComponent<BoxCollider>();

        // Set the position of the new GameObject
        HitBox.transform.position = transform.position + new Vector3(-atkRange, 0f, 0f);

        //Checks teh position of the hitbox and the target
        if (HitBox.transform.position == target.transform.position)
        {
            // Bounce the target up
            Rigidbody targetRigidbody = target.GetComponent<Rigidbody>();
            if (targetRigidbody != null)
            {
                targetRigidbody.AddForce(Vector3.up * 10f, ForceMode.Impulse);
            }
        }

        Destroy(HitBox);
    }
   
}
