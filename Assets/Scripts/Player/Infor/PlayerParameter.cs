using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerParameter : MonoBehaviour
{
    // 変数
    private int _numOfMilkRemaining;        // 宅配するミルクの残り数

    // プロパティ
    public int MilkRemainingProp
    {
        get { return _numOfMilkRemaining; }
        set { _numOfMilkRemaining = value; }
    }

    // 定数
    private const int MAX_MILK = 3;

    // Start is called before the first frame update
    void Start()
    {
        _numOfMilkRemaining = MAX_MILK;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// ミルクを１個配達完了
    /// </summary>
    public void DeliveredMilk()
    {
        _numOfMilkRemaining--;
    }
}
