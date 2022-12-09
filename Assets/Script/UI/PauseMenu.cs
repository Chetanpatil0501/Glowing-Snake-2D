using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuObject;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseMenuObject.SetActive(true);
            Time.timeScale = 0f;
        }  
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PauseMenuObject.SetActive(false);
        SoundManager.instance.ButtonClickFX();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        SoundManager.instance.ButtonClickFX();
    }
}
