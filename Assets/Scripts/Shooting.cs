using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject bulletPrefab;
    float fireTimer = 0;
    bool canShoot = false;
    
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Movement.Instance.colliding);

        if((Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.Space)) && !Movement.Instance.colliding)
        {
            canShoot = true;
            
        } 

        if(Movement.Instance.colliding)
        {
            canShoot = false;
        }

        Movement.Instance.shooting = canShoot;
	}

    private void FixedUpdate()
    {
        if(canShoot)
        {
            if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.Space))
            {
                if (Time.time > fireTimer || fireTimer == 0)
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
        Movement.Instance.shooting = true;

        fireTimer = Time.time + 0.15f;
    }
}
