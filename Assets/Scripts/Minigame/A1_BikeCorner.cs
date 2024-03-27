using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class A1_BikeCorner : MinigameBase
{
    [SerializeField, Tooltip("突進してくるバイク")]
    private GameObject _comingBike;

    private Rigidbody _comingBikeRB;


    void Start()
    {
        incidenceNum = 1000;

        _comingBike.SetActive(false);
        _comingBikeRB = _comingBike.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(isStartMinigame == true)
        {
            FuncMinigame();
        }
    }


    /// <summary>
    /// ミニゲーム発生時の処理
    /// </summary>
    protected override void FuncMinigame()
    {
        PhotonNetwork.Instantiate("Coming_Bike", _comingBike.transform.position, Quaternion.identity);
        isStartMinigame = false;
    }
}
