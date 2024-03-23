using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DispTextForBike : MonoBehaviour
{
    [SerializeField] private Text _textWhiteMinigame;
    [SerializeField] private Text _textBlackMinigame;
    [SerializeField] private Image _imageofMinigame;

    // テキスト

    // Start is called before the first frame update
    void Start()
    {
        _textWhiteMinigame.enabled = false;
        _textBlackMinigame.enabled = false;
        _imageofMinigame.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DispText()
    {
        _textWhiteMinigame.enabled = true;
        _textBlackMinigame.enabled = true;
        _imageofMinigame.enabled = true;
    }

}
