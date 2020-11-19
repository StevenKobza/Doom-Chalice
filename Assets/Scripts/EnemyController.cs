using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyController
{
    private static List<Enemy> enemies = new List<Enemy>();
    private static List<string> enemyTags = new List<string>();
    private static int enemiesKilled = 0;
    private static float dropRate;

    public static void AddEnemy(string tag, Enemy e)
    {
        enemies.Add(e);
        enemyTags.Add(tag);
    }

    public static void killEnemy(GameObject go)
    {
        ScoreController.killEnemy();
        int tempIndex = enemies.FindIndex(x => x.gameObject.name == go.name);

        Debug.Log(enemies[tempIndex].dead);
        string tempTag = enemyTags[tempIndex];
        Debug.LogError("Tag: " + tempTag + " index: " + tempIndex);
        enemies[tempIndex].Shot();
    }

    public static void killed()
    {
        enemiesKilled++;
    }

    public static void ChangedScene()
    {
        enemiesKilled = 0;
        enemies.Clear();
        enemyTags.Clear();
    }
   
    public static bool drop()
    {
        dropRate = Random.Range(0f, 100f);
        if (dropRate < 25f)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
