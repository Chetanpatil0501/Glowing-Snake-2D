using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI Score_text;
    public GameObject TwoXTextobject;
   public float _score;
    float TwoXScore;

    

    private void Start()
    {
        _score = 0f;
        TwoXScore = 1f;
        TwoXTextobject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            _score += 10f * TwoXScore;
            Score_text.text = "Score: " + _score.ToString();
        }


        if (collision.tag == "2xFood")
        {
            TwoXScore = 2f;
            Invoke("ResetPower", 10);
            TwoXTextobject.SetActive(true);
            Invoke("GameobejectHandler", 1.5f);
        }
    }

    private void ResetPower()
    {
        TwoXScore = 1f;
    }

    void GameobejectHandler()
    {
        TwoXTextobject.SetActive(false);
    }
}
