using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyController : MonoBehaviour
{   
    
    protected float speed = 10f;
    private Rigidbody enemyRb; 

    private GameObject player;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {   
        move();
    }

    public void move(){
        Vector3 lookDirection = (player.transform.position - transform.position).normalized; 
        enemyRb.AddForce(lookDirection * speed);

        if(transform.position.y < - 10){
            Destroy(gameObject);
        }
    }
}
