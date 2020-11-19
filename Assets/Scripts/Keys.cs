using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keys : MonoBehaviour
{
    public string Tag;
    public bool inInventory;
    private CapsuleCollider capsuleCollider;
    private MeshRenderer meshRenderer;
    public NarrativeController nC;

    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = this.GetComponent<CapsuleCollider>();
        meshRenderer = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!inInventory)
            {
                if (SceneManager.GetActiveScene().name == "StageTwoPointOneDungeon")
                {
                    //nC.DisplayText("You have gotten the key, the door is now open");
                } else if (SceneManager.GetActiveScene().name == "StageThree")
                {
                    //nC.DisplayText("inside the chest, you find a scroll wrapped around a mysterious scroll");
                }
                inInventory = true;
                capsuleCollider.enabled = false;
                meshRenderer.enabled = false;

            }
        }
    }
}
