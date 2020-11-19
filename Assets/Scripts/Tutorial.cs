using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public MeshRenderer[] ghostGate;
    public NarrativeController nC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (this.tag)
            {
                case "weaponTut":
                    nC.DisplayText("Press \"2\" or \"1\" to change your weapons");
                    break;
                case "leverTut":
                    nC.DisplayText("Press \"E\" to interact with the lever");
                    break;
                case "lutherTut":
                    nC.DisplayText("Press \"E\" to interact with the ghost behind the bars");
                    
                    break;
                case "enemyTut":
                    nC.DisplayText("Press \"Left Click\" to fire. Enemies have 3 health, so you must hit them 3 times");
                    break;
                case "movementTut":
                    nC.DisplayText("Press \"W\", \"A\", \"S\", \"D\" to move around");
                    break;
                case "jumpTut":
                    nC.DisplayText("Press \"Space Bar\" to jump");
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nC.StopDisplay();
        }
    }
}
