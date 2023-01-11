using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    [SerializeField] Score _score;
    [SerializeField] TextMeshProUGUI _finalscore;
    private void Start()
    {
        _finalscore.text = "Your final score: " + _score._score.ToString();
    }
}
