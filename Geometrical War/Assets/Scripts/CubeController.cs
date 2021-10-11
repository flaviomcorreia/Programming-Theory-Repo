using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : EnemyController
{   
    void Start(){
        speed = 0f;
    }
    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Enemy")|| other.gameObject.CompareTag("Player")){
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            speed = 10f;
        }

    }
}
