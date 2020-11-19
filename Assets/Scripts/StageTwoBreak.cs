using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageTwoBreak : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player") && this.name == "Dungeon entrance placeholder")
        {
            SceneManager.LoadScene("StageTwoPointOneDungeon", LoadSceneMode.Single);
        } else if (other.CompareTag("player") && this.name == "Library entrance placeholder")
        {
            SceneManager.LoadScene("StageTwoPointTwoLibrary", LoadSceneMode.Single);
        }
    }
}
