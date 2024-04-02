using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Cinemachine;

public class LookAtMove : MonoBehaviourPunCallbacks
{

    [SerializeField, Tooltip("追従したいオブジェクト")]
    private Transform _lookAtObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 自身のプレイヤーしか操作できない
        if (!photonView.IsMine) return;

        // 回転
        Vector3 lookAtEuler = this.transform.rotation.eulerAngles;
        lookAtEuler.y = _lookAtObject.rotation.eulerAngles.y;
        this.transform.eulerAngles = lookAtEuler;
    }
}
