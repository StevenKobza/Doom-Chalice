using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public Button _back;
    // Start is called before the first frame update
    void Start()
    {
        _back.onClick.AddListener(ChangeSceneToMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSceneToMenu()
    {
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
}
