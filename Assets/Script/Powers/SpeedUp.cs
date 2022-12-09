using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 6);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Player 2")
        {

            Destroy(this.gameObject);
        }
    }

}
