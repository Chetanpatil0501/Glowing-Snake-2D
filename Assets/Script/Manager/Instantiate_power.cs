
using UnityEngine;

public class Instantiate_power : MonoBehaviour
{
    [Header("2X power spawn")]
    public GameObject _twoXpower; //For the prefab reference
    public float _twoXpowerSpawntime;

    [Header("SpeedUp power spawn")]
    public float _speedUpSpawntime;
    public GameObject _speedUpPrefab;       //For the prefab reference


    [Header("Shield power spawn")]
    public float _shieldSpawnTime;
    public GameObject _shieldprefab;        //For the prefab reference



    public Collider2D gridArea;
    
    

    private void Start()
    {
        _twoXpowerSpawntime = Random.Range(10, 15);
        _speedUpSpawntime = Random.Range(20, 25);
        _shieldSpawnTime = Random.Range(25, 35);
    }

    private void Update()
    {
        _twoXpowerSpawntime -= 1 * Time.deltaTime;
        _speedUpSpawntime -= 1 * Time.deltaTime;
        _shieldSpawnTime -= 1 * Time.deltaTime;

        if (_twoXpowerSpawntime <= 0 )
        {
            SpawnTwoX();
        }
        if (_speedUpSpawntime <= 0)
        {
            SpawnSpeedUp();
        }

        if (_shieldSpawnTime <= 0)
        {
            SpawnShield();
        }
    }


    void SpawnTwoX()
    {
        _twoXpowerSpawntime = Random.Range(10, 25);
        Bounds bounds = gridArea.bounds;

        // Pick a random position inside the bounds
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        // Round the values to ensure it aligns with the grid
        x = Mathf.Round(x);
        y = Mathf.Round(y);

        Vector2 spawn = new Vector2(x, y);

        Instantiate(_twoXpower, spawn, Quaternion.identity);
    }
    
    void SpawnSpeedUp()
    {
        _speedUpSpawntime = Random.Range(15, 35);
        Bounds bounds = gridArea.bounds;

        // Pick a random position inside the bounds
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        // Round the values to ensure it aligns with the grid
        x = Mathf.Round(x);
        y = Mathf.Round(y);

        Vector2 spawn = new Vector2(x, y);

        Instantiate(_speedUpPrefab, spawn, Quaternion.identity);
    }
    
    void SpawnShield()
    {
        _shieldSpawnTime = Random.Range(20, 35);
        Bounds bounds = gridArea.bounds;

        // Pick a random position inside the bounds
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        // Round the values to ensure it aligns with the grid
        x = Mathf.Round(x);
        y = Mathf.Round(y);

        Vector2 spawn = new Vector2(x, y);

        Instantiate(_shieldprefab, spawn, Quaternion.identity);
    }
   
}
