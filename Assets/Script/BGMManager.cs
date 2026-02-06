using UnityEngine;

public class BGMManager : MonoBehaviour
{
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    public void PlayBGM()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }
}
