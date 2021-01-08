using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManagerController : MonoBehaviour
{
    //Created a Virtual Camera Object so that we can get Cinemachine Player Virtual Camera reference in it
    public GameObject vCam1;

    //Created a Virtual Camera Object so that we can get Cinemachine Boss Area Virtual Camera reference in it
    public GameObject bossCam;

    //Created a Boss Area Entrance Door Gameobject in which we have Boss Area closing door
    public GameObject entranceDoor;

    //Created a Boss Object in which we have our Boss
    public GameObject boss;

    //Created Final Boss Message Canvas Object, which will display message after boss is defeated
    public GameObject FinalBossTextCanvas;

    //Ontrigger Function will called automatically whenever any collider with trigger enable touch this GameObject
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Checking Player Tag
        if(other.CompareTag("Player"))
        {
            //Diabled Boss Area Collider
            GetComponent<BoxCollider2D>().enabled = false;

            //Diabled Player Virtual Camera
            vCam1.SetActive(false);

            //Enabled Boss Virtual Camera
            bossCam.SetActive(true);

            //Enabled Boss Area Closing Door
            entranceDoor.SetActive(true);

            //Enabled Boss
            boss.SetActive(true);

            //This will stop Background Music and play Boss Background Music
            SoundManagerController.Instance.backgroundSound.Stop();
            SoundManagerController.Instance.bossSound.Play();
        }
    }

    public void EnableFinalTextCanvas()
    {
        //Enabled Boss Defeat Text
        FinalBossTextCanvas.SetActive(true);
    }
}
