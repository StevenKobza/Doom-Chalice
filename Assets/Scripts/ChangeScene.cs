using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*//This is similar to how you would do it.
        if (LeverController.getStateOfLever(this.name))
        {
            switch(this.name)
            {
                case "leverTutorialExit":
                    LeverController.changedScene();
                    EnemyController.ChangedScene();
                    //to check the current scene it is
                    //SceneManager.GetActiveScene(); this is the actual scene
                    //SceneManager.GetActiveScene().name; this is the name of the scene
                    SceneManager.LoadScene("StageOne", LoadSceneMode.Single);//This right here is how you load scene.
                    break;
                case "leverScene1Exit":
                    LeverController.changedScene();
                    LeverController.changedScene();
                    SceneManager.LoadScene("StageTwo", LoadSceneMode.Single);
                    break;
                case "leverScene2Dungeon":
                    LeverController.changedScene();
                    LeverController.changedScene();
                    SceneManager.LoadScene("StageTwoPointOneDungeon", LoadSceneMode.Single);
                    break;
                case "leverScene2Library":
                    LeverController.changedScene();
                    LeverController.changedScene();
                    SceneManager.LoadScene("StageTwoPointTwoLibrary", LoadSceneMode.Single);
                    break;
                case "leverLibraryExit":
                    
                    break;
                case "leverDungeonExit":

                    break;
            }
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch(SceneManager.GetActiveScene().name)
            {
                case "StageZero":
                    LeverController.changedScene();
                    EnemyController.ChangedScene();
                    SceneManager.LoadScene("StageOne", LoadSceneMode.Single);
                    break;
                case "StageOne":
                    LeverController.changedScene();
                    EnemyController.ChangedScene();
                    SceneManager.LoadScene("StageTwo", LoadSceneMode.Single);
                    break;
                case "StageTwo":
                    LeverController.changedScene();
                    EnemyController.ChangedScene();
                    if (this.CompareTag("dungeonEnt"))
                    {
                        SceneManager.LoadScene("StageTwoPointOneDungeon", LoadSceneMode.Single);
                    } else if (this.CompareTag("libraryEnt"))
                    {
                        SceneManager.LoadScene("StageTwoPointOneDungeon", LoadSceneMode.Single);
                    }
                    break;
                case "StageTwoPointOneDungeon":
                    LeverController.changedScene();
                    EnemyController.ChangedScene();
                    SceneManager.LoadScene("StageThree", LoadSceneMode.Single);
                    break;
                case "StageTwoPointTwoLibrary":
                    LeverController.changedScene();
                    EnemyController.ChangedScene();
                    SceneManager.LoadScene("StageThree", LoadSceneMode.Single);
                    break;
                case "StageThree":
                    LeverController.changedScene();
                    EnemyController.ChangedScene();
                    if (this.CompareTag("dungeonEnt"))
                    {
                        SceneManager.LoadScene("StageFourPointOneDungeon", LoadSceneMode.Single);
                    } else if (this.CompareTag("libraryEnt"))
                    {
                        SceneManager.LoadScene("StageFourPointTwoLibrary", LoadSceneMode.Single);
                    }
                    break;
                case "SceneFourPointOneDungeon":
                    LeverController.changedScene();
                    EnemyController.ChangedScene();
                    SceneManager.LoadScene("StageFiveIntro", LoadSceneMode.Single);
                    break;
                case "StageFourPointTwoLibrary":
                    LeverController.changedScene();
                    EnemyController.ChangedScene();
                    SceneManager.LoadScene("StageFiveIntro", LoadSceneMode.Single);
                    break;
                case "StageFiveIntro":
                    LeverController.changedScene();
                    EnemyController.ChangedScene();
                    SceneManager.LoadScene("StageFive", LoadSceneMode.Single);
                    break;
            }
        }
    }
}
