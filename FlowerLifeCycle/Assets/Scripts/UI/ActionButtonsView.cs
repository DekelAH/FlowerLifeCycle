using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtonsView : MonoBehaviour
{
    #region Editor

    [SerializeField]
    private Button _manualWateringButton;

    [SerializeField]
    private float _waterAmountToAdd;

    #endregion

    #region Methods

    public void OnManualWateringClick()
    {
        var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
        playerModel.AddWater(_waterAmountToAdd);
    }

    #endregion
}
