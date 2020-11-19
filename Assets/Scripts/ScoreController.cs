using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreController
{
    private static int score = 0;
    public static void killEnemy()
    {
        score += 10;
    }

    public static int getScore()
    {
        return score;
    }
}
