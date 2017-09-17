using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject bulletPrefab;
    float fireTimer = 0;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.Space))
        {
            if (Time.time > fireTimer || fireTimer == 0)
            {
                if (!Movement.Instance.jumping)
                {
                    Shoot();
                }
            }
        }
	}

    void Shoot()
    {
        Vector2 Pos = new Vector2(Movement.Instance.transform.position.x, Movement.Instance.transform.position.y - 1f);
        var bullet = Instantiate(bulletPrefab, Pos, Quaternion.identity);

        fireTimer = Time.time + 0.15f;
    }
}
