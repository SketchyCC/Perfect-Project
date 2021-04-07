using System;
using UnityEngine;
using GameEvents;


[Serializable]
public class SoundSettings
{
    public bool MusicOn = true;
    public bool SfxOn = true;
}

public class AudioManager : MonoBehaviour
{
    [Header("Settings")]
    public SoundSettings Settings;

    [Header("Sound Effects")]
    /// true if the sound fx are enabled
    //public bool SfxOn=true;
    /// the sound fx volume
    [Range(0, 1)]
    public float SfxVolume = 1f;

    protected const string _saveFolderName = "Engine/";
    protected const string _saveFileName = "sound.settings";


    /// <summary>
    /// Plays a sound
    /// </summary>
    /// <returns>An audiosource</returns>
    /// <param name="sfx">The sound clip you want to play.</param>
    /// <param name="location">The location of the sound.</param>
    /// <param name="loop">If set to true, the sound will loop.</param>
    public virtual AudioSource PlaySound(AudioClip sfx, bool loop = false)
    {
        if (!Settings.SfxOn)
            return null;
        // we create a temporary game object to host our audio source
        GameObject temporaryAudioHost = new GameObject("TempAudio");
        // we add an audio source to that host
        AudioSource audioSource = temporaryAudioHost.AddComponent<AudioSource>() as AudioSource;
        // we set that audio source clip to the one in paramaters
        audioSource.clip = sfx;
        // we set the audio source volume to the one in parameters
        audioSource.volume = SfxVolume;
        // we set our loop setting
        audioSource.loop = loop;
        // we start playing the sound
        audioSource.Play();

        if (!loop)
        {
            // we destroy the host after the clip has played
            Destroy(temporaryAudioHost, sfx.length);
        }

        // we return the audiosource reference
        return audioSource;
    }

    /// <summary>
    /// Stops the looping sounds if there are any
    /// </summary>
    /// <param name="source">Source.</param>
    public virtual void StopLoopingSound(AudioSource source)
    {
        if (source != null)
        {
            Destroy(source.gameObject);
        }
    }

    public AudioClip CatalogueOpenSound;
    public AudioClip CatalogueCloseSound;
    public AudioClip CataloguePageTurn;
    public AudioClip Throwaway;

    public virtual void OnCatalogueOpen(GameEvent_OpenCatalogue e)
    {
        PlaySound(CatalogueOpenSound);
    }

    public virtual void OnCatalogueClose(GameEvent_CloseCatalogue e)
    {
        PlaySound(CatalogueCloseSound);
    }
    public virtual void OnPageTurned(GameEvent_PageTurn e)
    {
        PlaySound(CataloguePageTurn);
    }
    public virtual void OnItemDestroyedSound(ItemSoundOnDestroy e)
    {
        PlaySound(e.soundeffect);
    }
    public virtual void OnBDItemDestroyed(BDItemDestroyed e)
    {
        PlaySound(Throwaway);
    }
    protected virtual void OnEnable()
    {
        GameEventManager.AddListener<GameEvent_OpenCatalogue>(OnCatalogueOpen);
        GameEventManager.AddListener<GameEvent_CloseCatalogue>(OnCatalogueClose);
        GameEventManager.AddListener<GameEvent_PageTurn>(OnPageTurned);
        GameEventManager.AddListener<ItemSoundOnDestroy>(OnItemDestroyedSound);
        GameEventManager.AddListener<BDItemDestroyed>(OnBDItemDestroyed);
    }

    protected virtual void OnDisable()
    {
        GameEventManager.RemoveListener<GameEvent_OpenCatalogue>(OnCatalogueOpen);
        GameEventManager.RemoveListener<GameEvent_CloseCatalogue>(OnCatalogueClose);
        GameEventManager.RemoveListener<GameEvent_PageTurn>(OnPageTurned);
        GameEventManager.RemoveListener<ItemSoundOnDestroy>(OnItemDestroyedSound);
        GameEventManager.RemoveListener<BDItemDestroyed>(OnBDItemDestroyed);
    }
}
