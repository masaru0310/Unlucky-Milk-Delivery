using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class LookAtMove : MonoBehaviour
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
        // 回転
        Vector3 lookAtEuler = this.transform.rotation.eulerAngles;
        lookAtEuler.y = _lookAtObject.rotation.eulerAngles.y;
        this.transform.eulerAngles = lookAtEuler;
    }
}
