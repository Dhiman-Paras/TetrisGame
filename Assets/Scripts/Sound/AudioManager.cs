using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public  Sounds[] sounds;
   // public AudioClip coinclip;


    
    void Awake()
    {
        foreach(Sounds s in sounds)
        {
          s.source=  gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        

    }
    void Start(){
    
        Play("Theme");

 
    }
    public void Play(string name)
    {
      //  sounds[3].clip.length.Equals(0.5f); // used to play for a specific sound length

        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return; 
            s.source.Play();
    }

  
}
