using Assets.Scripts.Models;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Editor

    [SerializeField]
    private DayNightCycle _dayNightCycleManager;

    [SerializeField]
    private DateData _dateData;

    #endregion

    #region Methods

    private void Start()
    {
        _dayNightCycleManager.IsDayPassed += OnDayPassed;
    }

    private void OnDestroy()
    {
        _dayNightCycleManager.IsDayPassed -= OnDayPassed;
    }

    private void OnDayPassed(bool dayPassed)
    {
        _dateData.SetDayName(dayPassed);
    }

    #endregion
}
