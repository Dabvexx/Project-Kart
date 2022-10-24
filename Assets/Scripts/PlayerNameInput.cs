using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Thanks to Dapper Dino on how to earth to set up a lobby like this.
/// https://www.youtube.com/watch?v=Fx8efi2MNz0&ab_channel=DapperDino
/// </summary>
public class PlayerNameInput : MonoBehaviour
{
    #region Variables

    // Variables.
    [Header("UI")]
    [SerializeField] private TMP_InputField nameInput = null;

    [SerializeField] private Button continueBtn = null;

    public static string displayName { get; private set; }

    private const string playerPrefsNameKey = "PlayerName";

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        SetupInputField();
    }

    #endregion Unity Methods

    #region Private Methods

    // Private Methods.
    private void SetupInputField()
    {
        if (!PlayerPrefs.HasKey(playerPrefsNameKey)) return;

        string defaultName = PlayerPrefs.GetString(playerPrefsNameKey);

        nameInput.text = defaultName;

        SetPlayerName(defaultName);
    }

    private void SetPlayerName(string name)
    {
        continueBtn.interactable = !string.IsNullOrEmpty(name);
    }

    #endregion Private Methods

    #region Public Methods

    // Public Methods.
    public void SavePlayerName()
    {
        displayName = nameInput.text;

        PlayerPrefs.SetString(playerPrefsNameKey, displayName);
    }

    #endregion Public Methods
}