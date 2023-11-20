using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    private bool isFading;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerData playerData;

    public void FadeToBlack()
    {
        isFading = true;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeCompleted()
    {
        isFading = false;
        SceneManager.LoadScene(playerData.checkpoint);
    }

    public bool GetIsFading()
    {
        return isFading;
    }
}
