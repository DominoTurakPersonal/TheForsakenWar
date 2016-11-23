using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

    public Camera mainCam;

    private bool facingRight = true;

    private bool grounded = false;
    public Transform groundCheck;
    private float groundRadius = 0.225f;
    public LayerMask whatIsGround;

    private float speed = 4.5f;


	// Use this for initialization
	void Start () {
	}
	
	// FixedUpdate is called once per some time
	void FixedUpdate () 
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position,groundRadius,whatIsGround);
        GetComponent<Animator>().SetBool("Ground", grounded);

        // Set velocity , u can see it in Inspector
        float move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * speed, GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(move));   
        
        // change facing
        if(move > 0 && !facingRight)
            Flip();
        else if(move < 0 && facingRight)
            Flip();
	}

    // Update is called once per frame
    void Update ( )
    {
        if(grounded && Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Animator>().SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 700));
        }

        

        if(Input.GetKey(KeyCode.LeftShift))
        {
            if(speed < 9)
                speed += 0.05f;
        }
        else
            speed = 4.5f;
            
    }

    // flip hero scale to change direction of facing
    void Flip ( )
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z);
    }

    public float getPixelSize()
    {
        return GetComponent<Renderer>().bounds.size.y;
    }
}
