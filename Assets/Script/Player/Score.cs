
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI _score_text;
    public GameObject _twoXTextobject;
    public float _score;
    float _twoXScore;

    

    private void Start()
    {
        _score = 0f;
        _twoXScore = 1f;
        _twoXTextobject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            _score += 10f * _twoXScore;
            _score_text.text = "Score: " + _score.ToString();
        }


        if (collision.tag == "2xFood")
        {
            _twoXScore = 2f;
            Invoke("ResetPower", 10);
            _twoXTextobject.SetActive(true);
            Invoke("GameobejectHandler", 1.5f);
        }
    }

    private void ResetPower()
    {
        _twoXScore = 1f;
    }

    void GameobejectHandler()
    {
        _twoXTextobject.SetActive(false);
    }
}
