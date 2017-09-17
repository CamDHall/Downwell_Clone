using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Vector2 direction;

    private void Start()
    {
        direction = new Vector2(1, 0);
    }

    void Update () {

        transform.Translate(direction * Time.deltaTime);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("HERE");
        Vector2 newDirection = new Vector2(-direction.x, 0);
        direction = newDirection;
    }
}
