using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float movementSpeed;
    public static Movement Instance;
    public bool colliding = false;

	void Start () {
        Instance = this;
		if( movementSpeed <= 0)
        {
            movementSpeed = 1;
        }
	}

	void Update () {

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
    }

    public void Jump()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        colliding = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        colliding = false;
    }
}
