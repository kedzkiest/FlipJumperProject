using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // ============= Audio ================
    // Audio Source component attached on the character
    public AudioSource audioSource;
    // Audio Clip for Start
    public AudioClip startAudio;
    // Audio Clip for Add Force
    public AudioClip addForceAudio;
    // start jump audio
    public AudioClip jumpAudio;
    // Audio Clip for Successful Jump
    public AudioClip landingAudio;
    // Audio Clip for failure
    public AudioClip fallAudio;

    public AudioSource onStartCrowdCheering;

    public AudioClip successClip;

    // Start is called before the first frame update
    void Start()
    {
        // Play the audio clip for start the game
        PlayAudio(enumAudioClip.Start);
    }


    public CelebrationParticle cp;
    private bool isCalledOnce = false;
    void Update()
    {
        if (!cp.goalAchieved)
        {
            isCalledOnce = false;
        }
        
        if (cp.goalAchieved && !isCalledOnce)
        {
            isCalledOnce = true;
            onStartCrowdCheering.clip = successClip;
            onStartCrowdCheering.Play();
        }
    }

    /// <summary>
    /// play audio clip
    /// </summary>
    /// <param name="audioClip"></param>
    public void PlayAudio(enumAudioClip enumValue)
    {
        if (enumValue == enumAudioClip.Start)
        {
            onStartCrowdCheering.PlayOneShot(startAudio);
            //audioSource.clip = startAudio;
        }
        if (enumValue == enumAudioClip.AddForce)
        {
            audioSource.clip = addForceAudio;
        }
        if (enumValue == enumAudioClip.Jump)
        {
            audioSource.clip = jumpAudio;
        }
        if (enumValue == enumAudioClip.Success)
        {
            audioSource.clip = landingAudio;
            //onStartCrowdCheering.PlayOneShot(landingAudio);
        }
        if (enumValue == enumAudioClip.Fall)
        {
            audioSource.clip = fallAudio;
        }

        audioSource.Play();
    }
}
