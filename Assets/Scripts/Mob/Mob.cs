using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private IEnumerator Die()
    {
        Debug.Log("Mob has died");

        Destroy(gameObject);

        yield return null;
    }
}
