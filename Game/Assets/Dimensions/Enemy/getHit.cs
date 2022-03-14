using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getHit : MonoBehaviour
{

    [SerializeField] private Animator animator;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D coll)
    {

            if(coll.gameObject.CompareTag("ball")){

              animator.SetBool("shoot", true);
              StartCoroutine(endAnim());
    }

  }

      private IEnumerator endAnim()
      {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("shoot", false);
    }
}
