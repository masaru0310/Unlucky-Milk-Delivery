using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _pcPos;

    // 定数
    private const float _POS_Z_DIST_TO_PC = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 自身のプレイヤーしか操作できない
        if (!photonView.IsMine) return;

        NormalMove();
    }


    /// <summary>
    /// 通常時のカメラ挙動
    /// </summary>
    public void NormalMove()
    {
        Vector3 pcPos = _pcPos.transform.position;
        transform.position = new Vector3(pcPos.x, pcPos.y, pcPos.z - _POS_Z_DIST_TO_PC);
    }
}
