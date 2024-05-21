using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    Rigidbody rb;
    GameManager gameManager;

    float minSpeed = 10f;
    float maxSpeed = 15f;
    float minTroque = -10;
    float maxTorque = 10f;
    float xSpawnPos = 4f;
    float ySpawnPos = 2;
   [SerializeField] int pointValue;
   [SerializeField] ParticleSystem explosion;
    SoundsManager soundsManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RandomTargetsForcingUpwards();
        RandomTorque();
        RandomSpawnPos();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundsManager = GameObject.Find("AudioManager").GetComponent<SoundsManager>();
    }

    private void RandomSpawnPos()
    {
        transform.position = new Vector3(Random.Range(-xSpawnPos, xSpawnPos), -ySpawnPos);
    }

    private void RandomTorque()
    {
        rb.AddTorque(Random.Range(-minTroque, maxTorque), Random.Range(-minTroque, maxTorque), Random.Range(-minTroque, maxTorque), ForceMode.Impulse);
    }

    private void RandomTargetsForcingUpwards()
    {
        rb.AddForce(Vector3.up * Random.Range(minSpeed, maxSpeed), ForceMode.Impulse);
    }
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            soundsManager.PlaySounds();
            Destroy(gameObject);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
