using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_power : MonoBehaviour
{
    [Header("2X power spawn")]
    public GameObject TwoXpower;
    public float TwoXSpawnTime;

    [Header("SpeedUp power spawn")]
    public float SpeedUpSpawnTime;
    public GameObject SpeedUpprefab;
    
    
    [Header("Shield power spawn")]
    public float ShieldSpawnTime;
    public GameObject Shieldprefab;



    public Collider2D gridArea;
    
    

    private void Start()
    {
        TwoXSpawnTime = Random.Range(10, 15);
        SpeedUpSpawnTime = Random.Range(20, 25);
        ShieldSpawnTime = Random.Range(25, 35);
    }

    private void Update()
    {
        TwoXSpawnTime -= 1 * Time.deltaTime;
        SpeedUpSpawnTime -= 1 * Time.deltaTime;
        ShieldSpawnTime -= 1 * Time.deltaTime;

        if (TwoXSpawnTime <= 0 )
        {
            SpawnTwoX();
        }
        if (SpeedUpSpawnTime <= 0)
        {
            SpawnSpeedUp();
        }

        if (ShieldSpawnTime <= 0)
        {
            SpawnShield();
        }
    }


    void SpawnTwoX()
    {
        TwoXSpawnTime = Random.Range(10, 25);
        Bounds bounds = gridArea.bounds;

        // Pick a random position inside the bounds
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        // Round the values to ensure it aligns with the grid
        x = Mathf.Round(x);
        y = Mathf.Round(y);

        Vector2 spawn = new Vector2(x, y);

        Instantiate(TwoXpower, spawn, Quaternion.identity);
    }
    
    void SpawnSpeedUp()
    {
        SpeedUpSpawnTime = Random.Range(15, 35);
        Bounds bounds = gridArea.bounds;

        // Pick a random position inside the bounds
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        // Round the values to ensure it aligns with the grid
        x = Mathf.Round(x);
        y = Mathf.Round(y);

        Vector2 spawn = new Vector2(x, y);

        Instantiate(SpeedUpprefab, spawn, Quaternion.identity);
    }
    
    void SpawnShield()
    {
        ShieldSpawnTime = Random.Range(20, 35);
        Bounds bounds = gridArea.bounds;

        // Pick a random position inside the bounds
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        // Round the values to ensure it aligns with the grid
        x = Mathf.Round(x);
        y = Mathf.Round(y);

        Vector2 spawn = new Vector2(x, y);

        Instantiate(Shieldprefab, spawn, Quaternion.identity);
    }
   
}
