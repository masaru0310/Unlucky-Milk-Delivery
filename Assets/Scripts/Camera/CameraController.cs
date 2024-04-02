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

            // é©å»ÇFollowëŒè€Ç…ê›íËÇ∑ÇÈÅB
            this.GetComponent<CinemachineVirtualCamera>().Follow = this.transform.parent;
        }
        if (!photonView.IsMine)
        {
            gameObject.SetActive(false);
        }
    }
}
