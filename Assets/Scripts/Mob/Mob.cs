using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] private int health;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("oof");
            KYS();
        }
        else if (other.gameObject.tag == "Player")
        {
            Debug.Log("boo");
        }
    }
    
    public Mob Spawn(int health) 
    {
        GameObject mobObj = Instantiate(gameObject);

        Mob mob = mobObj.GetComponent<Mob>();
        mob.health = health;

        return mob;
    }

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

    private void KYS()
    {
        Destroy(this.gameObject);
    }
    private IEnumerator Die()
    {
        Debug.Log("Mob has died");

        Destroy(gameObject);

        yield return null;
    }
}
