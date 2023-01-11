
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverscreen : MonoBehaviour
{
   

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

}
