using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFall : MonoBehaviour
{
      [SerializeField ]private Animator Tree;
      [SerializeField ]private GameObject TreeObject;
      Collider2D TreeColl;

    void Start()
    {
         TreeColl = TreeObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {

            if(coll.gameObject.CompareTag("ball") && changeTutorialText.tutorialFinished){
              Tree.Play("TreeFall");
              Destroy(gameObject);
              TreeColl.enabled = !TreeColl.enabled;
            }

      }
}
