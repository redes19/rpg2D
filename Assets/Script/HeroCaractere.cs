using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCaractere : MonoBehaviour
{
    //variables
    public float moveSpeed = 5.0f;

    public Rigidbody2D rb;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    Vector2 dir; // direction

    int dirValue = 0; // 0=idl 1=WalkDown 2=WalkSide 3 = WalkUp


    void Start()
    {
        
    }

    void Update()
    {
        HandleKeys();
        HandleMove();
        if(Input.GetKey(KeyCode.X)){
            moveSpeed = 7.5f;
        }
    }

    public void HandleKeys() {
        if(Input.GetKey(KeyCode.Z)){
        dir = Vector2.up;
        dirValue = 3;
        }

        else if(Input.GetKey(KeyCode.D)){
            dir = Vector2.right;
            dirValue = 2;
            spriteRenderer.flipX = true;
        }

        else if(Input.GetKey(KeyCode.Q)){
            dir = Vector2.left;
            dirValue = 2 ;
            spriteRenderer.flipX = false;
        }

        else if(Input.GetKey(KeyCode.S)){
            dir = Vector2.down;
            dirValue = 1;
        }
        
        else
        {
            dir = Vector2.zero;
            dirValue = 0;
        }
    }

    // gestion du mouvement
    public void HandleMove() {
        rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);
        animator.SetInteger("dir", dirValue);
    }
}
