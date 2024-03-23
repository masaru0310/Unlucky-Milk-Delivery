using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCameraBase vMainCamera;

    // �e�ϐ�
    private float _speedZ = 15.0f;
    private float turnSpeed = 50.0f;
    private float LRInput;
    private float UDInput;

    private bool _isStartMinigame;

    // �v���p�e�B
    public float SpeedZProp
    {
        get { return _speedZ; }
        set { _speedZ = value; }
    }
    public bool StartMinigameProp
    {
        get { return _isStartMinigame; }
        set { _isStartMinigame = value; }
    }
    public int MainCameraProp
    {
        get { return vMainCamera.Priority; }
        set { vMainCamera.Priority = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        vMainCamera.Priority = 1;       // ���߂̓��C���J�������N������
    }

    // Update is called once per frame
    void Update()
    {
        // �s�K�����������Ƃ��́A�ړ������̓~�j�Q�[���֐����ł��
        if (_isStartMinigame == true) return;

        LRInput = Input.GetAxis("Horizontal") * 5.0f;
        UDInput = Input.GetAxis("Vertical") * 0.9f;

        _speedZ += UDInput * 0.01f;
        if (_speedZ >= 15.0f) _speedZ = 15.0f;

        if (UDInput == 0.0f)
        {
            _speedZ -= 0.06f;
            if (_speedZ < 0.0f) _speedZ = 0.0f;
        }

        transform.Translate(Vector3.forward * Time.deltaTime * _speedZ);

        transform.Rotate(Vector3.up, turnSpeed * LRInput * Time.deltaTime);
    }
}