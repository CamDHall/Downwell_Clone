using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject bulletPrefab;
    float fireTimer = 0;
    bool canShoot = false;
    public int magCapacity;
    public int magCount;


    private void Start()
    {
        magCount = magCapacity;
    }

    // Update is called once per frame
    void Update () {
        if((Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.Space)) && !Movement.Instance.colliding && !Movement.Instance.jumping)
        {
            canShoot = true;
        } 

        if(Movement.Instance.colliding || magCount <= 0 || Movement.Instance.jumping)
        {
            canShoot = false;
        }

        // change can shoot if button isn't down
        if(canShoot && (Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.Space))) {
            canShoot = false;
        }
        Movement.Instance.shooting = canShoot;
	}

    private void FixedUpdate()
    {
        if(canShoot)
        {
            if (Time.time > fireTimer || fireTimer == 0)
            {
                Movement.Instance.rb.AddForce(-Movement.Instance.rb.velocity * 50);
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Vector2 Pos = new Vector2(Movement.Instance.transform.position.x, Movement.Instance.transform.position.y - .5f);
        var bullet = Instantiate(bulletPrefab, Pos, Quaternion.identity);
        Movement.Instance.shooting = true;

        fireTimer = Time.time + 0.15f;
        magCount -= 1;
    }
}
