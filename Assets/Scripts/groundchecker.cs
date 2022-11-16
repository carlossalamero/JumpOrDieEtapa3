using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundchecker : MonoBehaviour
{
     public static bool isGrounded;
     public Player_movement player;
     

    void Awake()
    {
         player = GameObject.Find("knight").GetComponent<Player_movement>();
         
    }

     void OnTriggerStay2D(Collider2D col)
    {
         if(col.gameObject.tag == "Ground")
         {
          isGrounded = true;
          player.animatronix.SetBool("jump", false);
        }
        
    }

    void OnTriggerExit2D(Collider2D col)

    {
         isGrounded = false;
    }
}
