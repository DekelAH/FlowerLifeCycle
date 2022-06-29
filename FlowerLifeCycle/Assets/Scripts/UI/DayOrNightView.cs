using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayOrNightView : MonoBehaviour
{
    #region Editor

    [SerializeField]
    private Image _sunImage;

    [SerializeField]
    private Image _moonImage;

    [SerializeField]
    private DayNightCycle _dayNightCycle;

    #endregion

    #region Methods

    private void Start()
    {
        _dayNightCycle.IsSunShines += OnSunShine;
    }

    private void OnDestroy()
    {
        _dayNightCycle.IsSunShines -= OnSunShine;
    }

    private void OnSunShine(bool isSunShines)
    {
        if (isSunShines)
        {
            _sunImage.gameObject.SetActive(true);
            _moonImage.gameObject.SetActive(false);
        }
        else
        {
            _sunImage.gameObject.SetActive(false);
            _moonImage.gameObject.SetActive(true);         
        }
    }

    #endregion
}
