using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    
    private bool _shieldOn;

    [SerializeField] float speed;
    [SerializeField] GameObject _gameoverScreen;
    [SerializeField] GameObject _player_won_text;
    [SerializeField] GameObject _speedUptext;
    [SerializeField] GameObject _shieldOntext;
    [SerializeField] GameObject _shieldOfftext;
    [SerializeField] Transform _segmentPrefab;

   public List<Transform> _BodySegment;

   public virtual void Initialization()
    {
        _speedUptext.SetActive(false);
        _shieldOntext.SetActive(false);
        _shieldOfftext.SetActive(false);
        _BodySegment = new List<Transform>();
        _BodySegment.Add(transform);
    }

   public virtual void Player1Movement() {
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

   public virtual void Player2Movement() {
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

    public virtual void AddSegments() {
        for (int i = _BodySegment.Count - 1; i > 0; i--)
        {
            _BodySegment[i].position = _BodySegment[i - 1].position;
        }
        transform.position = new Vector3(Mathf.Round(transform.position.x + _direction.x), Mathf.Round(transform.position.y + _direction.y), 0.0f);
    }
    
    public virtual void Grow() {
        Transform segment = Instantiate(this._segmentPrefab);
        segment.position = _BodySegment[_BodySegment.Count - 1].position;
        _BodySegment.Add(segment);
    }

    public virtual void Shrink()
    {
        if (_BodySegment.Count > 4)
        {
            Destroy(_BodySegment[_BodySegment.Count - 1].gameObject);
            _BodySegment.RemoveAt(_BodySegment.Count - 1);
        }
       
    }
    public virtual void CoolDownSpeed() {
        if (Time.timeScale > 1f)
        {
            Time.timeScale -= 1f * Time.deltaTime;
            Time.timeScale = Mathf.Clamp(speed, 1f, 1.5f);
        }
        _speedUptext.SetActive(false);
    }

    public virtual void ShieldDisable()
    {
        _shieldOn = false;
        _shieldOntext.SetActive(false);
        _shieldOfftext.SetActive(true);
        Invoke("Awake", 3f);
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Grow();
            SoundManager._instance.FoodSoundFX();
        }

        if (collision.tag == "MassBurner")
        {
            Shrink();
        }

        else if (collision.tag == "Body" || collision.tag == "Body 2")
        {

            if (_shieldOn == false)
            {


                Time.timeScale = 0;

                _gameoverScreen.SetActive(true);

                _player_won_text.SetActive(true);


            }
        }

        if (collision.tag == "SpeedUp")
        {
            SoundManager._instance.PowerSoundFX();
            Time.timeScale = 1.5f;
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
}




