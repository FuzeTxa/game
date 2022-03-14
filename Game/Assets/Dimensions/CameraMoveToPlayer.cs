using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveToPlayer : MonoBehaviour
{

  [SerializeField] public Animator animator;
  [SerializeField] private GameObject player;
  [SerializeField] private GameObject cam;


    void Start()
    {
      player.GetComponent<Weapon>().enabled = false;
      player.GetComponent<PlayerMovement>().enabled = false;
      //cam.GetComponent<CameraMovement>().enabled = false;
      animator.Play("CamPlayer");
      StartCoroutine(endAnim());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator endAnim()
    {
      yield return new WaitForSeconds(5.5f);
      player.GetComponent<Weapon>().enabled = true;
      player.GetComponent<PlayerMovement>().enabled = true;
      cam.GetComponent<CameraMovement>().enabled = true;
      cam.GetComponent<Animator>().enabled = false;



  }
}
