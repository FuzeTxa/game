using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFall : MonoBehaviour
{
  // SerializeField dient dazu, den Wert im Spiel an der Seite anpassen zu können
      [SerializeField ]private Animator Tree; // Anitmation "Tree" wird in den Script einbezogen
      [SerializeField ]private GameObject TreeObject; // Anitmation "TreeObject" wird in den Script einbezogen
      Collider2D TreeColl;

    void Start() // Wird ausgeführt bei Start
    {
         TreeColl = TreeObject.GetComponent<Collider2D>(); // Component "Collider2D" wird definiert als "TreeColl"
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D coll) // Bei Collision mit einem Object wird ...
    {

            if(coll.gameObject.CompareTag("ball") && changeTutorialText.tutorialFinished){  // Wenn der Ball mit dem Baum kollidiert und der Tutorialtext vollständig angezeigt wurde
              Tree.Play("TreeFall");          // spiele Animation "TreeFall"
              Destroy(gameObject);   // zerstöre das Objekt, welches mit dem Script verbunden ist (Zielscheibe)
              TreeColl.enabled = !TreeColl.enabled; // Collider wird ausgeschaltet, damit daran vorbeigegangen werden kann
            }

      }
}
