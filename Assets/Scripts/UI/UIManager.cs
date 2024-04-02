using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // UI
    [SerializeField, Tooltip("�~���N�̎c���z��")]
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
        // �v���C���[�̏�񂪎擾�ł��Ă��Ȃ��ƁAUI�͕\�������Ȃ�
        if (FindPlayer() == false) return;

        DispRemainingMilk();
    }
  

    /// <summary>
    /// �v���C���[�̏����擾
    /// </summary>
    private bool FindPlayer()
    {
        if (_isFindPlayer == true) return true; 

        // �v���C���[����������
        if (GameObject.FindWithTag("Player") != null)
        {
            _isFindPlayer = true;
            // �v���C���[�ւ̎Q�Ƃ�ێ�
            _playerParameterObj = GameObject.FindWithTag("Player").GetComponent<PlayerParameter>();

            return true;
        }
        // �v���C���[��������Ȃ�
        else
        {
            return false;
        }
    }


    /// <summary>
    /// �~���N��\��
    /// </summary>
    public void DispRemainingMilk()
    {
        _remainingMilkText.text = _playerParameterObj.MilkRemainingProp.ToString();
    }
}
