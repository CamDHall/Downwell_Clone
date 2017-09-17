using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = Vector2.down * 10;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag != "Floor" && coll.gameObject.tag != "Player")
        {
            //Debug.Log(coll.gameObject.tag);
            Destroy(coll.gameObject);
        }

        Destroy(this.gameObject);
    }
}
