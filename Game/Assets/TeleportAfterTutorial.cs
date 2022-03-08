using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAfterTutorial : MonoBehaviour
{


    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject player;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {

            if(coll.gameObject.CompareTag("player")){
              camera.transform.position = new Vector3(-3.53f,11f,-10f);
              player.transform.position = new Vector2(6.26f,8.26f);

            }

      }
}
