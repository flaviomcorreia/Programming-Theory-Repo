using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;

    private GameObject focalPoint;
    public GameObject powerup;

    public bool hasPowerup = false;
    public float playerSpeed = 10f;
    public float powerUpStrenght = 15f;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInpuse = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * playerSpeed * verticalInpuse);
        powerup.transform.position = transform.position + new Vector3 (0,-0.5f,0);
    }

    IEnumerator PowerupCountdownRoutine (){
        yield return new WaitForSeconds(5);
        powerup.SetActive(false);
        hasPowerup = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerup.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position);

            enemyRb.AddForce(awayFromPlayer * powerUpStrenght, ForceMode.Impulse);
        }
    }
}
