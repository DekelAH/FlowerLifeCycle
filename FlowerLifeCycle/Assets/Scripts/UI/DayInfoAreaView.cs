using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

public class DayInfoAreaView : MonoBehaviour
{
    #region Editor

    [SerializeField]
    private DateData _dateData;

    [SerializeField]
    private Text _dayText;

    #endregion

    #region Methods

    private void Start()
    {
        RegisterEvents();
       _dayText.text = _dateData.FirstDay;
    }

    private void OnDestroy()
    {
        _dateData.DayChanged -= OnDayChange;
    }

    private void RegisterEvents()
    {
        _dateData.DayChanged += OnDayChange;
    }

    private void OnDayChange(string dayName)
    {
        _dayText.text = dayName;
    }

    #endregion
}
