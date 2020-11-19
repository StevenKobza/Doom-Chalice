using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public string _tag;
    public MeshRenderer _outerR;
    public MeshCollider _outerC;
    public MeshRenderer _innerR;
    public MeshCollider _innerC;
    public Light _light;
    private bool inInventory;

    // Start is called before the first frame update
    void Start()
    {
        _outerC = GetComponent<MeshCollider>();
        _outerR = GetComponent<MeshRenderer>();
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
                _innerC.enabled = false;
                _innerR.enabled = false;
                _outerC.enabled = false;
                _outerR.enabled = false;
                _light.enabled = false;
                inInventory = true;
            }
        }
    }
}
