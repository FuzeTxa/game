using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 LastVelocity;

    public Transform shotPoint;
    public Weapon weapon;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {


      //  if(Physics.Raycast()){}
    }

    void OnTriggerEnter2D(Collider2D other){
        switch(other.gameObject.tag){
          case "Wall":
          Destroy(gameObject);
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
