using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed;
    private float playerInput;
    private bool facingRight = true;

    //Jump section oh noes

    public bool onGround;
    public Transform feet;
    public float groundDist;
    public LayerMask whatIsGround;
    public float jumpForce;
    // Start is called before the first frame update
    void Start() {
        
    }
    void FixedUpdate() {
        onGround = Physics2D.OverlapCircle(feet.position, groundDist, whatIsGround);


        playerInput = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(speed * playerInput, player.velocity.y);
        if(playerInput < 0 && facingRight){
            PlayerFlipper();
        } else if(playerInput > 0 && !facingRight) {
            PlayerFlipper();
        }
        

    }

    void PlayerFlipper(){
        facingRight = !facingRight;
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.UpArrow) && onGround) {
            player.velocity = Vector2.up * jumpForce;
        }
    }
}
