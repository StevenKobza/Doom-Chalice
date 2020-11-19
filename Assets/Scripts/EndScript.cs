using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{
    public Image _image;
    public Sprite _part1;
    public Sprite _part2;
    public Sprite _part3;
    public Button _nextEnd;
    private int _currScene;

    // Start is called before the first frame update
    void Start()
    {
        _nextEnd.onClick.AddListener(nextEndScene);
        _currScene = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void nextEndScene()
    {
        Debug.Log(_currScene);
        switch(_currScene)
        {
            case 1:
                _currScene = 2;
                _image.sprite = _part2;
                break;
            case 2:
                _currScene = 3;
                _image.sprite = _part3;
                break;
            case 3:
                LeverController.changedScene();
                EnemyController.ChangedScene();
                SceneManager.LoadScene("Start");
                break;
        }
    }
}
