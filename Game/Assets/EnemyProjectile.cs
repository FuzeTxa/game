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


    }




    void OnTriggerEnter2D(Collider2D other)
    {

      // wenn das mit dem Script verbundene gameObject ein anderes GameObject mit Tag "" berührt mach das:
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

        // wenn Geschwindigkeit des Körpers 0 ist, vernichte es
        if(rb.velocity.x == 0 || rb.velocity.y == 0){
         Destroy(gameObject);
      }

}
}
