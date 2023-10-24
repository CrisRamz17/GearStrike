using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(DeathTimer(3f));
    }
    private IEnumerator DeathTimer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}