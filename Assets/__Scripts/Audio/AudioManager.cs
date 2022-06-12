using System;
using System.Diagnostics.CodeAnalysis;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : SingletonMonobehaviour<AudioManager>, ISaveable
{
    [Header("Main")] [Space]
    [SerializeField] private AudioSource musicSource;

    [SerializeField] private AudioMixer audioMixer;


    [Header("Sound Effects")] [Space]
    [GUIColor(0.778f, 0.219f, 0.619f)]
    public AudioSource sfxSource;

    [GUIColor(0.778f, 0.219f, 0.619f)] public Slider sfxVolumeSlider;

    [GUIColor(0.778f, 0.219f, 0.619f)] private float sfxVolume;

    [GUIColor(0.778f, 0.219f, 0.619f)] public Image sfxIconOn, sfxIconOff;

    [FoldoutGroup("SFX Clips")] [GUIColor(1, 0.874f, 0.301f)]
    public AudioClip pickupItem;

    [FoldoutGroup("SFX Clips")] [GUIColor(1, 0.874f, 0.301f)]
    public AudioClip openMenu;

    [FoldoutGroup("SFX Clips")] [GUIColor(1, 0.874f, 0.301f)]
    public AudioClip coins;

    [FoldoutGroup("SFX Clips")] [GUIColor(1, 0.874f, 0.301f)]
    public AudioClip buyItem;

    [FoldoutGroup("SFX Clips")] [GUIColor(1, 0.874f, 0.301f)]
    public AudioClip dropItem;

    [FoldoutGroup("SFX Clips")] [GUIColor(1, 0.874f, 0.301f)]
    public AudioClip button;

    [FoldoutGroup("SFX Clips")] [GUIColor(1, 0.874f, 0.301f)]
    public AudioClip streetLightsOn;

    [FoldoutGroup("SFX Clips")] [GUIColor(1, 0.874f, 0.301f)]
    public AudioClip itemSelect;

    [FoldoutGroup("SFX Clips")] [GUIColor(1, 0.874f, 0.301f)]
    public AudioClip bellAlarm;

    [FoldoutGroup("SFX Clips")] [GUIColor(1, 0.874f, 0.301f)]
    public AudioClip counterBell;

    [FoldoutGroup("SFX Clips")] [GUIColor(1, 0.874f, 0.301f)]
    public AudioClip shelfWhoosh;

    [FoldoutGroup("SFX Clips")] [GUIColor(1, 0.874f, 0.301f)]
    public AudioClip empty6;


    [Header("Settings")] [Space]
    [GUIColor(0.278f, 0.719f, 0.619f)] public Image musicIconOn;

    [GUIColor(0.278f, 0.719f, 0.619f)] public Image musicIconOff;

    [SerializeField] [GUIColor(0.278f, 0.719f, 0.619f)]
    private Slider musicVolumeSlider;

    [GUIColor(0.278f, 0.719f, 0.619f)] private float musicVolume;


    [SuppressMessage("ReSharper", "InconsistentNaming")]
    private const float TOLERANCE = 0.001f;

    public void PlaySfxClip(int sfxNumber)
    {
        switch (sfxNumber)
        {
            case 1 when pickupItem:
                PlayClip(sfxSource, pickupItem);
                break;
            case 2 when openMenu:
                PlayClip(sfxSource, openMenu);
                break;
            case 3 when coins:
                PlayClip(sfxSource, coins);
                break;
            case 4 when buyItem:
                PlayClip(sfxSource, buyItem);
                break;
            case 5 when dropItem:
                PlayClip(sfxSource, dropItem);
                break;
            case 6 when button:
                PlayClip(sfxSource, button);
                break;
            case 7 when streetLightsOn:
                PlayClip(sfxSource, streetLightsOn);
                break;
            case 8 when itemSelect:
                PlayClip(sfxSource, itemSelect);
                break;
            case 9 when bellAlarm:
                PlayClip(sfxSource, counterBell);
                PlayClipDelayed(sfxSource, bellAlarm, 1.2f);
                break;
            case 10 when counterBell:
                PlayClip(sfxSource, counterBell);
                break;
            case 11 when empty6:
                PlayClip(sfxSource, empty6);
                break;
        }
    }


    public void SetMusicSound(float soundLevel)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(soundLevel) * 20);
        musicVolume = soundLevel;
        PlayStopAudio();
    }

    public void SetSfxSound(float soundLevel)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(soundLevel) * 20);
        sfxVolume = soundLevel;
        PlayStopAudio();
    }

    public float GetMusicSound()
    {
        audioMixer.GetFloat("MusicVolume", out musicVolume);
        musicVolume = Mathf.Pow(10f, musicVolume / 20.0f);
        return musicVolume;
    }

    public float GetSfxSound()
    {
        audioMixer.GetFloat("SFXVolume", out sfxVolume);
        sfxVolume = Mathf.Pow(10f, sfxVolume / 20.0f);
        return sfxVolume;
    }

    public static void PlayClip(AudioSource source, AudioClip audio)
    {
        source.PlayOneShot(audio);
    }

    public void PlayClipDirect(AudioSource source, AudioClip audio)
    {
        source.PlayOneShot(audio);
    }

    public void PlayClipDelayed(AudioSource source, AudioClip clip, float delay)
    {
        source.clip = clip;
        source.PlayDelayed(delay);
    }


    private void PlayStopAudio()
    {
        musicVolumeSlider.value = musicVolume;
        sfxVolumeSlider.value = sfxVolume;

        if (Math.Abs(sfxVolume - 0.0001f) < TOLERANCE)
        {
            sfxIconOff.enabled = true;
            sfxIconOn.enabled = false;
        }
        else
        {
            sfxIconOff.enabled = false;
            sfxIconOn.enabled = true;
        }

        if (Math.Abs(musicVolume - 0.0001f) < TOLERANCE)
        {
            musicIconOff.enabled = true;
            musicIconOn.enabled = false;
        }
        else
        {
            musicIconOff.enabled = false;
            musicIconOn.enabled = true;
            if (!musicSource.isPlaying) { musicSource.Play(); }
        }
    }

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        a_SaveData.audioData.musicVolume = GetMusicSound();
        a_SaveData.audioData.sfxVolume = GetSfxSound();
    }


    public void LoadFromSaveData(SaveData a_SaveData)
    {
        sfxVolume = a_SaveData.audioData.sfxVolume;
        musicVolume = a_SaveData.audioData.musicVolume;
        SetSfxSound(sfxVolume);
        SetMusicSound(musicVolume);
        PlayStopAudio();
    }

    #endregion
}