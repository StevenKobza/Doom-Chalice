using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    private string _text;
    private Sprite _headToShow;
    private int _index;

    public Conversation(string _text, Sprite _headToShow, int _index)
    {
        this._text = _text;
        this._headToShow = _headToShow;
        this._index = _index;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetText()
    {
        return _text;
    }
    
    public int GetIndex()
    {
        return _index;
    }

    public Sprite GetHead()
    {
        return _headToShow;
    }
}
