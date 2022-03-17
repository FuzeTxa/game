using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiRange : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;    // GameObjekt auswählen um danach darauf zuzugreifen
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D coll){      // wenn ein anderer Collider mit diesem Collider kollidiert, mach:
      if(coll.gameObject.tag == "player"){      // wenn das GameObject welches kollidiert, den Tag player hat mach:
        Enemy.GetComponent<Ai>().shootPlayer(); // shootPlayer Methode des AI scriptes ausführen
      }
      }
}
