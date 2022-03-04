using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Opening : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonPress;
    public AudioClip powerDown;
    public Light lightComponent;
    public GameObject floor;
    public GameObject startBox;
    
    public GameObject playerHead;
    public GameObject playerBody;
    public Material whileLight;
    public AudioClip powerOn;

    public AudioSource bgmPlayer;
    private bool isStart;

    public Text thankText;
    
    void Start()
    {
        lightComponent.color = Color.white;
        floor.GetComponent<Renderer>().material.color = new Color(0.48f, 0.49f, 0.49f);
        startBox.GetComponent<Renderer>().material.color = Color.white;
        isStart = false;
        bgmPlayer.volume = 1.0f;
    }

    void Update()
    {
        if (isStart)
        {
            bgmPlayer.volume -= Time.deltaTime;
        }
    }

    public void OpeningMovie()
    {
        audioSource.PlayOneShot(buttonPress);
        isStart = true;
        Invoke(nameof(Darken), 1.5f);
        Invoke(nameof(Lighten), 3.0f);
        Invoke(nameof(SceneChange), 4.0f);
    }

    void Darken()
    {
        lightComponent.color = Color.black;
        floor.GetComponent<Renderer>().material.color = Color.black;
        startBox.GetComponent<Renderer>().material.color = Color.black;

        audioSource.PlayOneShot(powerDown);
    }

    void Lighten()
    {
        playerHead.GetComponent<Renderer>().material = whileLight;
        playerBody.GetComponent<Renderer>().material = whileLight;

        audioSource.PlayOneShot(powerOn);
    }

    void SceneChange()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnPressExitButton()
    {
        audioSource.PlayOneShot(buttonPress);
        Invoke(nameof(Darken), 1.5f);
        Invoke(nameof(EnableThankText), 1.5f);
        Invoke(nameof(Exit), 3.0f);
    }

    void EnableThankText()
    {
        thankText.gameObject.SetActive(true);
    }

    void Exit()
    {
        Application.Quit();
    }
}
