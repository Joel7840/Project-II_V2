using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioFile[] AudioFiles;

    public AudioFile[] MusicFiles => AudioFiles.Where(x => x.Type == AudioType.Music).ToArray();

    public AudioSource MusicSource;
    public AudioSource SFXSource;
    public AudioSource AmbientSource;

    public AudioMixer AudioMixer;

    [Range(0, 1)]
    public float GlobalMusicVolume=1;
    [Range(0, 1)]
    public float GlobalSFXVolume=1;
    [Range(0, 1)]
    public float GlobalAmbientVolume = 1;

    private void Awake()
    {
        if (Instance)
            Destroy(gameObject);
        else
        Instance = this;
    }

    public static void PlayMusic(string name)
    {
        Instance._PlayMusic(name);
    }

    public static void PlayRandomMusic()
    {
        Instance._PlayRandomMusic();
    }

    

    public static void PlaySFX(string name)
    {
        Instance._PlaySFX(name);
    }

    public static void PlaySFX(string name, AudioSource audioSource)
    {
        Instance._PlaySFX(name, audioSource);
    }

    public static void PlayAmbient(string name)
    {
        Instance._PlayAmbient(name);
    }

    public static void PlayAmbient(string name, AudioSource audioSource)
    {
        Instance._PlayAmbient(name);
    }

    private void _PlayMusic(string name)
    {
        var clip = GetFileByName(name);
        if (clip!= null)
        {
            float vol = GlobalMusicVolume * clip.Volume;
            MusicSource.volume = vol;
            MusicSource.clip = clip.Clip;
            MusicSource.Play();
        }
        else
        {
            Debug.LogError(" No such audio file " + name);
        }
    }

    private void _PlayRandomMusic()
    {
        var musics = MusicFiles;
        int rdm = Random.Range(0, musics.Length);
        _PlayMusic(musics[rdm].Name);
    }

    private void _PlaySFX(string name)
    {
        var clip = GetFileByName(name);
        if (clip != null)
        {
            float vol = GlobalSFXVolume * clip.Volume;
            SFXSource.volume = vol;
            SFXSource.clip = clip.Clip;
            SFXSource.outputAudioMixerGroup = /*AudioMixer.FindMatchingGroups(name).Length >0 ?
                   AudioMixer.FindMatchingGroups(name)[0] :*/
                   AudioMixer.FindMatchingGroups("Sfx")[0];

            SFXSource.Play();
        }
        else
        {
            Debug.LogError(" No such audio file " + name);
        }
    }

    private void _PlaySFX(string name, AudioSource audioSource)
    {
        var clip = GetFileByName(name);
        if (clip != null)
        {
            float vol = GlobalSFXVolume * clip.Volume;
            /*SFXSource.outputAudioMixerGroup = /*AudioMixer.FindMatchingGroups(name).Length >0 ?
                   AudioMixer.FindMatchingGroups(name)[0] :
            AudioMixer.FindMatchingGroups("Sfx")[0];*/
             audioSource.volume = vol;
            audioSource.clip = clip.Clip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError(" No such audio file " + name);
        }
    }

    private void _PlayAmbient(string name)
    {
        var clip = GetFileByName(name);
        if (clip != null)
        {
            float vol = GlobalAmbientVolume * clip.Volume;
            AmbientSource.volume = vol;
            AmbientSource.clip = clip.Clip;
            /*AmbientSource.outputAudioMixerGroup = AudioMixer.FindMatchingGroups("Environment")[0];
            */
            AmbientSource.Play();
        }
        else
        {
            Debug.LogError(" No such audio file " + name);
        }
    }

    private AudioFile GetFileByName(string name)
    {
        AudioFile l_AudioFile= AudioFiles.First(x => x.Name == name);
        if(l_AudioFile== null)
        {
            Debug.Log("name '"+name+"' not found");
            foreach (AudioFile it in AudioFiles)
                Debug.Log("rs " + it.Name);
        }
       return l_AudioFile;
    }
}

[Serializable]
public class AudioFile
{
    public string Name;
    public AudioClip Clip => Clips[Random.Range(0, Clips.Length)];
    public AudioClip[] Clips;
    [Range(0, 1)]
    public float Volume;
    public AudioType Type;

   


}

public enum AudioType
{
    Music,
    SfX,
    Environment
}