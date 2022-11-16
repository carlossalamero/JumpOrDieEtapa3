using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private AudioManager sfxManager;
    private BgmManager bgmManager;
    private MenuManager menuManager;
    private Player_movement knight;
    private Animator bombanimator;
    private Animator staranimator;
    private BoxCollider2D bombcollider;

    public GameObject[] hearts;
    public GameObject victoria;
    public GameObject derrota;
    int contestrellas;

    public Text numstars;
    
   
    // Start is called before the first frame update
    void Awake()
    {

        sfxManager = GameObject.Find("SFXManager").GetComponent<AudioManager>();
        bgmManager = GameObject.Find("BGMManager").GetComponent<BgmManager>();
        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        knight = GameObject.Find("knight").GetComponent<Player_movement>();
        
        
    }
    void Start() 
    {

        victoria.SetActive(false);
        derrota.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bombahit(GameObject bomba)
    {
        bombanimator = bomba.GetComponent<Animator>();
        bombcollider = bomba.GetComponent<BoxCollider2D>();

        bombanimator.SetBool("explosion", true);
        StartCoroutine(GameObject.Find("Main Camera").GetComponent<CameraShake>().Shake(2f, 0.06f));
        bombcollider.enabled = false;
        Destroy(bomba, 0.3f);

        
    }
    public void cogerestrellas(GameObject estrella, GameObject character)
    {

        staranimator = estrella.GetComponent<Animator>();        

        contestrellas = contestrellas + 1;
        Debug.Log("Conseguiste " +contestrellas+ " estrellas");

        if(contestrellas == 10)
        {

            ganar(character);
            SceneManager.LoadScene(0);

        }
        
        Destroy(estrella.gameObject);
        numstars.text = contestrellas.ToString();
        sfxManager.catchastar();


    }
    public void muerte(GameObject character)
    {

        derrota.SetActive(true);
        sfxManager.deathcharacter();
        Destroy(character, 0.3f);
        SceneManager.LoadScene(0);

    }

    public void restarvida(GameObject character)
    {

        Global.vidas--;

        if(Global.vidas == 0)
        {

            muerte(character); 
            hearts[0].SetActive(false);
            Debug.Log("Moriste");

        }
        if(Global.vidas == 1)
        {

            hearts[1].SetActive(false);
            Debug.Log("te queda 1 vida");

        }
        if(Global.vidas == 2)
        {

            hearts[2].SetActive(false);
            Debug.Log("te quedan 2 vidas");

        }


    }

    void ganar(GameObject character)
    {

        victoria.SetActive(true);
        Destroy(character, 0.3f);

        
    }  
}
