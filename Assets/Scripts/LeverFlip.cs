using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverFlip : MonoBehaviour
{
    public bool flipped;
    public GameObject parent;
    public LeverFlip _instance;
    public GameObject _this;
    public bool doorFlipper;
    public GameObject _door1;
    public DoorTrigger[] _door1Array;
    public GameObject _door2;
    public DoorTrigger[] _door2Array;

    // Start is called before the first frame update
    void Start()
    {
        if (_door1 != null)
        {
            _door1Array = _door1.GetComponentsInChildren<DoorTrigger>();
        }
        if (_door2 != null)
        {
            _door2Array = _door2.GetComponentsInChildren<DoorTrigger>();
        }
        flipped = false;
        _this = this.gameObject;
        LeverController.addLever(_this, this);
    }

    public void FlipLever()
    {
        parent.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x - 90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        if (flipped)
        {
            flipped = false;
        } else
        {
            flipped = true;
        }
        if (doorFlipper)
        {
            foreach (DoorTrigger t in _door1Array)
            {
                t.changeState();
            }
            foreach (DoorTrigger t in _door2Array)
            {
                t.changeState();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getFlipped()
    {
        return flipped;
    }
}
