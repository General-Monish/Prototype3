using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float powerUpStrength;
    [SerializeField] GameObject powerUpIndicatorPrefab;
    float verticalInput;
    GameObject focalPoint;
    Rigidbody rb;
    bool hasPowerUp=false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * moveSpeed * verticalInput);
        powerUpIndicatorPrefab.transform.position = transform.position + new Vector3(0, -.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            powerUpIndicatorPrefab.gameObject.SetActive(true);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody=collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position-transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            Debug.Log("Collided with :" + collision.gameObject.name+ " has PowerUp " + hasPowerUp);
            StartCoroutine(PowerUpCoutdouwnCoroutine());
        }
    }
    IEnumerator PowerUpCoutdouwnCoroutine()
    {
        yield return new WaitForSeconds(5f);
        hasPowerUp = false;
        powerUpIndicatorPrefab.gameObject.SetActive(false);
    }
}
