using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrigger : MonoBehaviour
{

  [SerializeField] private Animator PortalAnim;
  public PlayerMovement pm;
  [SerializeField] private GameObject Player;

  public int LevelToLoad;
  public static bool VoidAnim = false;



  private void OnCollisionEnter2D(Collision2D coll)
  {

          if(coll.gameObject.CompareTag("player")){
            PortalAnim.Play("Portal");
            Player.SetActive(!Player.activeSelf);
            StartCoroutine(LoadNewScreen());
            VoidAnim = true;

                  }

    }


    void LoadScene(){
      LoadNewScreen();
    }


      private IEnumerator LoadNewScreen()
      {
        yield return new WaitForSeconds (1.7f);
          SceneManager.LoadScene(LevelToLoad);

      }


}
