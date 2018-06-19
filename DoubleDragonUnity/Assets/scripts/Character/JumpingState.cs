using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : State {
    public JumpingState(Character character)
    {
        _Character = character;
        
    }

    private Character _Character;
    private float _JumpStartYPosition = 0;
    private Vector2 _Velocity = new Vector2();
    private Vector2 _DeltaPos = new Vector2();

    public override void Enter()
    {
        base.Enter();
        _Velocity.x = _Character.Input.Direction.x;
        _Velocity.y = _Character.Stats.JumpForce;
        _JumpStartYPosition = _Character.transform.position.y;
        _Character.Sprite.PlayJumpingAnimation();
    }

    public override void Update()
    {
        base.Update();
        _Velocity.y -= _Character.Stats.JumpGravity * Time.deltaTime;
        _DeltaPos = _Velocity * Time.deltaTime;
        _Character.Move(_DeltaPos);

        Vector3 charPosition = _Character.transform.position;
        if (charPosition.y <= _JumpStartYPosition && _Velocity.y <= 0)
        {
            charPosition.y = _JumpStartYPosition;
            _Character.transform.position = charPosition;
            _Character.StateMachine.SetState(_Character.States.idleState);
        }
    }



}
