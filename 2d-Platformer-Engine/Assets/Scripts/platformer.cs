using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //So you can use SceneManager


public class platformer : MonoBehaviour
{
    //these are different variables to change for different functions
    Rigidbody2D rb;
    //basic jumping
    public float speed;
    public float jumpForce;
    bool isGrounded = false;
    //this stuff is more advanced for jump feel
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float rememberGroundedFor;
    float lastTimeGrounded;
    //these are all for making sure when you can jump.
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    //keeping track of the bullet
    public GameObject bullet;
    private bool left;
    public bool shootingTrue;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //depending on the platformer you are making, you can take out and edit individual functions.
        Jump();
        BetterJump();
        Move();
        CheckIfGrounded();
        Fire();
    }
    void Fire()
    {
        if (shootingTrue)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetButtonDown("Fire1"))
            {
                GameObject bullet2 = Instantiate(bullet, transform.position + new Vector3(1.5f, 0, 0), transform.rotation);
                bullet2.SendMessage("Direction", left);
            }
        }
    }

    void Move()
    {
        //this is basic movement, left and right.  to change what inputs you are using go into project settings.
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        if (moveBy >= 0)
        {
            left = false;
        }
        else
        {
            left = true;
        }
        //in this project i'm using rigid body to move but there are other forms of movement you could use
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    void Jump()
    {
        //if the jump button is pressed the charecter's velocity is moved upwards in the y direction
                //also it checks with isGrounded to make sure there is ground benieth it
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckIfGrounded()
    {
        //makes sure that the "ground" is beneath it
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (colliders != null)
        {
            isGrounded = true;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //change these to input a lives system
        if (col.gameObject.tag == "OutOfBounds")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
        if (col.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }
}
