using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NarrativeController: MonoBehaviour
{
    public Sprite _luther;
    public Sprite _nic;
    public List<string> vs;

    public Text _textBox;
    public Image _headImg;
    public Image _background;

    private int conversationPoint;

    private void Start()
    {
        if (_luther && _nic != null)
        {
            SpriteHolder._luther = _luther;
            SpriteHolder._nic = _nic;
        }
        vs = ConversationHolder.AddCurrentStrings(SceneManager.GetActiveScene().name);
    }


    public void DisplayText(string _text)
    {
        _textBox.text = _text;
        _textBox.enabled = true;
        _background.enabled = true;
    }

    public void StopDisplay()
    {
        _textBox.enabled = false;
        _background.enabled = false;
    }

    public void DisplayHead(string _head)
    {
        if (_head == "luther")
        {
            _headImg.sprite = _luther;
        } else if (_head == "nic")
        {
            _headImg.sprite = _nic;
        }
    }

    public void StartConvo()
    {
        DisplayText(vs[0]);
        conversationPoint = 0;
    }

    public void StartConvo(string where)
    {
        
        conversationPoint = 0;
        PlayerController.instance.convoStarted();
        switch (where)
        {
            case "afterKey":
                vs = ConversationHolder.AddAfterStage3KeyStrings();
                break;
            case "enemyDead":
                vs = ConversationHolder.AddAfterEnemiesDeadDungeon2();
                break;
            case "afterPuzzleSolved":
                vs = ConversationHolder.AddAfterPuzzleSolvedLibrary2();
                break;
            case "afterScroll":
                vs = ConversationHolder.AddAfterScrollFound();
                break;
        }
        DisplayText(vs[0]);
    }

    public void ContinueConvo()
    {
        if (conversationPoint < vs.Count -1)
        {
            conversationPoint++;
            DisplayText(vs[conversationPoint]);
        } else
        {
            _textBox.enabled = false;
            _background.enabled = false;
            PlayerController.instance.convoFinished();
        }
    }

}
