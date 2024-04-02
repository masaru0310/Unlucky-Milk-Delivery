using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        if (photonView.IsMine)
        {

            // ���Ȃ�Follow�Ώۂɐݒ肷��B
            this.GetComponent<CinemachineVirtualCamera>().Follow = this.transform.parent;
        }
        if (!photonView.IsMine)
        {
            gameObject.SetActive(false);
        }
    }
}
