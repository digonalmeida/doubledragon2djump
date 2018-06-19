using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class CharacterSprite : MonoBehaviour {
    private Animator _Animator;
    private SpriteRenderer _SpriteRenderer;
    private int _lastDirection = 1;

    void Awake()
    {
        _Animator = GetComponent<Animator>();
        _SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PlayWalkingDownAnimation()
    {
        _Animator.Play(Animations.WalkingDown);
    }

    public void PlayWalkingUpAnimation()
    {
        _Animator.Play(Animations.WalkingUp);
    }

    public void PlayJumpingAnimation()
    {
        _Animator.Play(Animations.Jumping);
    }
    public void PlayIdleAnimation()
    {
        _Animator.Play(Animations.Idle);
    }
    public void SetXDirection(float direction)
    {
        direction = (Mathf.Approximately(direction, 0) ? 0 : Mathf.Sign(direction));
        if(direction != _lastDirection)
        {
            _lastDirection = (int) direction;
            if(direction != 0)
            {
                _SpriteRenderer.flipX = direction < 0;
            }
        }
    }

    private class Animations
    {
        public static int Idle = Animator.StringToHash("idle");
        public static int WalkingDown = Animator.StringToHash("walkingDown");
        public static int WalkingUp = Animator.StringToHash("walkingUp");
        public static int Jumping = Animator.StringToHash("jumping");
    }

}
