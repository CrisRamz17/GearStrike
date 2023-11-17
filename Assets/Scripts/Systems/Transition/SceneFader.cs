using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    private bool isFading;
    [SerializeField] private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public System.Collections.IEnumerator FadeToBlack()
    {
        isFading = true;
        animator.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1.75f);
    }

    public void OnFadeCompleted()
    {
        isFading = false;
    }

    public bool GetIsFading()
    {
        return isFading;
    }
}
