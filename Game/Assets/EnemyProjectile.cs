using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Vector3 LastVelocity;

    void Start()
    {

    }

    void Update()
    {


      //  if(Physics.Raycast()){}
    }

    void OnTriggerEnter2D(Collider2D other){
        switch(other.gameObject.tag){
          case "Wall":
          Destroy(this);
          break;

        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
      if (other.gameObject.CompareTag("player"))
          {
              Destroy(gameObject);
          }
        }


}
