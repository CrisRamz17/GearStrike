using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private SceneFader sceneFader;
    [SerializeField] private PlayerData playerData;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneFader = FindObjectOfType<SceneFader>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //ensure Player only hits Exit once
            if (!sceneFader.GetIsFading())
            {
                Debug.Log("Player has exited!");
                playerData.checkpoint++;
                sceneFader.FadeToBlack();
            }
        }
    }
}
