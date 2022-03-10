using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidStart : MonoBehaviour
{
  public GameObject Player;

  public Animator Animator;
  public GameObject AnimObject;
  public Animator mcAnim;

//  public Animator mcAnim;


  bool PlayAnim = false;
  bool mcZoom = false;
  //bool fAnimBool = false;

  void Start()
  {
    Player.SetActive(false);
      PlayAnim = true;
      StartCoroutine(ShowPlayer());
  }


  void Update()
  {
      if(PlayAnim){
      Animator.Play("Void");
      PlayAnim = false;
    }
      if(mcZoom){
        mcAnim.Play("MCzoom");
       mcZoom = false;
//      }
//      if(fAnimBool){
//        fAnim.Play("fAnim");
//        fAnimBool = false;
      }
    }


  private IEnumerator ShowPlayer()
  {
  yield return new WaitForSeconds (0.9f);
  Player.SetActive(true);
  AnimObject.SetActive(false);
  yield return new WaitForSeconds (1.5f);
  mcZoom = true;
//  yield return new WaitForSeconds (1.5f);
//  fAnimBool = true;
}

}
