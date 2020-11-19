using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestController : MonoBehaviour
{
    public NarrativeController controller;
    public Animator _animator;
    public bool opening;
    public AnimatorStateInfo asi;

    // Start is called before the first frame update
    void Start()
    {
        asi = new AnimatorStateInfo();
        _animator.StopPlayback();
    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {
            openChest();
        }
    }

    public void openChest()
    {
        //Sets the boolean variable in the animator to be true allowing it to run
        _animator.SetBool("Open", true);
        if (SceneManager.GetActiveScene().name == "StageThree")
        {
            controller.StartConvo("afterKey");
        } else if (SceneManager.GetActiveScene().name == "StageFiveIntro")
        {
            controller.StartConvo("afterScroll");
        }
        opening = false;
    }
}
