using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeSpeedController : MonoBehaviour
{
    [SerializeField, Range(0.1f, 2.0f)] private float speed;

    private readonly Speed _speed = new();      // Speedインスタンスを持たせる

    // Start is called before the first frame update
    void Start()
    {
        Physics.simulationMode = SimulationMode.Update;
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Simulate(Time.deltaTime * speed);
    }

    // 初期化
    public void Initialize()
    {
        _speed.OnValueChanged = UpdateSpeed;
    }

    private void UpdateSpeed(float speed)
    {

    }
}
