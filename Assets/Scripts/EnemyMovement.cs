using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Object target;
    public float speed;

    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Current position of traget
        Vector3 tragetPosition = target.GetComponent<Rigidbody>().position;
        //Distance to the traget
        Vector3 displacement = tragetPosition - transform.position;
        //Normalized the distance
        displacement = displacement.normalized;
        
        //Moves enemy to target
        rigidbody.MovePosition(transform.position + displacement * speed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
