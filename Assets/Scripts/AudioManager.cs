using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private AudioSource _audioSource;
    public AudioClip deathcharacterSFX;
    public AudioClip hurtSFX;
    public AudioClip starSFX;
    public AudioClip bombSFX;
    public AudioClip lifeSFX;
    
    // Start is called before the first frame update
    void Awake()
    {
         _audioSource = GetComponent<AudioSource>();
    }

    public void deathcharacter()
   {
       _audioSource.PlayOneShot(deathcharacterSFX);
   }

   public void hurt()
   {
       _audioSource.PlayOneShot(hurtSFX);
   }

   public void catchastar()
   {
       _audioSource.PlayOneShot(starSFX);
   }

   public void touchbomb()
   {
       _audioSource.PlayOneShot(bombSFX);
   }
}