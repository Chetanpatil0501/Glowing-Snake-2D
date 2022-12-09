using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance = null;
    AudioSource Audio;
    [Header("UI Sound FX")]
    [SerializeField] AudioClip ButtonCLickclip;
    [SerializeField] AudioClip GameOver;


    [Header("Interactables Sound Fx")]
    [SerializeField] AudioClip PowerSFX;
    [SerializeField] AudioClip FoodSFX;


    public static SoundManager instance
    {
        get
        {

            if (_instance == null)
            {
                _instance = (SoundManager)FindObjectOfType(typeof(SoundManager));

            }
            return _instance;

        }
    }
    private void Start()
    {
        Audio = GetComponent<AudioSource>();
        if (instance == this)
        {
            DontDestroyOnLoad(gameObject);
        }

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


