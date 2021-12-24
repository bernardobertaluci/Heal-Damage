using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    private float _health;

    public float HealthValue => _health;
    public void Increase(float value, float maxValue)
    {
        if (_health <= maxValue)
            _health += value;
    }
    public void Decrease(float value, float minValue)
    {
        if (_health >= minValue)
            _health -= value;
    }
}
