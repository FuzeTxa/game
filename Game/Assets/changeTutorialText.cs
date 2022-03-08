using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class changeTutorialText : MonoBehaviour
{


      public TextMeshPro Text;
      int text;
      public static bool tutorialFinished;

    void Start()
    {
      text = 0;
    }

    // Update is called once per frame
    void Update(){


      if(text == 1){
      Text.text = "Left Click to Shoot";
      }

      if(text == 3){
      Text.text = "If you hit an Enemy the Ball flies back to you";
      }
    else if(text == 5){
      Text.text = "You can hit the ball back by pressing the Right Mouse Button while the ball is in your range";
    }
    else if(text == 7){
      Text.text = "While doing this, you build up a combo";
    }
    else if(text == 9){
      Text.text = "The higher your combo gets the stronger your hits are";
    }
    else if(text == 11){
      Text.text = "The circle above your head tells you wheter you have the ball or not";
    }
    else if(text == 13){
      Text.text = "Press E to retrieve the ball ";
        tutorialFinished = true;
        text = -1;
    }

}

    private void OnCollisionEnter2D(Collision2D coll)
    {

            if(coll.gameObject.CompareTag("ball")){
              text++;
            }



            }

      }
