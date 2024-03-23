using UnityEngine;
using Cinemachine;
using UnityEngine.AI;
using Unity.VisualScripting;

public class StartMinigame_Bike : MonoBehaviour
{
    /// <summary>
    /// 外部オブジェクト
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

    // プロパティ
    public bool StartMinigameProp
    {
        get { return _isStartGame; }
        set { _isStartGame = value; }
    }

    // 定数
    private const float _ROTATE_VALUE = 0.2f;
    private const float _PC_SPEED_Z = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        _isStartGame = false;
        _isOnlyTheFirstTime = true;

        // コンポーネント取得
        _navToPc = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStartGame == true) MinigameMethod_Bike();
    }

    /// <summary>
    /// 不運ミニゲーム開始
    /// </summary>
    private void MinigameMethod_Bike()
    {
        // 不運ミニゲーム開始時に、カメラを切り替え目標回転角度を定義
        if(_isOnlyTheFirstTime == true)
        {
            // カメラを演出用に切り替え
            _vcam1Obj.Priority = 1;
            _pcMoveObj.MainCameraProp = 0;

            _startRot = _pcMoveObj.transform.rotation;
            _targetRot = Quaternion.AngleAxis(_targetAngle, _axis) * _pcMoveObj.transform.rotation;
            _isOnlyTheFirstTime = false;
        }

        // UIを表示
        _dispUiObj.DispText();

        // PCはゆっくり前方に進行
        _pcMoveObj.transform.Translate(Vector3.forward * Time.deltaTime * _PC_SPEED_Z);

        // PCの方向へ経路探索
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
