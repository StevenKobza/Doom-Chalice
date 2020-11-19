using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public string _weaponName;
    public AmmoType _ammoType;
    public Image _weaponSpriteR;
    public Sprite _weaponSprite;
    public AmmoType[] findRightOne;
    public AudioSource _audio;
    public AudioClip clip;
    public Animator animator;

    private void Start()
    {
        findRightOne = FindObjectsOfType<AmmoType>();
        if (_weaponName == "shotgun")
        {
            foreach (AmmoType a in findRightOne)
            {
                if (a.CompareTag("shells"))
                {
                    _ammoType = a;
                }
            }
        } else if (_weaponName == "laser")
        {
            foreach (AmmoType a in findRightOne)
            {
                if (a.CompareTag("laserBeam"))
                {
                    _ammoType = a;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.instance.addWeapon(this);
            Destroy(GetComponentInChildren<SpriteRenderer>());
        }
    }

    public void setCurrentGun()
    {
        _weaponSpriteR.sprite = _weaponSprite;
    }

    public bool CanShoot()
    {
        return _ammoType.GetCount() > 0;
    }

    public void Fired()
    {
        animator.SetTrigger("Shoot");
        _audio.PlayOneShot(clip);
        _ammoType.Fired();
    }
}
