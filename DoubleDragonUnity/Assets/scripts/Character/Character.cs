using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public CharacterStats Stats = new CharacterStats();

    #region Class Data
    public CharacterStates States { get; private set; }
    public CharacterInput Input { get; private set; }
    #endregion

    #region Components

    public FiniteStateMachine StateMachine { get; private set; }
    public CharacterSprite Sprite { get; private set; }

    #endregion

    #region Unity Methods
    void Awake()
    {
        Sprite = GetComponentInChildren<CharacterSprite>();
        Input = new CharacterInput();
        StateMachine = new FiniteStateMachine();
        States = new CharacterStates();
        States.idleState = new IdleState(this);
        States.jumpingState = new JumpingState(this);
    }

    void Start()
    {
        StateMachine.SetState(States.idleState);
    }
    
    void Update()
    {
        Input.Update();
        StateMachine.Update();
    }

    #endregion

    public void Move(Vector2 deltaPos)
    {
        transform.position += (Vector3)deltaPos;
        Sprite.SetXDirection(deltaPos.x);
    }

    #region DataClasses
    
    [System.Serializable]
    public class CharacterInput
    {
        public Vector2 Direction;
        public bool Jumping;

        public void Update()
        {
            Direction.x = UnityEngine.Input.GetAxisRaw("Horizontal");
            Direction.y = UnityEngine.Input.GetAxisRaw("Vertical");
            Jumping = UnityEngine.Input.GetButtonDown("Jump");
        }
    }

    [System.Serializable]
    public class CharacterStates
    {
        public State idleState;
        public State jumpingState;
    }

    [System.Serializable]
    public class CharacterStats
    {
        public float Speed = 1;
        public float JumpForce = 3;
        public float JumpGravity = 10;
    }
    #endregion
}
