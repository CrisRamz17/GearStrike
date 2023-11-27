using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject enemyDeathSFX;
    [SerializeField] private GameObject bulletHitSFX;
    [SerializeField] private float life = 3f;

    void Awake()
    {
        StartCoroutine(DeathTimer(life));
    }
    private IEnumerator DeathTimer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject); // destroys bullet

        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("Bullet hit mob!");
            Destroy(collision.gameObject);
            Instantiate(enemyDeathSFX);
        }
        else if (collision.gameObject.CompareTag("Portal"))
        { // If Bullet hits entrance or exit block
            // Do nothing
        }
        else
        {
            //Debug.Log("Bullet hit " + collision.gameObject.name + "!");
            Instantiate(bulletHitSFX);
        }
    }
}