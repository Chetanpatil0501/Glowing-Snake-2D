
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Snake_movement : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    public float speed;
    private bool _shieldOn;
    Score score_component;
    public GameObject _gameoverScreen;
    public GameObject _speedUptext;
    public GameObject _shieldOntext;
    public GameObject _shieldOfftext;
    public TextMeshProUGUI _score_text;
    public Transform _segmentPrefab;




    List<Transform> _BodySegment;

    private void Awake()
    {
        _speedUptext.SetActive(false);
        _shieldOntext.SetActive(false);
        _shieldOfftext.SetActive(false);
        score_component = GetComponent<Score>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _BodySegment = new List<Transform>();
        _BodySegment.Add(transform);

        score_component = GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_direction != Vector2.down)
            {
                _direction = Vector2.up;
            }

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (_direction != Vector2.up)
            {
                _direction = Vector2.down;
            }

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (_direction != Vector2.right)
            {
                _direction = Vector2.left;
            }

        }
        else if (Input.GetKeyDown(KeyCode.D))
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

                _score_text.text = "Your score : " + score_component._score.ToString();
            }
        }

        if (collision.tag == "SpeedUp")
        {
            SoundManager._instance.PowerSoundFX();
            //Time.timeScale = 1.5f;
            speed = 10;
            Invoke("CoolDownSpeed", 6);
            _speedUptext.SetActive(true);
        }

        if (collision.tag == "Shield")
        {
            SoundManager._instance.PowerSoundFX();
            _shieldOn = true;
            _shieldOntext.SetActive(true);
            Invoke("ShieldDisable", 10);
        }
    }


    private void CoolDownSpeed()
    {
        if (Time.timeScale > 1f)
        {
           Time.timeScale -= 1f * Time.deltaTime;
           Time.timeScale = Mathf.Clamp(speed, 1f, 1.5f);
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
