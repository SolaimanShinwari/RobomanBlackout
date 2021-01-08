using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    private GameMaster gm;

    //Bool variable which returns if Game is paused or not
    bool isPause = false;

    //Sound Mute, Unmute Gameobjects reference objects
    public GameObject muteButton;
    public GameObject unMuteButton;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        //Chaneg Game TimeScale to 1 so that it can run without stop
        Time.timeScale = 1;

        //Check if Audio of Game is muted or not so that Enable,disable sounds button accordingly
        if (AudioListener.volume == 0)
        {
            muteButton.SetActive(true);
            unMuteButton.SetActive(false);
        }
        if (AudioListener.volume == 1)
        {
            muteButton.SetActive(false);
            unMuteButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //On Escape Button click if Game is not Paused then change TimeScale to 0 and enable Pause Menu
        if(Input.GetKeyDown(KeyCode.Escape) && isPause==false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Time.timeScale = 0;
            isPause = true;
        }
        //On Escape Button click if Game is Paused then change TimeScale to 1 and disable Pause Menu
        else if (Input.GetKeyDown(KeyCode.Escape) && isPause == true)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            Time.timeScale = 1;
            isPause = false;
        }
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

    //Function which will Play Click sound and Restart Current Scene
    public void RestartScene()
    {
        // ensures checkpoint is removed since level has been restared
        gm.lastCheckpointPos = new Vector2(-3.79f, 3.9f);
        SoundManagerController.Instance.clickSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // ensures checkpoint is removed from level 1 in case menu is pressed and game is started from level 1
        gm.lastCheckpointPos = new Vector2(-3.79f, 3.9f);
        SoundManagerController.Instance.backgroundSound.Play();
        SoundManagerController.Instance.bossSound.Stop();
    }

    //Function which will Play Click sound and Load Menu Scene
    public void MenuScene()
    {
        SoundManagerController.Instance.clickSound.Play();
        SceneManager.LoadScene("Menu");
    }
}
