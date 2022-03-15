using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Weapon : MonoBehaviour
{

      private static int richtung;
      public LayerMask ballLayers;
      public Animator animator;
      public GameObject projectile;
      private GameObject projectileInt;
      public  float lifeTime;


        public Transform shotPoint;
        public float fireForce;

      private Transform aimTransform;
      public Transform attackPoint;
      public float attackRange;
      public static bool ballOnField;
      Rigidbody2D rbBall;

      public GameObject Indicator;
      public GameObject BlockIndicator;

      public float fireRate;
      float ReadyForNextShot;
      public float blockRate;
      float ReadyForNextBlock;

      public static int combo;

        void Awake(){
        aimTransform = transform.Find("Aim");
      }

      void Start(){

    }

    void Update()
    {

            if(projectileInt == null){
              Indicator.GetComponent<Renderer>().material.color = new Color(34f/255f, 135f/255f, 57f/255f);
            }
            else if(projectileInt !=null){
              Indicator.GetComponent<Renderer>().material.color = new Color(176f/255f,37f/255f,16f/255f);
            }

            if(combo == 0){
              BlockIndicator.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
            }
            if(combo > 2){
              BlockIndicator.GetComponent<Renderer>().material.color = new Color(109f/255f, 255f/255f, 28f/255f);
            }
            if(combo > 4){
              BlockIndicator.GetComponent<Renderer>().material.color = new Color(255f/255f, 182f/255f, 0f);
            }
            if(combo > 6){
              BlockIndicator.GetComponent<Renderer>().material.color = new Color(1f,0f, 0f);
            }

            richtung = PlayerMovement.Richtung();
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
            Vector3 aimDirection = (mousePosition - transform.position).normalized;
           if(richtung < 0){
              aimDirection.x = -aimDirection.x;
              mousePosition.x = -mousePosition.x;
              aimDirection.y = -aimDirection.y;
              mousePosition.y = -mousePosition.y;
           }

              float angle = Mathf.Atan2(aimDirection.y, aimDirection.x)* Mathf.Rad2Deg;
              aimTransform.eulerAngles = new Vector3(0,0,angle);


              if(Input.GetMouseButton(0))
              {
                  if(Time.time > ReadyForNextShot)
                  {
                    if(!ballOnField){
                    ReadyForNextShot = Time.time + 1/fireRate;
                    shoot();
                    ballOnField = true;
                    }
                  }
                }

              if(projectileInt == null){
                ballOnField = false;
                combo = 0;
              }

                if(Input.GetMouseButtonDown(1))
                {
                  if(Time.time > ReadyForNextBlock)
                  {
                    ReadyForNextBlock = Time.time + 1/blockRate;
                    block();
                  }
                  }


    }
      public void shoot()
        {

          animator.SetBool("shoot", true);
          SoundManagerScript.PlaySound("Schlag");
          if(richtung > 0){
            projectileInt = Instantiate(projectile, shotPoint.position, transform.rotation);
            projectileInt.GetComponent<Rigidbody2D>().AddForce(shotPoint.right.normalized * fireForce , ForceMode2D.Impulse);
          }
        else if(richtung < 0){
          projectileInt = Instantiate(projectile, shotPoint.position, transform.rotation);
          projectileInt.GetComponent<Rigidbody2D>().AddForce(shotPoint.right.normalized * fireForce *-1, ForceMode2D.Impulse);
        }
        if(richtung == 0){
          projectileInt = Instantiate(projectile, shotPoint.position, transform.rotation);
          projectileInt.GetComponent<Rigidbody2D>().AddForce(shotPoint.right.normalized * fireForce , ForceMode2D.Impulse);
        }
        if(animator.GetBool("shoot")){
            shootFalse();
          }


        }

        public void block()
          {

            animator.SetBool("shoot", true);
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, ballLayers);

            foreach(Collider2D other in hitEnemies){
              SoundManagerScript.PlaySound("Schlag");
              if(richtung > 0){
                if(other.gameObject.tag == "ball"){
              projectileInt.GetComponent<Rigidbody2D>().AddForce(shotPoint.right.normalized * fireForce,  ForceMode2D.Impulse);
              }
              else if(other.gameObject.tag == "enemyBall"){
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(shotPoint.right.normalized * fireForce,  ForceMode2D.Impulse);
              }

            }
              else if(richtung < 0){
                if(other.gameObject.tag == "ball"){
                projectileInt.GetComponent<Rigidbody2D>().AddForce(shotPoint.right.normalized * fireForce * -1,  ForceMode2D.Impulse);

              }
              else if(other.gameObject.tag == "enemyBall"){
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(shotPoint.right.normalized * fireForce * -1,  ForceMode2D.Impulse);
              }
            }
              combo++;
            }


            if(animator.GetBool("shoot")){
                shootFalse();
              }

          }



void OnDrawGizmosSelected(){
  if(attackPoint == null){
    return;
  }
  Gizmos.DrawWireSphere(attackPoint.position, attackRange);
}




        public void shootFalse()
        {
          StartCoroutine(SomeCoroutine());
        }

    private IEnumerator SomeCoroutine()
    {
    yield return new WaitForSeconds (0.5f);
    animator.SetBool("shoot", false);
  }


}
