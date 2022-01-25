using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1f;
    public Rigidbody2D rb;
    Vector3 movement;
    public Animator animator;
    void Start() { 
    
    }

    void Update() {
        ProcessInputs();
        Move();
    }

    private void Move() {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        animator.SetBool("isWalking", x != 0 || y != 0);
        
        if (x > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        } else if (x < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        rb.velocity = new Vector2(movement.x, movement.y);
    }

    private void ProcessInputs() {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
    }

}
