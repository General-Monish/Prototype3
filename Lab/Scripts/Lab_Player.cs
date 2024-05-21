using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab_Player : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody rb;

    float hInput;
    float vInput;
    float zBound=6.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        ContrainPlayerLimits();

    }

    private void ContrainPlayerLimits()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }

    private void MovePlayer()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        rb.AddForce(Vector3.forward * speed * vInput);
        rb.AddForce(Vector3.right * speed * hInput);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hitted");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Debug.Log("PowerUp Hitted");
            Destroy(other.gameObject);
        }
    }
}
