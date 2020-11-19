using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NarrationButtons : MonoBehaviour
{
    public Button _next;
    // Start is called before the first frame update
    void Start()
    {
        _next.onClick.AddListener(nextScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextScene()
    {
        switch(tag)
        {
            case "scene1":
                SceneManager.LoadScene("Narration Scene 2", LoadSceneMode.Single);
                break;
            case "scene2":
                SceneManager.LoadScene("Narration Scene 3", LoadSceneMode.Single);
                break;
            case "scene3":
                SceneManager.LoadScene("Narration Scene 4", LoadSceneMode.Single);
                break;
            case "scene4":
                SceneManager.LoadScene("StageZero", LoadSceneMode.Single);
                break;
        }
    }
}
