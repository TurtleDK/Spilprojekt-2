using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class AudioTrigger : MonoBehaviour
{
    public enum AudioTriggerType
    {
        RandomEnviromental, EventSpecific
    }

    public enum AudioOrder
    {
        Random, AsSpecified
    }

    public enum ActionAfterDone
    {
        Nothing, Repeat, DestroySelf, CustomAction
    }

    [HideInInspector]
    public UnityEvent customAction;

    [HideInInspector]
    public ActionAfterDone actionAfterDone = ActionAfterDone.DestroySelf;

    [HideInInspector]
    public AudioTriggerType audioTriggerType = AudioTriggerType.RandomEnviromental;

    [HideInInspector]
    public AudioSource audioSource;


    public List<AudioClip> audioClips;
    [HideInInspector]
    public AudioOrder audioOrder;
    [HideInInspector]
    public bool PlayOneClip = false;

    [HideInInspector]
    public float Volume = 1f;
    [HideInInspector]
    public float Range = 5f;
    [HideInInspector]
    public bool SurroundSound = true;

    [HideInInspector]
    public float minRandTime = 1f;
    [HideInInspector]
    public float maxRandTime = 5f;

    private void Update()
    {
        UpdateAudio();
    }

    AudioListener audioListener;
    public void Awake()
    {
        audioListener = FindObjectOfType<AudioListener>();
        if(audioTriggerType == AudioTriggerType.RandomEnviromental)
        {
            PlaySound();
        }
    }


    List<int> playOrder = new List<int>();
    
    int nextPlay = 0;
    public void PlaySound()
    {
        #region Play Order
        List<int> normalPlayOrder = new List<int>();
        for (int i = 0; i < audioClips.Count; i++)
        {
            normalPlayOrder.Add(i);
        }

        playOrder = audioOrder == AudioOrder.Random ? GenerateRandomIntList(audioClips.Count) : normalPlayOrder;
        #endregion

        StartCoroutine(PlayWait(audioTriggerType == AudioTriggerType.RandomEnviromental ? Random.Range(minRandTime, maxRandTime) + audioClips[playOrder[nextPlay]].length : audioClips[playOrder[nextPlay]].length));
    }

    IEnumerator PlayWait(float seconds)
    {
        if (audioTriggerType == AudioTriggerType.RandomEnviromental)
        {
            yield return new WaitForSeconds(Random.Range(minRandTime, maxRandTime));
        }
        audioSource.clip = audioClips[playOrder[nextPlay]];
        audioSource.Play();
        yield return new WaitForSeconds(seconds);
        nextPlay++;
        if(nextPlay >= audioClips.Count || PlayOneClip)
        {
            donePlaying();
        } else
        {
            StartCoroutine(PlayWait(audioTriggerType == AudioTriggerType.RandomEnviromental ? Random.Range(minRandTime, maxRandTime) + audioClips[playOrder[nextPlay]].length : audioClips[playOrder[nextPlay]].length));
        }
    }

    public void StopSound()
    {
        audioSource.Stop();
    }

    void donePlaying()
    {
        switch (actionAfterDone)
        {
            case ActionAfterDone.Nothing:
                nextPlay = 0;
                break;
            case ActionAfterDone.DestroySelf:
                Destroy(gameObject);
                break;
            case ActionAfterDone.Repeat:
                nextPlay = 0;
                PlaySound();
                break;
            case ActionAfterDone.CustomAction:
                customAction.Invoke();
                break;
        }
    }

    List<int> GenerateRandomIntList(int Count)
    {
        List<int> tempList = new List<int>();

        for (int i = 0; i < Count;)
        {
            int rand = Random.Range(0, Count);

            bool appears = false;
            for (int j = 0; j < tempList.Count; j++)
            {
                if (rand == tempList[j])
                {
                    appears = true;
                }
            }
            if (!appears)
            {
                tempList.Add(rand);
                i++;
            }
        }

        return tempList;
    }

    public void UpdateAudio()
    {
        audioSource.volume = Volume;
        audioSource.minDistance = 0;
        audioSource.spatialBlend = SurroundSound ? 1 : 0;
        audioSource.maxDistance = SurroundSound ? Range : 0;
    }
}
