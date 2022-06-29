using System;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [CreateAssetMenu(menuName = "Models/Date Data", fileName = "Date Data")]
    public class DateData : ScriptableObject
    {
        #region Events

        public event Action<string> DayChanged;

        #endregion

        #region Editor

        [SerializeField]
        private string[] _daysNames;

        [SerializeField]
        private int _dayIndex = 1;

        #endregion

        #region Fields

        private string _dayName;

        #endregion

        #region Methods

        public void SetDayName(bool isDayPassed)
        {
            if (isDayPassed)
            {
                _dayName = _daysNames[_dayIndex];
                DayChanged?.Invoke(_dayName);
                if (_dayIndex >= _daysNames.Length - 1)
                {
                    _dayIndex = 0;
                }
                else
                {
                    _dayIndex++;
                }
            }
        }

        #endregion

        #region Properties

        public string FirstDay => _daysNames[0];

        #endregion
    }
}
