using UnityEngine;

public class PlayerModelProvider
{

    #region Fields

    private static PlayerModelProvider _instance;
    private readonly PlayerModel _playerModel;

    #endregion

    #region Consts

    private const string PLAYER_MODEL_FILE_NAME = "Player Model";

    #endregion

    #region Constructor

    public PlayerModelProvider(string playerModelName)
    {
        _playerModel = Resources.Load<PlayerModel>(playerModelName);
    }

    #endregion

    #region Properties

    public static PlayerModelProvider Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerModelProvider(PLAYER_MODEL_FILE_NAME);
            }

            return _instance;
        }
    }

    public PlayerModel GetPlayerModel => _playerModel;

    #endregion
}
