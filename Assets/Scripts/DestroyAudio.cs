using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAudio : MonoBehaviour
{
    float startTime;
    [SerializeField] float delay;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - startTime) >= delay)
            Destroy(this.gameObject);
    }
}
