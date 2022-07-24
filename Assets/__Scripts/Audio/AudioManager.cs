using System;
using System.Diagnostics.CodeAnalysis;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : SingletonMonobehaviour<AudioManager>, ISaveable
{
    [Header("Main")] [Space] [GUIColor(0.368f, 0.796f, 0.831f)]
    [SerializeField] private AudioSource musicSource;

    [GUIColor(0.368f, 0.796f, 0.831f)]
    [SerializeField] private AudioMixer audioMixerMain;

    [GUIColor(0.368f, 0.796f, 0.831f)]
    [SerializeField] private AudioMixerGroup mixerPickupItem, mixerSfx, mixerWalking;


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
    public AudioClip fireCrackle;


    [Header("Settings")] [Space]
    [GUIColor(0.278f, 0.719f, 0.619f)] public Image musicIconOn;

    [GUIColor(0.278f, 0.719f, 0.619f)] public Image musicIconOff;

    [SerializeField] [GUIColor(0.278f, 0.719f, 0.619f)]
    private Slider musicVolumeSlider;

    [GUIColor(0.278f, 0.719f, 0.619f)] private float musicVolume;

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    private const float TOLERANCE = 0.001f;

    private DynamicAudio[] dynamicAudios;

    private void OnEnable()
    {
        Actions.OnSceneLoad += SetSceneDynamicAudio;
    }

    private void OnDisable()
    {
        Actions.OnSceneLoad -= SetSceneDynamicAudio;
    }

    private void Start()
    {
        dynamicAudios = FindObjectsOfType<DynamicAudio>(true);
        Debug.Log($"DynamicAudios: {dynamicAudios.Length}");
    }

    public void SetSceneDynamicAudio(string currentScene, string arrivingFrom)
    {
        foreach (DynamicAudio da in dynamicAudios)
        {
            da.SetScene(currentScene, arrivingFrom);
        }
    }


    public void PlaySfxClip(int sfxNumber, bool isLooping)
    {
        switch (sfxNumber)
        {
            case 1 when pickupItem:
                sfxSource.outputAudioMixerGroup = mixerPickupItem;
                PlayClip(sfxSource, pickupItem, isLooping);
                break;
            case 2 when openMenu:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                PlayClip(sfxSource, openMenu, isLooping);
                break;
            case 3 when coins:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                PlayClip(sfxSource, coins, isLooping);
                break;
            case 4 when buyItem:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                PlayClip(sfxSource, buyItem, isLooping);
                break;
            case 5 when dropItem:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                PlayClip(sfxSource, dropItem, isLooping);
                break;
            case 6 when button:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                PlayClip(sfxSource, button, isLooping);
                break;
            case 7 when streetLightsOn:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                PlayClip(sfxSource, streetLightsOn, isLooping);
                break;
            case 8 when itemSelect:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                PlayClip(sfxSource, itemSelect, isLooping);
                break;
            case 9 when bellAlarm:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                PlayClip(sfxSource, counterBell, isLooping);
                PlayClipDelayed(sfxSource, bellAlarm, 1.2f);
                break;
            case 10 when counterBell:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                PlayClip(sfxSource, counterBell, isLooping);
                break;
            case 11 when fireCrackle:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                sfxSource.rolloffMode = AudioRolloffMode.Linear;
                float oldVolume = sfxSource.volume;
                audioMixerMain.SetFloat("MixerSFX", Mathf.Log10(0.5f) * 20);
                PlayClip(sfxSource, fireCrackle, isLooping);
                sfxSource.rolloffMode = AudioRolloffMode.Logarithmic;
                sfxSource.volume = oldVolume;
                break;
        }
    }

    public void PlaySfxClip(int sfxNumber)
    {
        switch (sfxNumber)
        {
            case 1 when pickupItem:
                sfxSource.outputAudioMixerGroup = mixerPickupItem;
                PlayClip(sfxSource, pickupItem);
                break;
            case 2 when openMenu:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                PlayClip(sfxSource, openMenu);
                break;
            case 3 when coins:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                PlayClip(sfxSource, coins);
                break;
            case 4 when buyItem:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                PlayClip(sfxSource, buyItem);
                break;
            case 5 when dropItem:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                PlayClip(sfxSource, dropItem);
                break;
            case 6 when button:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                PlayClip(sfxSource, button);
                break;
            case 7 when streetLightsOn:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                PlayClip(sfxSource, streetLightsOn);
                break;
            case 8 when itemSelect:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                PlayClip(sfxSource, itemSelect);
                break;
            case 9 when bellAlarm:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                PlayClip(sfxSource, counterBell);
                PlayClipDelayed(sfxSource, bellAlarm, 1.2f);
                break;
            case 10 when counterBell:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                PlayClip(sfxSource, counterBell);
                break;
            case 11 when fireCrackle:
                sfxSource.outputAudioMixerGroup = mixerSfx;
                sfxSource.rolloffMode = AudioRolloffMode.Linear;
                float oldVolume = sfxSource.volume;
                audioMixerMain.SetFloat("MixerSFX", Mathf.Log10(0.5f) * 20);
                PlayClip(sfxSource, fireCrackle);
                sfxSource.rolloffMode = AudioRolloffMode.Logarithmic;
                sfxSource.volume = oldVolume;
                break;
        }
    }


    public void SetMusicSound(float soundLevel)
    {
        audioMixerMain.SetFloat("MusicVolume", Mathf.Log10(soundLevel) * 20);
        musicVolume = soundLevel;
        PlayStopAudio();
    }

    public void SetSfxSound(float soundLevel)
    {
        audioMixerMain.SetFloat("SFXVolume", Mathf.Log10(soundLevel) * 20);
        sfxVolume = soundLevel;
        PlayStopAudio();
    }

    public float GetMusicSound()
    {
        audioMixerMain.GetFloat("MusicVolume", out musicVolume);
        musicVolume = Mathf.Pow(10f, musicVolume / 20.0f);
        return musicVolume;
    }

    public float GetSfxSound()
    {
        audioMixerMain.GetFloat("SFXVolume", out sfxVolume);
        sfxVolume = Mathf.Pow(10f, sfxVolume / 20.0f);
        return sfxVolume;
    }

    public static void PlayClip(AudioSource source, AudioClip audio, bool isLooping)
    {
        if (isLooping)
        {
            source.loop = isLooping;
            source.PlayOneShot(audio);
        }
        else { source.PlayOneShot(audio); }
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