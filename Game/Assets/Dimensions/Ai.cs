using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{
    private GameObject projectileInt2;
    public GameObject projectile;
    public Transform shotPoint;
    [SerializeField] private Transform player;
    [SerializeField] private Animator animator;
    Vector3 playerLoc;
    bool canShoot = true;


    void Start()
    {

    }


    void Update()
    {
        }



      public void shootPlayer(){
        playerLoc = new Vector3(player.position.x,player.position.y,player.position.z) - shotPoint.position;
        if(projectileInt2 == null && canShoot){
        projectileInt2 = Instantiate(projectile, shotPoint.position, transform.rotation);
        projectileInt2.GetComponent<Rigidbody2D>().AddForce(playerLoc.normalized * 10 , ForceMode2D.Impulse);
        animator.SetBool("shoot", true);
        StartCoroutine(endAnim());
        canShoot = false;
        StartCoroutine(shootAgain());
      }
      }



      private IEnumerator shootAgain()
      {
        yield return new WaitForSeconds(1f);
        canShoot = true;
}

private IEnumerator endAnim()
{
  yield return new WaitForSeconds(0.1f);
  animator.SetBool("shoot", false);
}

}
