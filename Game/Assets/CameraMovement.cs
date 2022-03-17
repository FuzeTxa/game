using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{ // definiert Variablen
  public Transform target;
  public Vector3 offset;
  [Range(1,10)]
  public float smoothFactor;

  private void FixedUpdate(){
    Follow(); // führt Methode "follow" aus
  }

  void Follow()
  {
      Vector3 targetPos = target.position + offset; // Ein neuer Vektor namens "targetPos" wird definiert, welcher der Ortsvektor vom zuvor definierten Variable "target" ist
      Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothFactor*Time.fixedDeltaTime);
      transform.position = targetPos; // Die Position vom Vektor 3 wird verändert durch die Multiplikation von "smoothFactor" und "Time.fixedDeltaTime"
  }
}
