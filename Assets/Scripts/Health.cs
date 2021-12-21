using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Slider _slider;

    private float _health;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }   

    public float GetCurrentHealthValue()
    {
        return _health = _slider.value;
    }
}
