using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleChanged : MonoBehaviour
{
    private Health _health;
    private Slider _slider;

    private float _rate;
    private int _changeValue;

    private IEnumerator _currentCoroutine;

    private void Start()
    {
        _health = GetComponent<Health>();
        _slider = GetComponent<Slider>();

        _rate = 10f;
        _changeValue = 10;
    }
    public void SetHandleValueDamage()
    {
        ChangeVolume(_health.GetCurrentHealthValue() + _changeValue);
    }

    public void SetHandleValueHeal()
    {
        ChangeVolume(_health.GetCurrentHealthValue() - _changeValue);
    }

    private void ChangeVolume(float value)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = HandleChanging(value);

        StartCoroutine(_currentCoroutine);
    }
    private IEnumerator HandleChanging(float value)
    {
        while (_health.GetCurrentHealthValue() != value)
        {
            _slider.value = Mathf.MoveTowards(_health.GetCurrentHealthValue(), value, _rate * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
    }
}
