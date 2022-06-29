using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlowerStatsView : MonoBehaviour
{
    #region Editor

    [SerializeField]
    private Slider _waterSlider;

    [SerializeField]
    private Slider _oxygenSlider;

    [SerializeField]
    private float _statsSliderSpeed;

    #endregion

    #region Fields

    private bool _isLerpingStats = false;
    private float _waterTarget;
    private float _oxygenTarget;
    private float _timeScale;

    #endregion

    #region Methods

    private void Start()
    {
        RegisterToEvents();
        SetUpParams();
    }

    private void OnDestroy()
    {
        var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
        playerModel.OxygenAmountChange -= OnOxygenAmountChange;
        playerModel.WaterAmountChange -= OnWaterAmountChange;
    }

    private void RegisterToEvents()
    {
        var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
        playerModel.OxygenAmountChange += OnOxygenAmountChange;
        playerModel.WaterAmountChange += OnWaterAmountChange;
    }

    private void SetUpParams()
    {
        var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
        _waterSlider.value = playerModel.GetWaterAmount;
        _oxygenSlider.value = playerModel.GetOxygenAmount;
    }

    private void OnWaterAmountChange(float water)
    {
        _waterTarget = water;
        _timeScale = 0f;

        if (!_isLerpingStats)
        {
            StartCoroutine(LerpSlider(_waterTarget, _waterSlider));
        }
    }

    private void OnOxygenAmountChange(float oxygen)
    {
        _oxygenTarget = oxygen;
        _timeScale = 0f;

        if (!_isLerpingStats)
        {
            StartCoroutine(LerpSlider(_oxygenTarget, _oxygenSlider));
        }
    }

    private IEnumerator LerpSlider(float statsTarget, Slider statsSlider)
    {
        var startFuel = statsSlider.value;

        _isLerpingStats = true;

        while (_timeScale < 1)
        {
            _timeScale += Time.deltaTime * _statsSliderSpeed;
            statsSlider.value = Mathf.Lerp(startFuel, statsTarget, _timeScale);

            yield return null;
        }

        _isLerpingStats = false;
    }

    #endregion
}
