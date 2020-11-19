using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoType : MonoBehaviour
{
    public string _ammoName;
    private int _ammoCount = 30;
    public Ammo[] _pickups;
    public Text _ammoText;
    public string prefix;

    // Start is called before the first frame update
    void Start()
    {
        prefix = _ammoText.text;
        _pickups = FindObjectsOfType<Ammo>();
        _ammoText.text = prefix + " " + _ammoCount;
    }

    // Update is called once per frame
    void Update()
    {

        _ammoText.text = prefix + " " + _ammoCount;
    }
    public int GetCount()
    {
        return _ammoCount;
    }

    public void pickedUp()
    {
        _ammoCount += 20;
    }

    public void Fired()
    {
        _ammoCount--;
    }
}
