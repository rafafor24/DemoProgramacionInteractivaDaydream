using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    private AudioClip music;
    public AudioSource musicSource;
    private int actual;
    // Start is called before the first frame update
    void Start()
    {
        actual = Mathf.RoundToInt(Random.Range(1f, 7f));
        music = Resources.Load("MusicaSonidos/"+actual) as AudioClip;
        musicSource.clip = music;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
           
        
    }

    public void cambiarMusica()
    {
        int newActual = Mathf.RoundToInt(Random.Range(1f, 7f));
        while (actual == newActual)
        {
            newActual = Mathf.RoundToInt(Random.Range(1f, 7f));
        }
        music = Resources.Load("MusicaSonidos/" + newActual) as AudioClip;
        musicSource.clip = music;
        musicSource.Play();
        actual = newActual;
    }
}
