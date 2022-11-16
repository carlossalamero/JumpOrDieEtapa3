using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    
    public Animator bombanimatronix;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        
        bombanimatronix = GetComponent<Animator>();

    }

    // Update is called once per frame
    public void bombahit(GameObject bomba)
    {

        bombanimatronix.SetBool("bombexplosion", true);
        StartCoroutine(GameObject.Find("Main Camera").GetComponent<CameraShake>().Shake(2f, 0.06f));
        Destroy(this.gameObject, 1f);
        
    }
     
}
