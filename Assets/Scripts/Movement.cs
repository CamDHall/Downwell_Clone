using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float movementSpeed;
    public static Movement Instance;
    public bool colliding = false, hitEnemy = false;

    public float jumpHeight;
    public bool jumping = false;
    Rigidbody2D rb;

    // Shooting
    public bool shooting = false;

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

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightShift)) && !shooting) {
            if (colliding && Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.Space))
            {
                jumping = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine("DelayShot");
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
            // Different behavior for enemy and platform
            if (hitEnemy)
            {
                rb.AddForce(Vector2.up * (3 * jumpHeight));
                StartCoroutine("DelayShot");
            }
            else if (rb.velocity.y < 7)
            {
                rb.AddForce(Vector2.up * (8 + jumpHeight));
            }
            else
            {
                jumping = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        // Wall
        if (coll.gameObject.tag == "Enemy")
        {
            jumping = true;
            hitEnemy = true;
            Destroy(coll.gameObject, 0.2f);
        }
        else if (coll.gameObject.tag != "Wall")
        {
            colliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        colliding = false;
    }

    IEnumerator DelayShot()
    {
        yield return new WaitForSeconds(0.25f);
        jumping = false;
        hitEnemy = false;
    }
}