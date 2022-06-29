using System;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    #region Events

    public event Action<bool> IsDayPassed;
    public event Action<bool> IsSunShines;

    #endregion

    #region Editor

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float _time;

    [SerializeField]
    private float _fullDayLength;

    [SerializeField]
    private float _startTime;

    [SerializeField]
    private Vector3 _noon;

    [Header("Sun")]
    [SerializeField]
    private Light _sun;

    [SerializeField]
    private Gradient _sunColor;

    [SerializeField]
    private AnimationCurve _sunIntensity;    

    [Header("Moon")]
    [SerializeField]
    private Light _moon;

    [SerializeField]
    private Gradient _moonColor;

    [SerializeField]
    private AnimationCurve _moonIntensity;

    [Header("Other Lighting")]
    [SerializeField]
    private AnimationCurve _lightingIntensityMultiplier;

    [SerializeField]
    private AnimationCurve _reflectionsIntensityMultiplier;

    #endregion

    #region Fields

    private float _timeRate;
    #endregion

    #region Methods

    private void Start()
    {
        _timeRate = 1.0f / _fullDayLength;
        _time = _startTime;
    }

    private void Update()
    {
        SettingTime(_timeRate);
        SettingLightingAngles(_time, _noon);
        SettingLightIntensity(_time);
        ColorChanging(_time);
        EnableOrDisableLights();
        SetIntensityAccordingToTime();
        CheckIfDayPassed();
        CheckIfSunShines();
    }

    private void CheckIfSunShines()
    {
        if (_sun.intensity == 0f)
        {
            IsSunShines?.Invoke(false);
        }
        else
        {
            IsSunShines?.Invoke(true);
        }
    }

    private void CheckIfDayPassed()
    {
        if (_time == 0f)
        {
            IsDayPassed?.Invoke(true);
        }
        else
        {
            IsDayPassed?.Invoke(false);
        }
    }

    private void SettingTime(float timeRate)
    {
        _time += timeRate * Time.deltaTime;
        if (_time >= 1.0f)
        {
            _time = 0.0f;
        }
    }

    private void SettingLightingAngles(float time, Vector3 noonPos)
    {
        _sun.transform.eulerAngles = (time - 0.25f) * 4.0f * noonPos;
        _moon.transform.eulerAngles = (time - 0.75f) * 4.0f * noonPos;
    }

    private void SettingLightIntensity(float time)
    {
        _sun.intensity = _sunIntensity.Evaluate(time);
        _moon.intensity = _moonIntensity.Evaluate(time);
    }

    private void ColorChanging(float time)
    {
        _sun.color = _sunColor.Evaluate(time);
        _moon.color = _moonColor.Evaluate(time);
    }

    private void EnableOrDisableLights()
    {
        if (_sun.intensity == 0 && _sun.gameObject.activeInHierarchy)
        {
            _sun.gameObject.SetActive(false);
        }
        else if (_sun.intensity > 0 && !_sun.gameObject.activeInHierarchy)
        {
            _sun.gameObject.SetActive(true);
        }

        if (_moon.intensity == 0 && _moon.gameObject.activeInHierarchy)
        {
            _moon.gameObject.SetActive(false);
        }
        else if (_moon.intensity > 0 && !_moon.gameObject.activeInHierarchy)
        {
            _moon.gameObject.SetActive(true);
        }
    }

    private void SetIntensityAccordingToTime()
    {
        RenderSettings.ambientIntensity = _lightingIntensityMultiplier.Evaluate(_time);
        RenderSettings.reflectionIntensity = _reflectionsIntensityMultiplier.Evaluate(_time);
    }

    #endregion
}
