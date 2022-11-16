using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Player_movement : MonoBehaviour
{
    public float speed = 5.5f;
    public float jumpforce = 2f;
    private float horizontal;
    private Transform playerTransform;
    private Rigidbody2D rb;
    public Animator animatronix;
    public Bomb bomb;
    public GameManager gamemanager;
    private AudioManager sfxManager;
    


    public PlayableDirector director;


    private void Awake() {
        
        rb = GetComponent<Rigidbody2D>();
        animatronix = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<AudioManager>();
        


    }
 
    //Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        
         if (horizontal == 1)
        {   
            playerTransform.rotation = Quaternion.Euler(0, 0, 0);
            animatronix.SetBool("run", true);
        }      
        else if (horizontal == -1)
        {
            playerTransform.rotation = Quaternion.Euler(0, 180, 0);
            animatronix.SetBool("run", true);
        }
        else 
        {
            animatronix.SetBool("run", false);
        }

        if(Input.GetButtonDown("Jump") && groundchecker.isGrounded)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            animatronix.SetBool("jump", true);
        }
        
        
    }
     void FixedUpdate() {

        
        //la velocidad del Rigidbody es un vector que en el eje X, mueves en horizontal dependiendo de la velocidad(multiplica)
        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);    

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)  
        {

             gamemanager.bombahit(other.gameObject); 
             gamemanager.restarvida(this.gameObject);
             sfxManager.touchbomb();
            
        }
        if(other.gameObject.layer == 7)
        {

            Destroy(this.gameObject);
            Debug.Log("Caiste al vacio");
            sfxManager.deathcharacter();
            gamemanager.muerte(this.gameObject);

        }
         if(other.gameObject.layer == 8)
        {
            
           
            gamemanager.cogerestrellas(other.gameObject, this.gameObject);
            Debug.Log("Conseguiste una estrella");

        }
        
    }  
    

        
    

    
    
   
} 