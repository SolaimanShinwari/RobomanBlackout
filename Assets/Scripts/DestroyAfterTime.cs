using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    //Time variable after which user wants to destroy this GameObject
    public float time = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy Gameobject after a specific time passed using time variable
        Destroy(this.gameObject, time);
    }

}
