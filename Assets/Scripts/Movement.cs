using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float movementSpeed;
    public static Movement Instance;
    public bool colliding = false;

    public float jumpHeight;
    float forceAmount = 5;
    public bool jumping = false;
    Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();

        Instance = this;
		if( movementSpeed <= 0)
        {
            movementSpeed = 1;
        }
	}

	void Update () {
        // Constantly falling
        if (!colliding && !jumping)
        {
            rb.velocity = Vector2.down * movementSpeed;
        }
        Debug.Log(colliding);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightShift)) {
            if (colliding && Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.Space))
            {
                jumping = true;
                Debug.Log(colliding);
            }
        }

        if (Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine("DelayShot");
            forceAmount = jumpHeight;
        }
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * (Time.deltaTime * movementSpeed));
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * (Time.deltaTime * movementSpeed));
        }

        if(jumping)
        {
            // Add upward force within a range
            if (rb.velocity.y < 7)
                rb.AddForce(Vector2.up * (8 + jumpHeight));
            else
                jumping = false;
        }
    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        StartCoroutine("DelayShot");
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag != "Wall")
            colliding = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        colliding = false;
    }

    IEnumerator DelayShot()
    {
        yield return new WaitForSeconds(0.25f);
        jumping = false;
    }
}