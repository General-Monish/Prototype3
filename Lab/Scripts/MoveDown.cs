using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody rb;

    float Zbound=9f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.forward * - speed );

        if(transform.position.z < -Zbound)
        {
            Destroy(gameObject);
        }
    }


}