using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Slider _slider;

    private float _rate;

    private IEnumerator _currentCoroutine;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _rate = 10f;
    }   

    public float GetCurrentHealthValue()
    {
        return _slider.value;
    }

    public void ChangeVolume(float value)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = HandleChanging(value);

        StartCoroutine(_currentCoroutine);
    }
    private IEnumerator HandleChanging(float value)
    {
        while (_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _rate * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
    }
}
