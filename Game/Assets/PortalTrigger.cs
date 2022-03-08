using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{

  [SerializeField] private Animator PortalAnim;
  public PlayerMovement pm;
  [SerializeField] private GameObject Player;


  private void OnCollisionEnter2D(Collision2D coll)
  {

          if(coll.gameObject.CompareTag("player")){
            PortalAnim.Play("Portal");
            Player.SetActive(!Player.activeSelf);

          }

    }
}
