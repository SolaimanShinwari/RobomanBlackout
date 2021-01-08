using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    private GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    //Check if Level End Gate is collided with player so that we can change Scene to next Level
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == ("Player"))
        {
            TransitionController.Instance.ChangeScene();
            gm.lastCheckpointPos = new Vector2(-3.79f, 3.9f);
        }

    }
}
