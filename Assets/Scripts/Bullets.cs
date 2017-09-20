using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll);
        if(coll.gameObject.tag != "Floor" && coll.gameObject.tag != "Player" && coll.gameObject.tag != "Barrier")
        {
            Destroy(coll.gameObject);
        }

        if(coll.gameObject.tag != "Player")
            Destroy(this.gameObject);
    }
}
