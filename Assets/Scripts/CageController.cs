using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CageController : MonoBehaviour
{
    private GameObject[] leverGOArray;
    private List<LeverFlip> leverFlips;
    private MeshRenderer[] meshRenderers;
    private BoxCollider[] boxColliders;
    public NarrativeController nC;

    // Start is called before the first frame update
    void Start()
    {
        leverFlips = new List<LeverFlip>();
        leverGOArray = GameObject.FindGameObjectsWithTag("lever");
        foreach (GameObject i in leverGOArray)
        {
            if (i.name != "leverScene1Exit")
            {
                leverFlips.Add(i.GetComponent<LeverFlip>());
            }
        }
        Debug.Log(leverGOArray.Length);
        meshRenderers = this.GetComponentsInChildren<MeshRenderer>();
        boxColliders = this.GetComponentsInChildren<BoxCollider>();
        Debug.Log(meshRenderers.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (LeverController.checkAll(leverFlips))
        {
            foreach (MeshRenderer i in meshRenderers)
            {
                i.enabled = false;
            }
            foreach (BoxCollider i in boxColliders)
            {
                i.enabled = false;
            }
            if (SceneManager.GetActiveScene().name == "StageOne")
            {
                //nC.DisplayText("How did you get here?");
                //nC.DisplayHead("luther");
            }
        } else
        {
            foreach (MeshRenderer i in meshRenderers)
            {
                i.enabled = true;
            }
            foreach (BoxCollider i in boxColliders)
            {
                i.enabled = true;
            }
        }
    }
}
