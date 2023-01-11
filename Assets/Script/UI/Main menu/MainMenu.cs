using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void StartButton()
    {
        SceneManager.LoadScene(1);
        SoundManager._instance.ButtonClickFX();
    }

    public void CoOPSnake()
    {
        SceneManager.LoadScene(2);
        SoundManager._instance.ButtonClickFX();
    }

    public void Quit()
    {
        Application.Quit();
        SoundManager._instance.ButtonClickFX();
    }
}
