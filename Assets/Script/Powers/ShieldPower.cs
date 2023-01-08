
using UnityEngine;

public class ShieldPower : MonoBehaviour
{
   

    private void Start()
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
