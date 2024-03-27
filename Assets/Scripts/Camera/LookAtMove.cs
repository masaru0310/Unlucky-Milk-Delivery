using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class LookAtMove : MonoBehaviour
{
    [SerializeField, Tooltip("�Ǐ]�������I�u�W�F�N�g")]
    private Transform _lookAtObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ��]
        Vector3 lookAtEuler = this.transform.rotation.eulerAngles;
        lookAtEuler.y = _lookAtObject.rotation.eulerAngles.y;
        this.transform.eulerAngles = lookAtEuler;
    }
}
