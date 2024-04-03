using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // UI
    [SerializeField, Tooltip("ミルクの残り宅配数")]
    private Text _remainingMilkText;
    [SerializeField, Tooltip("ミルクお届け時のUI")]
    private GameObject _deliveredMilkImage;

    private PlayerParameter _playerParameterObj;
    private bool _isFindPlayer;

    // プロパティ

    /// <summary>
    /// ミルクお届け時のUIを表示、非表示を切り替え
    /// </summary>
    public bool IsDeliveredMilkImageActiveProp
    {
        set { _deliveredMilkImage.SetActive(value); }
    }

    // Start is called before the first frame update
    void Start()
    {
        _isFindPlayer = false;

        _deliveredMilkImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの情報が取得できていないと、UIは表示させない
        if (FindPlayer() == false) return;

        DispRemainingMilk();
    }
  

    /// <summary>
    /// プレイヤーのインスタンスを見つける
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
        if (_playerParameterObj != null)
        {
            _remainingMilkText.text = _playerParameterObj.MilkRemainingProp.ToString();
        }
    }
}
