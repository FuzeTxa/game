using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiRange : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D coll){
      if(coll.gameObject.tag == "player"){
        Enemy.GetComponent<Ai>().shootPlayer();
      }
      }
}
