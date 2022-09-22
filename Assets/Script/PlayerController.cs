using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   [Header("Component References")]
   [SerializeField] private Transform player;
   [SerializeField] private Rigidbody2D rb;
   [SerializeField] private Collider2D playerCollider;
   [SerializeField] private PlayerAnimatorController animatorController;

   [Header("Player Values")]
   [SerializeField] private float movementSpeed = 5f;
   [SerializeField] private float jumpforce = 10f;
   
   [Header("Ground Check")]
   [SerializeField] private LayerMask groundLayers;
   [SerializeField] private float groundCheckDistance = 0.1f;

   [SerializeField] private float coyoteTime = 0.15f;
   [SerializeField] private float coyoteTimeCounter;

   //input values
   private float _moveInput;
   
   //Boolean Flags
   private bool _isGrounded;

   private void Update(){
     CheckGround();
     SetAnimatorParameters();
     if(_isGrounded == true){
          coyoteTimeCounter = coyoteTime;
     }else{
          coyoteTimeCounter -= Time.deltaTime;
     }
   }

   private void FixedUpdate(){
      Move();
   }
   
   #region Actions
   private void Move(){
     rb.velocity = new Vector2(_moveInput * movementSpeed, rb.velocity.y);
     FlipPlayerSprite();
   }

   public void Jump(float force){
     rb.velocity = new Vector2(rb.velocity.x,0f);
     if(coyoteTimeCounter > 0f){
          rb.AddForce(force * transform.up,ForceMode2D.Impulse);
          coyoteTimeCounter = 0f;
     }
   }

   private void TryJumping(){
     if(!_isGrounded) return;

     Jump(jumpforce);
   }

   private void FlipPlayerSprite(){
     if(_moveInput < 0){
          player.localScale = new Vector3(-1,1,1);
     }
     else if (_moveInput > 0){
          player.localScale = Vector3.one;
     }
   }

   private void CheckGround(){
     RaycastHit2D raycastHit = Physics2D.BoxCast(
          playerCollider.bounds.center,
          playerCollider.bounds.size,
          0f,
          Vector2.down,
          groundCheckDistance,
          groundLayers);
     
     _isGrounded = raycastHit.collider != null;
   }

   private void SetAnimatorParameters(){
     animatorController.SetAnimatorParameter(rb.velocity, _isGrounded);
   }
   #endregion

   #region Input
   private void OnJump(InputValue value)
   {
        if(!value.isPressed) return;
        TryJumping();
        
   }

    private void OnMove(InputValue value)
   {
        _moveInput = value.Get<float>();
   }

   #endregion

}
