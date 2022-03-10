using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{

    public static Rigidbody2D rb;
    Vector3 LastVelocity;
    GameObject player;

    Transform playerTransform;


    [SerializeField]
    public float fireForce;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("player");
         playerTransform = player.transform;


    }

    void Update()
    {
        LastVelocity = rb.velocity;
        
        if(rb.velocity.x == 0 || rb.velocity.y == 0){
         Destroy(gameObject);
      }

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
          Vector3 collPoint = coll.contacts[0].point;
      if(coll.gameObject.CompareTag("Enemy")){

        var directionToPlayer = playerTransform.position - collPoint;
        rb.velocity = (directionToPlayer.normalized * fireForce);
        rb.gravityScale = 0;

      }
      if(coll.gameObject.CompareTag("Environment")){

                var speed = LastVelocity.magnitude;
                var direction = Vector3.Reflect(LastVelocity.normalized,coll.contacts[0].normal);
                var directionToPlayer = playerTransform.position - transform.position;

                var direction2 = Vector3.Lerp(direction, directionToPlayer, 0);

                rb.velocity= direction2 * Mathf.Max(speed/3,0f);
                rb.gravityScale = 1;
      }
    }
}
