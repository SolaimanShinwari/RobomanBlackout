using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    //Created a player GameObject so that we can get Player Reference in that using Tag
    GameObject player;

    //Boss moving speed towards player
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        //Getting reference of Player in player Object by finding Tag in scene
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //This line will call again and again in Update. Using Movetowards Boss can follow player position
         transform.position = Vector3.MoveTowards(transform.position,new Vector3(player.transform.position.x,transform.position.y,transform.position.z) , speed * Time.deltaTime);
    }

    //OnDestroy function automatically called when object is Destroyed
    private void OnDestroy()
    {
        //Enabling Final Text Message by Boss in Canvas by finding object of type
        FindObjectOfType<BossManagerController>().EnableFinalTextCanvas();
    }
}
