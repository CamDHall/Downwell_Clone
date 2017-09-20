using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    public float movementSpeed;
    public static Movement Instance;
    public bool colliding = false, hitEnemy = false;

    public float jumpHeight;
    public bool jumping = false;

    float jumpForce;

    public Rigidbody2D rb;

    // Shooting
    public bool shooting = false;

	void Start () {
        rb = GetComponent<Rigidbody2D>();

        Instance = this;
		if( movementSpeed <= 0)
        {
            movementSpeed = 1;
        }

        jumpForce = jumpHeight;
	}

	void Update () {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightShift)) && !shooting) {
            if (colliding && (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.Space)))
            {
                jumping = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.Space))
        {
            jumping = false;
            jumpForce = jumpHeight;
            StartCoroutine("DelayShot");
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * (Time.deltaTime * movementSpeed));
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * (Time.deltaTime * movementSpeed));
        }

        if (jumping)
        {
            if (hitEnemy)
            {
                rb.AddForce(new Vector2(0, jumpForce * 3.5f), ForceMode2D.Impulse);
                hitEnemy = false;
                jumping = false;
            }
            else
            {

                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

                // Reduce upward force
                jumpForce -= 0.25f;
                if (jumpForce < 0)
                    jumpForce = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        // Wall
        if (coll.gameObject.tag == "Enemy")
        {
            hitEnemy = true;
            jumping = true;
            Destroy(coll.gameObject, 0.2f);
        } else if(coll.gameObject.tag == "Floor")
        {
            SceneManager.LoadScene("main");
        }
        else if (coll.gameObject.tag != "Wall")
        {
            colliding = true;
            GetComponent<Shooting>().magCount = GetComponent<Shooting>().magCapacity;
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