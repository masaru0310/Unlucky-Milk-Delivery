using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        // �v���C���[�ɏՓ˂�����A
        if (other.gameObject.GetComponent<PlayerParameter>() == false) return;

        // ��z�G���A����Space�L�[���� �� �~���N��z����
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            // �~���N��z�B����
            other.gameObject.GetComponent<PlayerParameter>().DeliveredMilk();
        }
    }

}
