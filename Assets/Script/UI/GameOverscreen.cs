
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverscreen : MonoBehaviour
{
    //private Score score;

    //private void Start()
    //{
    //    score = GetComponent<Score>();
    //}





    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

}
