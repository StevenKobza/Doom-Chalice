using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public Button _consume;
    public Button _destroy;

    // Start is called before the first frame update
    void Start()
    {
        _consume.onClick.AddListener(ConsumeStone);
        _destroy.onClick.AddListener(DestroyStone);
    }

    void ConsumeStone()
    {
        SceneManager.LoadScene("ConsumeStone", LoadSceneMode.Single);
    }

    void DestroyStone()
    {
        SceneManager.LoadScene("DestroyStone", LoadSceneMode.Single);

    }
}
