using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{
    private GameObject projectileInt2;
    public GameObject projectile;
    public Transform shotPoint;
    [SerializeField] private Transform player;
    Vector3 playerLoc;


    void Start()
    {

    }


    void Update()
    {
        }

    void OnTriggerStay2D(Collider2D coll){
      if(coll.gameObject.tag == "player"){
        playerLoc = new Vector3(player.position.x,player.position.y,player.position.z);
        if(projectileInt2 == null){
        projectileInt2 = Instantiate(projectile, shotPoint.position, transform.rotation);
        projectileInt2.GetComponent<Rigidbody2D>().AddForce(playerLoc.normalized * 15 , ForceMode2D.Impulse);
        Debug.Log("hi");
      }
      }
      }
}
