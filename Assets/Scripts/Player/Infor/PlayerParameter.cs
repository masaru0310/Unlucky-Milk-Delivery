using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerParameter : MonoBehaviour
{
    // �ϐ�
    private int _numOfMilkRemaining;        // ��z����~���N�̎c�萔

    // �v���p�e�B
    public int MilkRemainingProp
    {
        get { return _numOfMilkRemaining; }
        set { _numOfMilkRemaining = value; }
    }

    // �萔
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
    /// �~���N���P�z�B����
    /// </summary>
    public void DeliveredMilk()
    {
        _numOfMilkRemaining--;
    }
}
