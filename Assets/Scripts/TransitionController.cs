using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    //Created Instance of TransitionController Class so that other classes can Access it
    public static TransitionController Instance;

    //Stores reference of Image which appears as transition between all scenes
    [SerializeField] Image transitionImage;

    //Bool variable if user wants Transition on Level start or not
    [SerializeField] bool transitOnStart = true;

    //Scene name after so that it can be loaded after Level End Transition
    [SerializeField] string sceneName;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Starts Coroutine which will Unfade black transition screen on Level Start
        if (transitOnStart)
        {
            StartCoroutine("UnFadeRoutine");
        }
    }

    IEnumerator UnFadeRoutine()
    {
        transitionImage.color = new Color(0, 0, 0, 1);

        while (true)
        {
            transitionImage.color = Color.LerpUnclamped(transitionImage.color, new Color(0, 0, 0, 0), 1 * Time.deltaTime);
            if(transitionImage.color==new Color(0,0,0,0))
            {
                break;
            }
            yield return null;
        }
    }

    //Starts Coroutine which will Fade black transition screen on Level End and Load Next Scene
    public void ChangeScene()
    {
        StartCoroutine("FadeRoutine");
    }

    IEnumerator FadeRoutine()
    {
        transitionImage.color = new Color(0, 0, 0, 0);

        while (true)
        {
            transitionImage.color = Color.LerpUnclamped(transitionImage.color, new Color(0, 0, 0, 1), 5 * Time.deltaTime);
            if (transitionImage.color == new Color(0, 0, 0, 1))
            {
                break;
            }
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
        SoundManagerController.Instance.backgroundSound.Stop();
        SoundManagerController.Instance.backgroundSound.Play();
    }


    //Load Level without Transition Directly
    public void ChangeSceneDirectly()
    {
        SceneManager.LoadScene(sceneName);
        SoundManagerController.Instance.backgroundSound.Stop();
        SoundManagerController.Instance.backgroundSound.Play();
    }
}
