using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class DoorTrigger : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public BoxCollider boxCollider;
    public SphereCollider sphereCollider;
    public bool keyTrigger;
    public Keys trigger;
    private MeshRenderer[] meshRenderers;
    private BoxCollider[] boxColliders;
    public bool manualOpen = false;
    public NarrativeController nc;
    private bool open;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player" && !keyTrigger)
        {
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player" && !manualOpen)
        {
            meshRenderer.enabled = true;
            boxCollider.enabled = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (tag == "cage")
        {
           
            boxColliders = GetComponentsInChildren<BoxCollider>();
            meshRenderers = GetComponentsInChildren<MeshRenderer>();
        }
        else
        {
            sphereCollider = this.GetComponent<SphereCollider>();
            meshRenderer = this.GetComponent<MeshRenderer>();
            boxCollider = this.GetComponent<BoxCollider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        


        if (keyTrigger)
        {
            if (KeyScript.getKeyResponse(trigger))
            {
                sphereCollider.enabled = false;
                meshRenderer.enabled = false;
                boxCollider.enabled = false;
            }
        }
    }

    public void changeState()
    {
        if (this.name == "Cage bars 3 (1)")
        {
            
        }
        manualOpen = true;
        if (tag == "cage")
        {
            foreach (MeshRenderer mr in meshRenderers)
            {
                if (mr.enabled)
                {
                    mr.enabled = false;
                } else
                {
                    mr.enabled = true;
                }
            }
            foreach (BoxCollider bc in boxColliders)
            {
                if (bc.enabled)
                {
                    bc.enabled = false;
                } else
                {
                    bc.enabled = true;
                }
            }
            
        }
        if (meshRenderer != null && boxCollider != null && sphereCollider != null)
        {
            if (sphereCollider.enabled)
            {
                sphereCollider.enabled = false;
            }
            else
            {
                sphereCollider.enabled = true;
            }

            if (meshRenderer.enabled)
            {
                meshRenderer.enabled = false;
            }
            else
            {
                meshRenderer.enabled = true;
            }

            if (boxCollider.enabled)
            {
                boxCollider.enabled = false;
            }
            else
            {
                boxCollider.enabled = true;
            }
        }
    }
}
