using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // UI
    [SerializeField, Tooltip("ミルクの残り宅配数")]
    private Text _remainingMilkText;

    private PlayerParameter _playerParameterObj;
    private bool _isFindPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _isFindPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの情報が取得できていないと、UIは表示させない
        if (FindPlayer() == false) return;

        DispRemainingMilk();
    }
  

    /// <summary>
    /// プレイヤーの情報を取得
    /// </summary>
    private bool FindPlayer()
    {
        if (_isFindPlayer == true) return true; 

        // プレイヤーが見つかった
        if (GameObject.FindWithTag("Player") != null)
        {
            _isFindPlayer = true;
            // プレイヤーへの参照を保持
            _playerParameterObj = GameObject.FindWithTag("Player").GetComponent<PlayerParameter>();

            return true;
        }
        // プレイヤーが見つからない
        else
        {
            return false;
        }
    }


    /// <summary>
    /// ミルクを表示
    /// </summary>
    public void DispRemainingMilk()
    {
        _remainingMilkText.text = _playerParameterObj.MilkRemainingProp.ToString();
    }
}
