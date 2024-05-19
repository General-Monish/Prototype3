using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody Rigidbody;
    [SerializeField] float moveSpeed;
    GameObject Player;
    float boundY=5f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (Player.transform.position - transform.position).normalized;
        Rigidbody.AddForce(lookDirection* moveSpeed);

        if(transform.position.y < -boundY)
        {
            Destroy(gameObject);
        }
    }
}
