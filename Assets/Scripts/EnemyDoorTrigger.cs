using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoorTrigger : MonoBehaviour
{
    public GameObject _areaToSearch;
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;
    private Enemy[] _enemiesToTrigger;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
        boxCollider = this.GetComponent<BoxCollider>();
        _enemiesToTrigger = _areaToSearch.GetComponentsInChildren<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        bool temp = true;
        foreach (Enemy i in _enemiesToTrigger)
        {
            if (i.dead == false)
            {
                temp = false;
            } 
        }

        if (temp == true)
        {
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
        } else if (temp == false)
        {
            meshRenderer.enabled = true;
            boxCollider.enabled = true;
        }
    }
}
