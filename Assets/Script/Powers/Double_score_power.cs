using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double_score_power : MonoBehaviour
{ 
    private void Update()
    {
        Destroy(gameObject, 6);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PowerSoundFX();
            Destroy(this.gameObject);
        }
        if (collision.tag == "Player 2")
        {
            SoundManager.instance.PowerSoundFX();
            Destroy(this.gameObject);
        }
    }
}
