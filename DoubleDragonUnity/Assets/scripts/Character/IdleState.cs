using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State {

    public IdleState(Character character)
    {
        _Character = character;
    }

    private Character _Character;
    private Vector2 _DeltaPos = new Vector2();

    public override void Enter()
    {
        base.Enter();
        _Character.Sprite.PlayIdleAnimation();
    }

    public override void Update()
    {
        base.Update();
        if (_Character.Input.Jumping)
        {
            _Character.StateMachine.SetState(_Character.States.jumpingState);
        }
        else
        {
            DoMovement();
            UpdateAnimation();
        }
    }

    private void DoMovement()
    {
        _DeltaPos = _Character.Input.Direction * _Character.Stats.Speed * Time.deltaTime;
        _Character.Move(_DeltaPos);
    }

    private void UpdateAnimation()
    {
        if (_DeltaPos.sqrMagnitude == 0)
        {
            _Character.Sprite.PlayIdleAnimation();
        }
        else
        {
            if (_DeltaPos.y > 0)
            {
                _Character.Sprite.PlayWalkingUpAnimation();
            }
            else
            {
                _Character.Sprite.PlayWalkingDownAnimation();
            }
        }
    }


}
