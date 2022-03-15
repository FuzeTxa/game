using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Vector3 LastVelocity;

    private Rigidbody2D rb;
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {


      //  if(Physics.Raycast()){}
    }

  //  void OnTriggerEnter2D(Collider2D other){
  //      switch(other.gameObject.tag){
  //        case "Wall":
  //        Destroy(this);
  //        break;
//
  //      }
  //  }


    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.CompareTag("player"))
          {
              Destroy(gameObject);
          }
      else if(other.gameObject.CompareTag("Wall")){
          Destroy(gameObject);
      }
      else if(other.gameObject.CompareTag("Enemy")){
          Destroy(gameObject);
      }
      else if(other.gameObject.CompareTag("rangeWall")){
          Destroy(gameObject);
      }

        if(rb.velocity.x == 0 || rb.velocity.y == 0){
         Destroy(gameObject);
      }

}
}
