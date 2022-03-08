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
      rb = GetComponent<Rigidbody2D>();
      ground = GetComponent<CapsuleCollider2D>();

    }



    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
      if(canMove){
       rb.velocity = new Vector2(movement * MovementSpeed, rb.velocity.y);
     }
       if(Input.GetAxis("Horizontal") > 0){
         transform.localScale = new Vector3(0.2f,0.2f,1);
         face = 1;
       }

       if(Input.GetAxis("Horizontal") < 0 ){
         transform.localScale = new Vector3(-0.2f,0.2f,1);
         face = -1;

       }
      animator.SetFloat("Speed", Mathf.Abs(movement));

        if(Input.GetButton("Jump") && grounded() && canMove)  {
          Jump();
          animator.SetBool("isJumping", true);
        }
        else if(grounded()){
          animator.SetBool("isJumping",false);
        }
      }

      public static int Richtung(){
        return face;
      }

    void Jump(){
      rb.velocity = new Vector2(rb.velocity.x, JumpForce * Time.fixedDeltaTime);
        }


        private bool grounded(){
          return Physics2D.BoxCast(ground.bounds.center, ground.bounds.size, 0f, Vector2.down, .1f, layerGround);
        }

    public void DisableMovement(){
      canMove = false;
    }

}
