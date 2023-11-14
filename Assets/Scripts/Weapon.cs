using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform bulletSpawnpoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float shotCooldown = 2f;
    private float timesinceLastShot;

    void Update()
    {
        timesinceLastShot += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timesinceLastShot >= shotCooldown)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnpoint.forward * bulletSpeed;
            timesinceLastShot = 0;
        }
    }
}
