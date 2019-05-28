using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private List<AudioSource> sources;
    public int numberOfSources = 5;

    public List<AudioClip> clips;

    public static AudioManager instance;

    void Awake()
    {
        if (instance != null){
            Destroy(gameObject);
            return;
        }
        instance = this;

        sources = new List<AudioSource>();
        for (int i = 0; i < numberOfSources; i++){
            AudioSource newSource = gameObject.AddComponent<AudioSource>();
            sources.Add(newSource);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    AudioSource GetFreeSource()
    {
        foreach(AudioSource source in sources){
            if (!source.isPlaying)
                return source;
        }
        return null;
    }

    public void PlayClip(int index)
    {
        AudioSource freeSource = GetFreeSource();
        if (freeSource != null){
            freeSource.clip = clips[index];
            freeSource.Play();
        }
    }


}
