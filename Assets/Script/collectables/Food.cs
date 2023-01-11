
using UnityEngine;

public class Food : MonoBehaviour
{

    public BoxCollider2D gridArea;
    public float timer = 10;

    private void Start()
    {
        RandomizePosition();
       
    }

    private void Update()
    {
        timer -= 1 * Time.deltaTime;

        if (timer <= 0)
        {
            RandomizePosition();
        }
    }

    public void RandomizePosition()
    {
        timer = 10;
       
        Bounds bounds = gridArea.bounds;

        // Pick a random position inside the bounds
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        // Round the values to ensure it aligns with the grid
        x = Mathf.Round(x);
        y = Mathf.Round(y);

        transform.position = new Vector2(x, y);
       


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        RandomizePosition();
    }

   
}
