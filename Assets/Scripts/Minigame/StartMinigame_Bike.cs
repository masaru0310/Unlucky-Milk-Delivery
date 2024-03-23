using UnityEngine;
using Cinemachine;
using UnityEngine.AI;
using Unity.VisualScripting;

public class StartMinigame_Bike : MonoBehaviour
{
    /// <summary>
    /// �O���I�u�W�F�N�g
    /// </summary>
    [SerializeField] private PlayerMove _pcMoveObj;
    [SerializeField] private DispTextForBike _dispUiObj;
    [SerializeField] private CinemachineVirtualCameraBase _vcam1Obj;
    [SerializeField] private float _targetAngle;
    [SerializeField] private Vector3 _axis;
    [SerializeField] private GameObject _destination;
    private bool        _isStartGame;
    private bool        _isOnlyTheFirstTime;
    private Quaternion  _startRot;
    private Quaternion  _targetRot;

    private NavMeshAgent _navToPc;

    // �v���p�e�B
    public bool StartMinigameProp
    {
        get { return _isStartGame; }
        set { _isStartGame = value; }
    }

    // �萔
    private const float _ROTATE_VALUE = 0.2f;
    private const float _PC_SPEED_Z = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        _isStartGame = false;
        _isOnlyTheFirstTime = true;

        // �R���|�[�l���g�擾
        _navToPc = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStartGame == true) MinigameMethod_Bike();
    }

    /// <summary>
    /// �s�^�~�j�Q�[���J�n
    /// </summary>
    private void MinigameMethod_Bike()
    {
        // �s�^�~�j�Q�[���J�n���ɁA�J������؂�ւ��ڕW��]�p�x���`
        if(_isOnlyTheFirstTime == true)
        {
            // �J���������o�p�ɐ؂�ւ�
            _vcam1Obj.Priority = 1;
            _pcMoveObj.MainCameraProp = 0;

            _startRot = _pcMoveObj.transform.rotation;
            _targetRot = Quaternion.AngleAxis(_targetAngle, _axis) * _pcMoveObj.transform.rotation;
            _isOnlyTheFirstTime = false;
        }

        // UI��\��
        _dispUiObj.DispText();

        // PC�͂������O���ɐi�s
        _pcMoveObj.transform.Translate(Vector3.forward * Time.deltaTime * _PC_SPEED_Z);

        // PC�̕����֌o�H�T��
        if (_navToPc.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            _navToPc.SetDestination(_destination.transform.position);
        }
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player") == true)
    //    {
    //        _dispUiObj.
    //    }
    //}
}
