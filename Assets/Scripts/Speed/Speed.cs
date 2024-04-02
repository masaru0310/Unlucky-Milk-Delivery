using System;

public class Speed
{
    private float _speed = 1.0f;
    public float CurrentSpeed => _speed;

    public Action<float> OnValueChanged;

    public void SetSpeed(float speed)
    {
        _speed = speed;
        OnValueChanged?.Invoke(speed);
    }
}