using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    //[SerializeField] private int health; //unused for now (1-hit kill)
    private SceneFader sceneFader;
    [SerializeField] private GameObject playerDeathSFX;
    void Start()
    {
        sceneFader = FindObjectOfType<SceneFader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("Bullet touched Mob!");
            Die();
        }
    }*/

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Mob touched Player!");
            Debug.Log("Player is dead!");
            //Instantiate(playerDeathSFX);
            Destroy(other.gameObject);
            sceneFader.FadeToBlack();
        }
    }

    /*
    public Mob Spawn(int health) 
    {
        GameObject mobObj = Instantiate(gameObject);

        Mob mob = mobObj.GetComponent<Mob>();
        mob.health = health;

        return mob;
    }
    */

    /*private void Die()
    {
        Destroy(this.gameObject);

    }*/

    /*
    private void ReduceHealth(int i)
    {
        //Decrease health
        health -= i;

        if (health > 0)
        {

        }
        else
        { // If dead
            health = 0;
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        Debug.Log("Mob has died");

        Destroy(gameObject);

        yield return null;
    }
    */
}
