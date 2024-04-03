using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    // �ϐ�
    public bool _isTouchThePlayer;     // true : �v���C���[�ɐG��Ă���, false : �v���C���[�ɐG��Ă��Ȃ�
    private GameObject _touchedObject;  // �G�ꂽ�I�u�W�F�N�g

    private UIManager _uiManagerObj;

    // Start is called before the first frame update
    void Start()
    {
        _isTouchThePlayer = false;

        // UI�}�l�[�W���[���擾
        if (GameObject.FindWithTag("Canvas").GetComponent<UIManager>() != null)
        {
            _uiManagerObj = GameObject.FindWithTag("Canvas").GetComponent<UIManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isTouchThePlayer == true)
        {
            Debug.Log("Space�{�^���������āA�~���N�����炷");

            // ��z�G���A����Space�L�[���� �� �~���N��z����
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                // �~���N��z�B����
                _touchedObject.gameObject.GetComponent<PlayerParameter>().DeliveredMilk();
                // �G�ꂽ�I�u�W�F�N�g����ɂ���
                _touchedObject = null;
                // �G��Ă��Ȃ���Ԃɖ߂�
                _isTouchThePlayer = false;
                // �~���N���͂�UI���\��
                _uiManagerObj.IsDeliveredMilkImageActiveProp = false;

                // �f���o���[�|�C���g���폜
                Destroy(this.gameObject);
            }

        }
        else
        {
            // �G�ꂽ�I�u�W�F�N�g����ɂ���
            _touchedObject = null;
            // �G��Ă��Ȃ���Ԃɖ߂�
            _isTouchThePlayer = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�S�[���ɐG��Ă���");

        // �v���C���[�ɏՓ˂�����A
        if (other.gameObject.GetComponent<PlayerParameter>() == false) return;

        _isTouchThePlayer = true;

        _touchedObject = other.gameObject;

        // �~���N���͂�UI��\��
        _uiManagerObj.IsDeliveredMilkImageActiveProp = true;

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("�S�[���ɐG��Ă���");

        // �v���C���[�ɏՓ˂�����A
        if (other.gameObject.GetComponent<PlayerParameter>() == false) return;

        _isTouchThePlayer = false;

        _touchedObject = null;

        // �~���N���͂�UI���\��
        _uiManagerObj.IsDeliveredMilkImageActiveProp = false;
    }

}