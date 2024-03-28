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
    /// ����!! �C�̏����𖞂����ƁA�~�j�Q�[�����J�n�����
    /// </summary>
    /// <param name="other"></param>
    protected void OnCollisionEnter(Collision collision)
    {
        // �@ �G�ꂽ�̂��A�v���C���[�ȊO�������珈�����I��
        if (collision.gameObject.tag != "Player") return;

        // �A �e�~�j�Q�[�����Ƃ̊J�n������B�����Ă��Ȃ�������I��
        // �� ����!! �����́A�p����Œ�`�����
        if (IsJudgeStart() == false) return;

        // �B �~�j�Q�[���������邽�߂̕����ɐi�s���Ă��邩
        if (IsJudgeInRightDirection(collision) == false) return;

        // �~�j�Q�[���J�n�����߂闐�����o��
        int randomNum = Random.Range(1, 100);

        // �� �����Ńv���C���[�̏��ʂ��m�F���A���ʂɂ���Ċm����ύX������

        // �C ����������m�����������Ă���A�p����ŕs�^�~�j�Q�[���J�n
        if (randomNum <= incidenceNum) isStartMinigame = true;
    }


    private bool IsJudgeInRightDirection(Collision collision)
    {
        // ��܂��ȏՓˈʒu�����o
        Vector3 hitPos = collision.contacts[0].point;

        // �L�����N�^�[���ʂ��猩���Փˈʒu�̊p�x���擾
        Vector3 diff = hitPos - transform.position;
        Vector3 axis = Vector3.Cross(transform.forward, diff);
        float angle = Vector3.Angle(transform.forward, diff) * (axis.y < 0 ? -1 : 1);

        Debug.Log($"�p�x : {angle}");

        if ((angle <= 145.0f && angle >= 128.0f) || (angle >= -145.0f && angle <= -128.0f))
        {
            //// �R���W�������猩�āA�v���C���[���܂������i��ł��邩���m�F
            //if (Mathf.Abs(angle) <= 90.0f)
            //{
            //    return true;
            //}
            //// �ʂ̊p�x����Փ˂����ꍇ�́A�~�j�Q�[�����������𖞂����Ȃ�
            //else return false;
            Debug.Log("���ʂ���ːi");
            return true;
        }
        else
        {
            Debug.Log("���ʂ���ːi���Ă��Ȃ�");
            return false;
        }
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
