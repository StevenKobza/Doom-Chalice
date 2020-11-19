using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public AmmoType _parent;
    public SpriteRenderer _ammoSpriteR;
    public Sprite _ammoSprite;
    public Text _ammoText;

    private void Start()
    {
        _parent = FindObjectOfType<AmmoType>();
        _ammoSpriteR = GetComponentInChildren<SpriteRenderer>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _parent.pickedUp();
            Destroy(this.gameObject);
        }
    }

    
}
