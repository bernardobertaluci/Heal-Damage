using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HandleChanged : MonoBehaviour
{
    private Slider _slider;

    private float _rate;
    private int _changeValue;

    private IEnumerator _currentCoroutine;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _rate = 5f;
        _changeValue = 10;
    }
    public void SetHandleValueDamage()
    {
        ChangeVolume(_slider.value + _changeValue);
    }
    public void SetHandleValueHeal()
    {
        ChangeVolume(_slider.value - _changeValue);
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
        while (_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _rate * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
    }
}
