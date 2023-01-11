using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : PlayerController
{
  
    //public Player1 player1;
    // Start is called before the first frame update
    private void Awake()
    {
       base.Initialization();

    }

    // Update is called once per frame
    void Update()
    {
        base.Player1Movement();
    }

    private void FixedUpdate()
    {
        AddSegments();
    }


    public override void AddSegments()
    {
        base.AddSegments();
    }

    public override void CoolDownSpeed()
    {
        base.CoolDownSpeed();
    }

    public new void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    public override void Grow()
    {
        base.Grow();
    }

    public override void ShieldDisable()
    {
        base.ShieldDisable();
    }

    public override void Shrink()
    {
        base.Shrink();
    }

}
