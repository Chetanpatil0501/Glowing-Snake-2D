using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   
    AudioSource Audio;
    [Header("UI Sound FX")]
    [SerializeField] AudioClip ButtonCLickclip;
    [SerializeField] AudioClip GameOver;


    [Header("Interactables Sound Fx")]
    [SerializeField] AudioClip PowerSFX;
    [SerializeField] AudioClip FoodSFX;

    private static SoundManager instance = null;
    public static SoundManager _instance
    {
        get
        {

            if (instance == null)
            {
                instance = (SoundManager)FindObjectOfType(typeof(SoundManager));

            }
            return instance;

        }
    }
    private void Start()
    {
        Audio = GetComponent<AudioSource>();

        DontDestroyOnLoad(gameObject);
            

    }

    public void ButtonClickFX()
    {
        Audio.PlayOneShot(ButtonCLickclip);
    }

    public void GameOverFX()
    {
        Audio.PlayOneShot(GameOver);
    }



    #region Inractables Fx

    public void PowerSoundFX()
    {
        Audio.PlayOneShot(PowerSFX);
    }
    public void FoodSoundFX()
    {
        Audio.PlayOneShot(FoodSFX);
    }
    #endregion

}


