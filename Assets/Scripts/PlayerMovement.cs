using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    #region Variables   
    public float MoveSmoothTime;
    public float GravityStrength;
    public float JumpStrength;
    public float WalkSpeed;
    public float RunSpeed; 

    private CharacterController Controller;
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDampVelocity; 
    private Vector3 CurrentForceVelocity;
    #endregion

    #region Unity Methods
    private void Start()
    {      
        Controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        PlayerJump();
    }
    #endregion

    #region Movement Methods
    // gets the player input and then moves the player
    private void PlayerMovement(){
        Vector3 PlayerInput = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")    
        };

        if (PlayerInput.magnitude > 1f)
        {
            PlayerInput.Normalize();
        }

        Vector3 MoveVector = transform.TransformDirection(PlayerInput); 
        float CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : WalkSpeed;

        CurrentMoveVelocity = Vector3.SmoothDamp(
            CurrentMoveVelocity,
            MoveVector * CurrentSpeed,
            ref MoveDampVelocity,
            MoveSmoothTime
        );

        Controller.Move(CurrentMoveVelocity * Time.deltaTime);
    }

    // allows the player to jump
    private void PlayerJump(){
        Ray groundCheckRay = new Ray (transform.position, Vector3.down);
        if (Physics.Raycast(groundCheckRay, 1.25f))
        {
            CurrentForceVelocity.y = -2f;

            if (Input.GetKey(KeyCode.Space))
            {
                CurrentForceVelocity.y = JumpStrength;
            }
        }
        else
        {
            CurrentForceVelocity.y -= GravityStrength * Time.deltaTime;
        }

        Controller.Move(CurrentForceVelocity * Time.deltaTime);
    }
    #endregion
}
