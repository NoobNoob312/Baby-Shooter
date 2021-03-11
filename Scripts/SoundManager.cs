using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private static SoundManager instance = null;

    public static SoundManager Instance
    {
        get
        {

            return instance;
        }
    }

    public AudioSource BackgroundSource;
    public AudioSource SFXSource;
    public AudioSource SFXSource2;
    public AudioSource SFXSource3;

    public AudioClip Won;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        BackgroundSource = this.gameObject.AddComponent<AudioSource>();
        SFXSource = this.gameObject.AddComponent<AudioSource>();
        SFXSource2 = this.gameObject.AddComponent<AudioSource>();
        SFXSource3 = this.gameObject.AddComponent<AudioSource>();

    }
    public void PlayMusic(AudioClip clip)
    {
        BackgroundSource.loop = true;
        BackgroundSource.clip = clip;
        BackgroundSource.Play();
    }

    public void StopMusic()
    {
        BackgroundSource.Stop();
    }

    public void PlaySFX(AudioClip clip)
    {
        //SFXSource.clip = clip;
        SFXSource.PlayOneShot(clip);
    }
    public void PlaySFX2(AudioClip clip)
    {
        SFXSource2.clip = clip;
        SFXSource2.Play();
    }

    public void PlaySFX3()
    {
        SFXSource3.clip = Won;
        SFXSource3.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
