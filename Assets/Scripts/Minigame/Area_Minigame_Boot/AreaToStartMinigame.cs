using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaWhereMinigame : MonoBehaviour
{
    // �O���Q�[���N���X
    

    // �ϐ�
    [SerializeField] private MinigameData.ID _minigameID;            // ����ID�Ɋ�Â��A�J�n����~�j�Q�[�������߂�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<BikeController>() == true)
        {
            // �~�j�Q�[���X�^�[�g
        }
    }
}
