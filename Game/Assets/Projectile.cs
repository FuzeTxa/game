using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 LastVelocity;



    void Start()
    {
    }

    void Update()
    {
      if(gameObject != null){
        returnBall();
      }

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

        public void returnBall(){
          if(Input.GetKeyDown("e")){
            Destroy(gameObject);
          }
        }


}
