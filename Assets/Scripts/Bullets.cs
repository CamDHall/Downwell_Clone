using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

    private void Update()
    {
        transform.Translate(Vector3.down * (Time.deltaTime * 0.5f));
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
