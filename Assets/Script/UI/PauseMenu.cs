
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject _pauseMenuObject;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            _pauseMenuObject.SetActive(true);
            Time.timeScale = 0f;
        }  
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        _pauseMenuObject.SetActive(false);
        SoundManager._instance.ButtonClickFX();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        SoundManager._instance.ButtonClickFX();
    }
}
