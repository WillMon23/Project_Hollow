using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public float atkRange;
    public GameObject hitBox;
    private Rigidbody rigbody;

    // Start is called before the first frame update
    void Start()
    {
        rigbody = GetComponent<Rigidbody>();
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
        rigbody.MovePosition(currentPos += displacement * speed * Time.fixedDeltaTime * atkRange);
    }

    private void TryAttack()
    {
        //Move The hitbox to target
        Rigidbody hitBoxRigidbody = hitBox.GetComponent<Rigidbody>();
        hitBox.SetActive(true);
        Vector3 orginalPos = hitBoxRigidbody.position;

        //Current position of traget
        Vector3 tragetPosition = target.transform.position;
        //Distance to the traget
        Vector3 displacement = tragetPosition - hitBoxRigidbody.position;
        //Normalized the distance
        displacement = displacement.normalized;

        hitBoxRigidbody.MovePosition(hitBoxRigidbody.position + displacement * 1.0f * Time.fixedDeltaTime);

        //Checks for collision hit
        if(hitBox.GetComponentInParent<HitBoxCollision>().isActive == true)
        {
            hitBox.SetActive(false);
            hitBox.transform.position = orginalPos;
        }
    }
}
