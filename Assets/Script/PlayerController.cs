using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private Rigidbody2D rb;
   [SerializeField] private float JumpForce = 5f;
   [SerializeField] private float Speed = 10f;
   private float _moveInput;

   private void OnJump(InputValue value)
   {
        if(value.isPressed){
            rb.AddForce(JumpForce * transform.up, ForceMode2D.Impulse);
        }
   }

    private void OnMove(InputValue value)
   {
        _moveInput = value.Get<float>();
        rb.velocity = new Vector2(_moveInput * Speed,0);
       
   }

}
