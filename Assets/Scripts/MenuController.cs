using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //Created a Variable of Animator that will store Animator reference attached to Main Menu Canvas

    Animator menuAnim;

    //Sound Mute, Unmute Gameobjects reference objects
    public GameObject muteButton;
    public GameObject unMuteButton;

    private void Awake()
    {
        //Chaneg Game TimeScale to 1 so that it can run without stop
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Check if Audio of Game is muted or not so that Enable,disable sounds button accordingly
        if(AudioListener.volume==0)
        {
            muteButton.SetActive(true);
            unMuteButton.SetActive(false);
        }
        if (AudioListener.volume == 1)
        {
            muteButton.SetActive(false);
            unMuteButton.SetActive(true);
        }

        //Stores reference of Animator attached to Main Menu Canvas
        menuAnim = GetComponent<Animator>();

        //Play Background Music on Start in a Loop
        SoundManagerController.Instance.backgroundSound.Play();

        //Stops Boss Background Music on Start if Playing
        SoundManagerController.Instance.bossSound.Stop();
    }

    //Function which will mute all sounds of game by changing Volume of Audio Listener to 0
    public void MuteSound()
    {
        AudioListener.volume = 0;
    }

    //Function which will Unmute all sounds of game by changing Volume of Audio Listener to 1
    public void UnMuteSound()
    {
        AudioListener.volume = 1;
    }

    //Function which will Start Game Starting Text and then Change Scene
    public void Play()
    {
        SoundManagerController.Instance.clickSound.Play();
        menuAnim.Play("Menu");
    }

    //Function to Exit Game
    public void Exit()
    {
        Application.Quit();
    }

    //Change Scene to Level1 after Game Starting Text is finished
    public void ChangeScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
