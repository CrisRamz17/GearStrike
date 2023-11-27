using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnpoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private float shotCooldown = 2f;
    private float timeSinceLastShot;
    [SerializeField] private GameObject gunshotSFX;
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timeSinceLastShot >= shotCooldown)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
            Instantiate(gunshotSFX);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnpoint.forward * bulletSpeed;
            timeSinceLastShot = 0;
        }
    }
}
