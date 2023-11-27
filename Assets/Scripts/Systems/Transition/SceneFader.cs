using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    private bool isFading;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private float timeout = 1;

    public void FadeToBlack()
    {
        isFading = true;
        animator.SetTrigger("FadeOut");
        foreach (AudioSource a in FindAudioPlaying())
        {
            Debug.Log(a.name);
            StartCoroutine(FadeAudio(a, timeout));
        }

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

    //Fade given audio source to 0 and then stop playing
    public IEnumerator FadeAudio(AudioSource audioSource, float duration)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        Debug.Log(audioSource.gameObject.name);
        //fade
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, 0, currentTime / duration);
            yield return null;
        }
        //stop audio source
        audioSource.Stop();
        audioSource.volume = start;
        yield break;
    }

    public List<AudioSource> FindAudioPlaying()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        List<AudioSource> foundAudio = new List<AudioSource>();
        Debug.Log("finding audio");
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].isPlaying)
            {
                foundAudio.Add(audioSources[i]);
                Debug.Log("finding audio");
            }
        }
        return foundAudio;
    }
}
