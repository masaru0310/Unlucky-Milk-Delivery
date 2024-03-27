using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameBase : MonoBehaviour
{
    /// <summary>
    /// �����m��
    /// </summary>
    protected int incidenceNum;

    /// <summary>
    /// true : �~�j�Q�[���J�n, false : �~�j�Q�[���s��
    /// </summary>
    public bool isStartMinigame;

    void Start()
    {
        incidenceNum = 40;
        isStartMinigame = false;
    }




    /// <summary>
    /// �~�j�Q�[�������G���A�ɐG�ꂽ��̏���
    /// </summary>
    /// <param name="other"></param>
    protected void OnTriggerEnter(Collider other)
    {
        Debug.Log("�Փ�");

        // �@ �G�ꂽ�̂��A�v���C���[�ȊO�������珈�����I��
        if (other.gameObject.tag != "Player") return;
        Debug.Log("�G�ꂽ�̂��o�C�N");

        // �A �~�j�Q�[���̊J�n������B�����Ă��Ȃ�������I��
        if (IsJudgeStart() == false) return;

        // �~�j�Q�[���J�n�����߂闐�����o��
        int randomNum = Random.Range(1, 100);

        Debug.Log($"���� : {randomNum}");

        // �� �����Ńv���C���[�̏��ʂ��m�F���A���ʂɂ���Ċm����ύX������

        // �B ����������m�����������Ă���A�s�^�~�j�Q�[���J�n
        if (randomNum <= incidenceNum) isStartMinigame = true;
    }


    /// <summary>
    /// �G�ꂽ���ƒǉ��ł̔�������
    /// </summary>
    /// <returns></returns>
    protected virtual bool IsJudgeStart()
    {
        if (true)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    /// <summary>
    /// �~�j�Q�[���������̏���
    /// </summary>
    protected virtual void FuncMinigame()
    {

    }
}
