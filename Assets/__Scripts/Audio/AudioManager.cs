using System;
using System.Diagnostics.CodeAnalysis;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : SingletonMonobehaviour<AudioManager>, ISaveable
{
    [SerializeField]
    private AudioSource mainMusic;

    [SerializeField]
    private AudioSource[] soundFX;
    [GUIColor(0.778f, 0.219f, 0.619f)]
    public float musicVolume;
    [GUIColor(0.778f, 0.219f, 0.619f)]
    public float sfxVolume;
    [GUIColor(0.278f, 0.719f, 0.619f)]
    public Image sfxIconOn, sfxIconOff, musicIconOn, musicIconOff;
    
    [SerializeField] [GUIColor(0.478f, 0.519f, 0.619f)]
    private Slider musicVolumeSlider = null;

    [SerializeField] [GUIColor(0.478f, 0.519f, 0.619f)]
    private Slider sfxVolumeSlider = null;

    [SerializeField]
    private AudioMixer audioMixer;

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    private const float TOLERANCE = 0.001f;


    private void Start()
    {

    }

    public void SetMusicSound(float soundLevel)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(soundLevel) * 20);
        musicVolume = soundLevel;
        PlayStopAudio();
        Debug.Log($"musicVolume: {musicVolume}");
    }
    
    public void SetSfxSound(float soundLevel)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(soundLevel) * 20);
        sfxVolume = soundLevel;
        PlayStopAudio();
        Debug.Log($"sfxVolume: {sfxVolume}");
    }

    public float GetMusicSound()
    {
        audioMixer.GetFloat("MusicVolume", out musicVolume);
        musicVolume = Mathf.Pow(10f, musicVolume/20.0f);
        return musicVolume;
    }
    
    public float GetSfxSound()
    {
        audioMixer.GetFloat("SFXVolume", out sfxVolume);
        sfxVolume = Mathf.Pow(10f, sfxVolume/20.0f);
        return sfxVolume;
    }

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        a_SaveData.audioData.musicVolume = GetMusicSound();
        a_SaveData.audioData.sfxVolume = GetSfxSound();
        Debug.Log($"Audio Data saved: {sfxVolume} | {musicVolume}");
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        sfxVolume = a_SaveData.audioData.sfxVolume;
        musicVolume = a_SaveData.audioData.musicVolume;
        Debug.Log($"Audio Data loaded: {sfxVolume} | {musicVolume}");
        SetSfxSound(sfxVolume);
        SetMusicSound(musicVolume);
        PlayStopAudio();
    }

    private void PlayStopAudio()
    {
        musicVolumeSlider.value = musicVolume;
        sfxVolumeSlider.value = sfxVolume;
        
        if (Math.Abs(sfxVolume - 0.0001f) < TOLERANCE)
        { sfxIconOff.enabled = true;
            sfxIconOn.enabled = false; }
        else
        { sfxIconOff.enabled = false;
            sfxIconOn.enabled = true; }

        if (Math.Abs(musicVolume - 0.0001f) < TOLERANCE)
        { musicIconOff.enabled = true;
            musicIconOn.enabled = false; }
        else
        { musicIconOff.enabled = false;
            musicIconOn.enabled = true;
            if (!mainMusic.isPlaying) { mainMusic.Play(); } }
    }

    #endregion
}