using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Snake_1_move : MonoBehaviour
{
    private Vector2 _Direction = Vector2.right;
    public float speed;
    private bool ShieldOn;
    public GameObject GameoverScreen;
    public GameObject Player_2_won;
    public GameObject SpeedUptext;
    public GameObject ShieldOntext;
    public GameObject ShieldOfftext;
    public Transform SegmentPrefab;




    List<Transform> _BodySegment;

    private void Awake()
    {
        SpeedUptext.SetActive(false);
        ShieldOntext.SetActive(false);
        ShieldOfftext.SetActive(false);
    
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



        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_Direction != Vector2.down)
            {
                _Direction = Vector2.up;
            }

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (_Direction != Vector2.up)
            {
                _Direction = Vector2.down;
            }

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (_Direction != Vector2.right)
            {
                _Direction = Vector2.left;
            }

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (_Direction != Vector2.left)
            {
                _Direction = Vector2.right;
            }
        }

    }


    private void FixedUpdate()
    {
        for (int i = _BodySegment.Count - 1; i > 0; i--)
        {
            _BodySegment[i].position = _BodySegment[i - 1].position;
        }
        transform.position = new Vector3(Mathf.Round(transform.position.x + _Direction.x), Mathf.Round(transform.position.y + _Direction.y), 0.0f);
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.SegmentPrefab);
        segment.position = _BodySegment[_BodySegment.Count - 1].position;
        _BodySegment.Add(segment);
    }

   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Grow();
            SoundManager.instance.FoodSoundFX();
        }

        else if (collision.tag == "Body" || collision.tag == "Body 2")
        {

            if (ShieldOn == false)
            {


                Time.timeScale = 0;

                GameoverScreen.SetActive(true); 
               
                Player_2_won.SetActive(true);
                
             
            }
        }

        if (collision.tag == "SpeedUp")
        {
            SoundManager.instance.PowerSoundFX();
            Time.timeScale = 1.5f; ;
            Invoke("CoolDownSpeed", 6);
            SpeedUptext.SetActive(true);
        }

        if (collision.tag == "Shield")
        {
            SoundManager.instance.PowerSoundFX();
            ShieldOn = true;
            ShieldOntext.SetActive(true);
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
        SpeedUptext.SetActive(false);
    }

    private void ShieldDisable()
    {

        ShieldOn = false;
        ShieldOntext.SetActive(false);
        ShieldOfftext.SetActive(true);
        Invoke("Awake", 3f);
    }
    

}
