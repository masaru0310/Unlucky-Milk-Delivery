using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    // 変数
    private float _moveInput;
    private float _steerInput;
    private float _rayLength;
    private float _currentVelocityOffset;

    [HideInInspector] private Vector3 _velocity;

    [SerializeField, Tooltip("最大スピード")]
    private float MAX_SPEED;
    [SerializeField, Tooltip("加速度")]
    private float ACCELERATION;
    [SerializeField, Tooltip("横に回転する強さ")]
    private float _steerStrength;
    [SerializeField, Tooltip("ブレーキスピード"), Range(1, 10)]
    private float _brakingFactor;
    [SerializeField, Tooltip("重力強さ")]
    private float _gravity;
    [SerializeField, Tooltip("バイクを傾ける強さX")]
    private float _bikeXTiltIncrement = .09f;
    [SerializeField, Tooltip("バイクを傾ける強さZ")]
    private float _bikeZTiltIncrement = 45f;
    [SerializeField, Tooltip("ハンドルを傾ける強さZ")]
    private float _handleRotVal = 30f;
    [SerializeField, Tooltip("ハンドルを傾ける強さZ")]
    private float _handleRotSpeed = .15f;
    [SerializeField, Tooltip("バイク進行用のコライダー")]
    private Rigidbody _sphereRB;
    [SerializeField, Tooltip("バイクのモデルデータ")]
    private Rigidbody _bikeModel;
    [SerializeField]
    private LayerMask _derivableSurface;
    [SerializeField, Tooltip("ハンドル")]
    private GameObject _handle;
    [SerializeField, Tooltip("前輪")]
    private GameObject _frontTyre;
    [SerializeField, Tooltip("後輪")]
    private GameObject _backTyre;


    // 変数
    [SerializeField, Range(0, 1)] private float _minPitch;
    [SerializeField, Range(1, 5)] private float _maxPitch;


    RaycastHit _hit;

    // 音声データ
    [SerializeField, Tooltip("エンジンの音")]
    private AudioSource _engineSound;
    [SerializeField, Tooltip("ブレーキ音")]
    private AudioSource _stopSound;

    // 定数
    private const float TYRE_ROT_SPEED = 10000.0f;
    private const float NO_DRAG = 2.0f;
    private const float DRIFT_DRAG = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        _sphereRB.transform.parent = null;
        _bikeModel.transform.parent = null;

        _rayLength = _sphereRB.GetComponent<SphereCollider>().radius + 0.2f;

        _stopSound.mute = true;
    }


    // Update is called once per frame
    void Update()
    {
        _moveInput = Input.GetAxis("Vertical");
        _steerInput = Input.GetAxis("Horizontal");

        transform.position = _sphereRB.transform.position;

        _velocity = _bikeModel.transform.InverseTransformDirection(_bikeModel.velocity);
        _currentVelocityOffset = _velocity.z / MAX_SPEED;
    }



    private void FixedUpdate()
    {
        Movement();

        _frontTyre.transform.Rotate(Vector3.right, Time.deltaTime * TYRE_ROT_SPEED * _currentVelocityOffset);
        _backTyre.transform.Rotate(Vector3.right, Time.deltaTime * TYRE_ROT_SPEED * _currentVelocityOffset);

        // エンジン音を鳴らす
        EngineSound();
    }


    /// <summary>
    /// バイクの挙動関数
    /// </summary>
    void Movement()
    {
        if (Grounded() == true)
        {
            if (Input.GetKey(KeyCode.Space) == false)
            {
                Acceleration();
            }
            Rotation();
            Brake();
        }
        else
        {
            Gravity();
        }

        BikeTilt();
    }


    /// <summary>
    /// 加速処理
    /// </summary>
    private void Acceleration()
    {
        _sphereRB.velocity = Vector3.Lerp(_sphereRB.velocity, MAX_SPEED * _moveInput * transform.forward, Time.fixedDeltaTime * ACCELERATION);
    }


    /// <summary>
    /// 回転
    /// </summary>
    private void Rotation()
    {
        // 進行方向の回転
        transform.Rotate(0.0f, _steerInput * _moveInput * _currentVelocityOffset * _steerStrength * Time.fixedDeltaTime, 0, Space.World);

        // ハンドルの回転
        // ※ オブジェクト上のハンドルが-90度回転しているため、Eulerのyはマイナスの値を使う
        _handle.transform.localRotation = Quaternion.Slerp(_handle.transform.localRotation, Quaternion.Euler(_handle.transform.localRotation.eulerAngles.x, -(_handleRotVal * _steerInput), _handle.transform.localRotation.eulerAngles.z), _handleRotSpeed);
    }


    /// <summary>
    /// バイクの見せかけの傾き
    /// </summary>
    private void BikeTilt()
    {
        float xRot = (Quaternion.FromToRotation(_bikeModel.transform.up, _hit.normal) * _bikeModel.transform.rotation).eulerAngles.x;
        float zRot = 0;

        if (_currentVelocityOffset > 0.0f)
        {
            zRot = -_bikeZTiltIncrement * _steerInput * _currentVelocityOffset;
        }

        Quaternion targetRot = Quaternion.Slerp(_bikeModel.transform.rotation, Quaternion.Euler(xRot, transform.eulerAngles.y, zRot), _bikeXTiltIncrement);

        Quaternion newRotation = Quaternion.Euler(targetRot.eulerAngles.x, transform.eulerAngles.y, zRot);

        _bikeModel.MoveRotation(newRotation);
    }


    /// <summary>
    /// ブレーキ処理
    /// ※ Space入力で減速
    /// </summary>
    void Brake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _sphereRB.velocity *= _brakingFactor / 10.0f;
            _sphereRB.drag = DRIFT_DRAG;
        }
        else
        {
            _sphereRB.drag = NO_DRAG;
        }
    }

    private bool Grounded()
    {
        if (Physics.Raycast(_sphereRB.position, Vector3.down, out _hit, _rayLength, _derivableSurface))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Gravity()
    {
        _sphereRB.AddForce(_gravity * Vector3.down, ForceMode.Acceleration);
    }


    /// <summary>
    /// エンジン音を鳴らす
    /// </summary>
    public void EngineSound()
    {
        _engineSound.pitch = Mathf.Lerp(_minPitch, _maxPitch, Mathf.Abs(_currentVelocityOffset));
    }
}