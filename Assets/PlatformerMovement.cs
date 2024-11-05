using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Ali Jawad Parpia
public class PlatformerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpForce = 14f;
    private bool isJumping = false;

    public int jumpcounter = 0;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 moveVector = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);


    if (Input.GetButtonDown("Jump") && jumpcounter<2){
        moveVector.y = jumpForce;
        isJumping = true;
        jumpcounter++;
    }

    rb.velocity = moveVector;

    if (horizontalInput < 0){
        transform.localScale = new Vector3(-1, 1, 1);
    }else if(horizontalInput > 0){
        transform.localScale = new Vector3(1, 1, 1);
    }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Ground")){
            isJumping = false;
            jumpcounter = 0;
        }
    }
}
