using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask layerGround;
    public float MovementSpeed = 1f;
    public float JumpForce = 1f;

    bool canMove = true;
    public Animator animator;
    private Rigidbody2D rb;
    private CapsuleCollider2D ground;

    private static int face = 0;

    void Start()
    {
      rb = GetComponent<Rigidbody2D>();               // greife auf den Körper zu
      ground = GetComponent<CapsuleCollider2D>();     // greife auf die Hitbox zu

    }



    void Update()
    {


        float movement = Input.GetAxis("Horizontal");    // definiere die Variable "movement" (wenn links als -1 wenn rechts als 1)
      if(canMove){   // wenn canMove true ist mach:
       rb.velocity = new Vector2(movement * MovementSpeed, rb.velocity.y); // bewegt den Spieler
     }

     // ändert die Richtung in der der Spieler schaut, je nach in welche Richtung er läuft
       if(Input.GetAxis("Horizontal") > 0){
         transform.localScale = new Vector3(0.2f,0.2f,1);
         face = 1;
       }

       if(Input.GetAxis("Horizontal") < 0 ){
         transform.localScale = new Vector3(-0.2f,0.2f,1);
         face = -1;

       }
      animator.SetFloat("Speed", Mathf.Abs(movement));


        // wenn canMove true ist ,grounded true ist und space gedrückt wird dann führe Methode jump aus und spiele Jump animation aus.
        if(Input.GetButton("Jump") && grounded() && canMove)  {
          Jump();
          animator.SetBool("isJumping", true);
        }
        else if(grounded()){
          animator.SetBool("isJumping",false);
        }
      }

          // gibt die Richtung in der der Spieler schaut aus
      public static int Richtung(){
        return face;
      }


// Spieler wird nach oben "geschoben" um einen Sprung vorzutäuschen
    void Jump(){
      rb.velocity = new Vector2(rb.velocity.x, JumpForce * Time.fixedDeltaTime);
        }


        // erstellt einen weiteren Collider 1 pixel nach unten verschoben und prüft ob dieser mit einem Objekt welches den Layer Ground hat kollidiert
        private bool grounded(){
          return Physics2D.BoxCast(ground.bounds.center, ground.bounds.size, 0f, Vector2.down, .1f, layerGround);
        }

        // schaltet die Bewegung aus
    public void DisableMovement(){
      canMove = false;
    }

}
