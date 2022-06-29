using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Models/Player Model", fileName = "Player Model")]
public class PlayerModel : ScriptableObject
{
    #region Events

    public event Action<float> OxygenAmountChange;
    public event Action<float> WaterAmountChange;

    #endregion

    #region Editor

    [SerializeField]
    [Range(0, 1)]
    private float _oxygenAmount;

    [SerializeField]
    [Range(0, 1)]
    private float _waterAmount;

    #endregion

    #region Methods

    public void AddOxygen(float oxygenToAdd)
    {
        _oxygenAmount = Mathf.Min(_oxygenAmount + oxygenToAdd, 1);
        OxygenAmountChange?.Invoke(_oxygenAmount);
    }

    public void WithDrawOxygen(float oxygenToWithdraw)
    {
        _oxygenAmount = Mathf.Max(0, _oxygenAmount - oxygenToWithdraw);
        OxygenAmountChange?.Invoke(_oxygenAmount);
    }

    public void AddWater(float waterToAdd)
    {
        _waterAmount = Mathf.Min(_waterAmount + waterToAdd, 1);
        WaterAmountChange?.Invoke(_waterAmount);
    }

    public void WithDrawWater(float waterToWithdraw)
    {
        _waterAmount = Mathf.Min(0, _waterAmount - waterToWithdraw);
        WaterAmountChange?.Invoke(_waterAmount);
    }

    #endregion

    #region Properties

    public float GetWaterAmount => _waterAmount;
    public float GetOxygenAmount => _oxygenAmount;

    #endregion

}
