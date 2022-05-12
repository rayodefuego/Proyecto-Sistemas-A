using Godot;
using System;

public class Player : KinematicBody2D
{
    [Export] private float jumpForce;

    private float _yVelocity;

    private float _gravityAceleration = 9.81f;

    private bool jumping = false;

    private Vector2 _yForce;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public override void _PhysicsProcess(float delta)
    {
        _yVelocity += _gravityAceleration * delta;
        _yForce = new Vector2(0, _yVelocity);

        KinematicCollision2D colision = MoveAndCollide(_yForce);

        if (Input.IsActionJustPressed("jump") && !jumping)
        {
            _yVelocity = -jumpForce;
            GD.Print("saltar");
            jumping = true;
        }
        
        if(colision != null)
        {
            jumping = false;
        }
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
