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

    /// <summary>
    /// �Փ˂����v���C���[�I�u�W�F�N�g
    /// </summary>
    protected GameObject bikeThatCollided;

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
    protected void OnTriggerEnter(Collider other)
    {
        // �@ �G�ꂽ�̂��A�v���C���[�ȊO�������珈�����I��
        if (other.gameObject.tag != "Player") return;

        // �A �e�~�j�Q�[�����Ƃ̊J�n������B�����Ă��Ȃ�������I��
        // �� ����!! �����́A�p����Œ�`�����
        if (IsJudgeStart() == false) return;

        // �B �~�j�Q�[���������邽�߂̕����ɐi�s���Ă��邩
        if (IsJudgeInRightDirection(other) == false) return;

        // �~�j�Q�[���J�n�����߂闐�����o��
        int randomNum = Random.Range(1, 100);

        // �� �����Ńv���C���[�̏��ʂ��m�F���A���ʂɂ���Ċm����ύX������

        // �C ����������m�����������Ă���A�p����ŕs�^�~�j�Q�[���J�n
        if (randomNum <= incidenceNum)
        {
            isStartMinigame = true;

            // �Փ˂����o�C�N�I�u�W�F�N�g���擾 �� �p����Ŏg�p�����
        }
    }


    private bool IsJudgeInRightDirection(Collider other)
    {
        // ��܂��ȏՓˈʒu�����o
        Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);

        // �~�j�Q�[�������G���A���猩���v���C���[�̏Փˈʒu�̊p�x���擾
        Vector3 diff = hitPos - transform.position;
        Vector3 axis = Vector3.Cross(transform.forward, diff);
        float angle = Vector3.Angle(transform.forward, diff) * (axis.y < 0 ? -1 : 1);

        Debug.Log($"�p�x : {angle}");

        if ((angle <= 145.9f && angle >= 128.0f) || (angle >= -145.9f && angle <= -128.0f))
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


    /// <summary>
    /// �~�j�Q�[���I�����̏���
    /// </summary>
    private void EndMinigame()
    {


    }

}
