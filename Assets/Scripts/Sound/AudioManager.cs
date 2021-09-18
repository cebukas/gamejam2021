using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        // NOTE: Some insights on class vs struct for data storage
        // Some things on structs and classes:
        // If we make Sound class as struct, we get compile errors in foreach
        // because struct is a value type, therefore immutable
        // and we can't modify it's members
        // class is a reference type, we handle only references, so no problem 
        // modifying it in foreach
        
        // IDEA: Maybe use structs only when passing strict immutable data?

        // This works if sound is struct:
        /*
        for (var i = 0; i < sounds.Length; i++)
        {
            sounds[i].source = gameObject.AddComponent<AudioSource>();
        }
        */
        
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }
    private void Start(){

        FindObjectOfType<AudioManager>().Play("Background");
    }

    public void Play(string soundName)
    {
        var s = Array.Find(sounds, sound => sound.name == soundName);
        s.source.Play();
    }
    
    public void Stop(string soundName){
        var s = Array.Find(sounds, sound => sound.name == soundName);
        s.source.Stop(); 
    }
}
