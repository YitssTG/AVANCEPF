using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float speedX;
    public float Horizontal;
    private Rigidbody2D _componentRigidBody2D;
    private Animator _componentAnimator;
    private SpriteRenderer _componentSpriteRenderer;
    public bool canJump;
    public bool isJumping;
    public float jumpForce;
   
    void Awake()
    {
        _componentRigidBody2D = GetComponent<Rigidbody2D>();
        _componentAnimator = GetComponent<Animator>();
        _componentSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        _componentAnimator.SetInteger("isWalking", (int)Horizontal);
        if (Horizontal < 0)
        {
            _componentSpriteRenderer.flipX = false;
        }
        else if (Horizontal > 0) 
        {
            _componentSpriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) == true && canJump == true)
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        _componentRigidBody2D.velocity = new Vector2(Horizontal * speedX, _componentRigidBody2D.velocity.y);
        if (isJumping == true)
        {
            _componentRigidBody2D.AddForce(new Vector2(0, jumpForce),ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }    
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
            isJumping = false;
        }
    }
    
}
