
using UnityEngine;

public class Double_score_power : MonoBehaviour
{ 
   
    private void Start()
    {
        Destroy(gameObject, 6);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager._instance.PowerSoundFX();
            Destroy(this.gameObject);
        }
        if (collision.tag == "Player 2")
        {
            SoundManager._instance.PowerSoundFX();
            Destroy(this.gameObject);
        }
    }
}
