using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public PlayerData playerData; // probably best not to use scriptable objects for this

    [SerializeField] private uint checkpoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Die()
    {
        Debug.Log("Player is dead!");
        Destroy(this.gameObject);
    }
}
