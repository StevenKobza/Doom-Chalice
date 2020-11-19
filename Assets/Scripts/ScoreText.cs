using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = ScoreController.getScore();
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        score = ScoreController.getScore();
        scoreText.text = "Score: " + score;
    }
}
