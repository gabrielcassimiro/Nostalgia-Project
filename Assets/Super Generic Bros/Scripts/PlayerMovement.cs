using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Player")]
    private Rigidbody2D body;
    [SerializeField] private Vector2 Movement;
    [SerializeField] private float speed, extraSpeed, horizontal;

    [SerializeField] private float jumpForce;
    public bool isGrounded;
    public Transform GroundChecker;
    public float checkRadius;
    public LayerMask layer;

    public Animator anim;
    public SpriteRenderer sprite;

    public Transform spawnPoint;

    public LevelManager level;

    

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetKey(KeyCode.LeftShift))
            body.velocity = new Vector2(horizontal * speed * extraSpeed, body.velocity.y);
        else{
            body.velocity = new Vector2(horizontal * speed, body.velocity.y);
            
        }
    }

    private void Update() {
        isGrounded = Physics2D.OverlapCircle(GroundChecker.position, checkRadius, layer);

        if(isGrounded){
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)){
                body.velocity = Vector2.up * jumpForce;
            }
            anim.SetBool("Jump", false);
        }

        if(!isGrounded){
            anim.SetBool("Run", false);
            anim.SetBool("Fast", false);
            anim.SetBool("Jump", true);
        }

        if(isGrounded && Input.GetButton("Horizontal")){
            if(Input.GetKey(KeyCode.LeftShift)){
                anim.SetBool("Fast", true);
                anim.SetBool("Run", false);
                anim.SetBool("Jump", false);
            }
            else
            {
                anim.SetBool("Run", true);
                anim.SetBool("Fast", false);
                anim.SetBool("Jump", false);
            }            
        }
        else
        {
            anim.SetBool("Run", false);
            anim.SetBool("Fast", false);
        }
        flip();
    }

    void flip(){
        
        if(horizontal > 0)
            sprite.flipX = false;
        else if (horizontal < 0)
        {
            sprite.flipX = true;
        }
            
    }

    public void spawn(){
        transform.position = spawnPoint.position;
        level.takeDamage();
    }

    public void TakeKey(){
        level.addKey();
    }
}
