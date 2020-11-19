using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainButtons : MonoBehaviour
{
    public Button _play;
    public Button _instruct;
    public Button _settings;
    public Button _quit;
    // Start is called before the first frame update
    void Start()
    {
        _play.onClick.AddListener(ChangeSceneToPlay);
        _instruct.onClick.AddListener(ChangeSceneToInstruct);
        _settings.onClick.AddListener(ChangeSceneToSettings);
        _quit.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSceneToPlay()
    {
        SceneManager.LoadScene("Narration Scene 1", LoadSceneMode.Single);
    }

    public void ChangeSceneToInstruct()
    {
        SceneManager.LoadScene("Instructions", LoadSceneMode.Single);
    }

    public void ChangeSceneToSettings()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
