using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;
    private Transform aimGunEndPointTransform;
    private static int richtung;


    public Vector3 gunEndPointPosition;
    public GameObject Ball;
    private GameObject BallIns;
    public float BallSpeed;
    public Transform BallPoint;
    public float fireRate;
    float ReadyForNextShot;
    public float distance;
    public LayerMask WhatIsSolid;
    public float lifetime;
    bool shot = false;

    void Awake()

    {
        aimTransform = transform.Find("Aim");
        aimGunEndPointTransform = aimTransform.Find("GunEndPointPosition");
    }

    void Update()
    {

      richtung = PlayerMovement.Richtung();
      Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
      Vector3 aimDirection = (mousePosition - transform.position).normalized;
      if(richtung < 0){
        aimDirection.x = -aimDirection.x;
        mousePosition.x = -mousePosition.x;
        aimDirection.y = -aimDirection.y;
        mousePosition.y = -mousePosition.y;
        }

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x)* Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0,0,angle);

      if(Input.GetMouseButton(0))
      {
          if(Time.time > ReadyForNextShot )
          {
            ReadyForNextShot = Time.time + 1/fireRate;
            shoot();
            shot = true;
                if(richtung > 0){
                  Debug.DrawRay(BallIns.transform.position,BallIns.transform.right,Color.green);
                  RaycastHit2D hitRechts =Physics2D.Raycast(BallIns.transform.position,BallIns.transform.up,distance,WhatIsSolid);
                  if(hitRechts.collider != null){
                    if(hitRechts.collider.CompareTag("Enemy")){
                      Debug.Log("Rechts");
                      Destroy(BallIns);

                      }
                    }
                    }
                    else if(richtung < 0) {
                    Debug.DrawRay(BallIns.transform.position,-BallIns.transform.right,Color.green);
                    RaycastHit2D hitLinks = Physics2D.Raycast(BallIns.transform.position,-BallIns.transform.up,distance,WhatIsSolid);
                      if(hitLinks.collider != null){
                        if(hitLinks.collider.CompareTag("Enemy")){
                          Debug.Log("Links");
                          Destroy(BallIns);
                          }
                        }
                      }
                    }
                  }
                }


  void shoot(){

      if(richtung > 0){
      BallIns = Instantiate(Ball,BallPoint.position,BallPoint.rotation);
      BallIns.GetComponent<Rigidbody2D>().AddForce(BallIns.transform.right*BallSpeed);
          Destroy(BallIns,lifetime);
      }

      else if(richtung < 0){
      BallIns = Instantiate(Ball,BallPoint.position,BallPoint.rotation);
      BallIns.GetComponent<Rigidbody2D>().AddForce(BallIns.transform.right*BallSpeed*-1);
      Destroy(BallIns,lifetime);
      }

      }
  }
