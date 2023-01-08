
using System.Collections.Generic;
using UnityEngine;

public class Snake_2_move : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    public float _speed;
    private bool _shieldOn;
    public GameObject _gameoverScreen;
    public GameObject _player_1_won_text;
    public GameObject _speedUptext;
    public GameObject _shieldOntext;
    public GameObject _shieldOfftext;
    public Transform _segmentPrefab;




    List<Transform> _BodySegment;

    private void Awake()
    {
        _speedUptext.SetActive(false);
        _shieldOntext.SetActive(false);
        _shieldOfftext.SetActive(false);
      
    }

    // Start is called before the first frame update
    void Start()
    {
        _BodySegment = new List<Transform>();
        _BodySegment.Add(transform);
       
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_direction != Vector2.down)
            {
                _direction = Vector2.up;
            }

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (_direction != Vector2.up)
            {
                _direction = Vector2.down;
            }

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_direction != Vector2.right)
            {
                _direction = Vector2.left;
            }

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_direction != Vector2.left)
            {
                _direction = Vector2.right;
            }
        }

    }


    private void FixedUpdate()
    {
        for (int i = _BodySegment.Count - 1; i > 0; i--)
        {
            _BodySegment[i].position = _BodySegment[i - 1].position;
        }
        transform.position = new Vector3(Mathf.Round(transform.position.x + _direction.x), Mathf.Round(transform.position.y + _direction.y), 0.0f);
    }

    private void Grow()
    {
        Transform segment = Instantiate(this._segmentPrefab);
        segment.position = _BodySegment[_BodySegment.Count - 1].position;
        _BodySegment.Add(segment);
    }

   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Grow();
            SoundManager._instance.FoodSoundFX();
        }

        else if (collision.tag == "Body" || collision.tag == "Body 2")
        {

            if (_shieldOn == false)
            {

                Time.timeScale = 0;
                _gameoverScreen.SetActive(true);
                
            
                    _player_1_won_text.SetActive(true);
                
            }
        }

        if (collision.tag == "SpeedUp")
        {
            Time.timeScale = 1.5f; ;
            Invoke("CoolDownSpeed", 6);
            _speedUptext.SetActive(true);
            SoundManager._instance.PowerSoundFX();
        }

        if (collision.tag == "Shield")
        {
            _shieldOn = true;
            _shieldOntext.SetActive(true);
            Invoke("ShieldDisable", 10);
            SoundManager._instance.PowerSoundFX();
        }
    }


    private void CoolDownSpeed()
    {
        if (Time.timeScale > 1f)
        {
           Time.timeScale -= 1f * Time.deltaTime;
           Time.timeScale = Mathf.Clamp(_speed, 1f, 1.5f);
        }
        _speedUptext.SetActive(false);
    }

    private void ShieldDisable()
    {

        _shieldOn = false;
        _shieldOntext.SetActive(false);
        _shieldOfftext.SetActive(true);
        Invoke("Awake", 3f);
    }
    

}
