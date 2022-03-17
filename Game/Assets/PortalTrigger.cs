using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrigger : MonoBehaviour
{

  [SerializeField] private Animator PortalAnim;
  public PlayerMovement pm;
  [SerializeField] private GameObject Player;
  [SerializeField] private GameObject ball;

  public int LevelToLoad;
  public static bool VoidAnim = false;



  private void OnCollisionEnter2D(Collision2D coll) // wenn ein Körper mit dem Körper, welches mit diesem Script verbunden ist, kollidiert, macht das:
  {

          if(coll.gameObject.CompareTag("player")){ // wenn das Objekt den Tag "Player" hat, mache:
            PortalAnim.Play("Portal"); // spiele die Animation "Portal" ab
            Player.SetActive(!Player.activeSelf); // deaktiviere das Objekt Player"
            StartCoroutine(LoadNewScreen()); // führe Coroutine "LoadNewScreen" aus
            VoidAnim = true;

                  }
                  if(coll.gameObject.CompareTag("player")){

// vernichte alle Objekte mit dem Tag "ball"
                    GameObject[] destroyObject;
                    destroyObject = GameObject.FindGameObjectsWithTag("ball");
                    foreach (GameObject oneObject in destroyObject)
                    Destroy (oneObject);
                  }

    }


    void LoadScene(){
      LoadNewScreen();
    }


      private IEnumerator LoadNewScreen()
      {
        yield return new WaitForSeconds (1.7f); // warte 1.7 Sekunden
          SceneManager.LoadScene(LevelToLoad); // lade neue Szene

      }


}
