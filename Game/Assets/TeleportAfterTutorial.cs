using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAfterTutorial : MonoBehaviour
{


    [SerializeField] private GameObject camera; // GameObject "camera" wird hineinbezogen
    [SerializeField] private GameObject player; // GameObject "player" wird hineinbezogen



    void Start() // wird bei Start ausgeführt
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D coll) // Wenn etwas mit dem folgenden kollidiert, dann...
    {

            if(coll.gameObject.CompareTag("player")){ // Wenn das kollidierende Objekt den Tag (player)  hat, dann...
              camera.transform.position = new Vector3(-3.53f,11f,-10f); // verschiebe Kameraposition X/Y/Z auf eingetragene Werte
              player.transform.position = new Vector2(6.26f,8.26f); // verschiebe Spieler X/Y auf eingetragene Werte

            }

      }
}
