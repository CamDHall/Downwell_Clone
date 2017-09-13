using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject bulletPrefab;
    float fireTimer = 0;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.RightShift))
        {
            if (Time.time > fireTimer || fireTimer == 0)
            {
                if(!Movement.Instance.colliding)
                    Shoot();
                else

            }
        }
	}

    void Shoot()
    {
        Vector2 Pos = new Vector2(Movement.Instance.transform.position.x, Movement.Instance.transform.position.y - 0.5f);
        var bullet = Instantiate(bulletPrefab, Pos, Quaternion.identity);
        fireTimer = Time.time + 2;
    }
}
