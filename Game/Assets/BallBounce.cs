using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    // Variablen werden definiert
    public static Rigidbody2D rb;
    Vector3 LastVelocity;
    GameObject player;

    Transform playerTransform;


    [SerializeField]
    public float fireForce;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();           // greife auf den Körper des mit dem Script verbundenen Objekts zu
        player = GameObject.FindWithTag("player");
         playerTransform = player.transform;


    }

    void Update()
    {
        if(rb != null){                 // während der Ball einen Körper hat (existiert) mach:
        LastVelocity = rb.velocity;     // definiert die Geschwindigkeit des Körpers als LastVelocity

        if(rb.velocity.x == 0 || rb.velocity.y == 0){     // wenn die Geschwindigkeit des Körpers null ist mach:
         Destroy(gameObject);                             // vernichte den Körper
      }
}
    }

    private void OnCollisionEnter2D(Collision2D coll)       // wenn etwas mit dem Collider dieses Objekts kollidiert mach:
    {
          Vector3 collPoint = coll.contacts[0].point;       // definiere den Orts Vektor wo das Objekt kollidiert ist als collPoint
      if(coll.gameObject.CompareTag("Enemy")){              // wenn das Objekt welches kollidiert ist den Tag Enemy hat, mach:

        var directionToPlayer = playerTransform.position - collPoint;   // rechnet den Richtungsvektor vom collPoint zum Spieler aus
        rb.velocity = (directionToPlayer.normalized * fireForce);       // "schießt" den Ball in die Richtung des eben erechneten Vektor (aber diesmal ist der Vektor normalisiert)
        rb.gravityScale = 0;

      }
      if(coll.gameObject.CompareTag("Environment")){         // wenn das Objekt welches kollidiert ist den Tag Environment hat, mach:

                var speed = LastVelocity.magnitude;         // rechnet die Länge des LastVelocity Vektors aus
                var direction = Vector3.Reflect(LastVelocity.normalized,coll.contacts[0].normal);   // erstellt neuen Vektor, welcher den LastVelocity Vektor reflektiert
                var directionToPlayer = playerTransform.position - transform.position;      // neuer Richtungsvektor vom Ball zum Spieler

                var direction2 = Vector3.Lerp(direction, directionToPlayer, 0);

                rb.velocity= direction2 * Mathf.Max(speed/3,0f);
                rb.gravityScale = 1;          // setzt die Gravitation des Körpers auf 1 (zuvor 0)
      }
    }
}
