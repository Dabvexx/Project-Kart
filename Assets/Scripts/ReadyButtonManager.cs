using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This script acts as a middle man between the network ready tracker and the swapping of buttons
/// </summary>
public class ReadyButtonManager : MonoBehaviour
{
    #region Variables

    // Variables.
    [SerializeField] private Button button;

    [SerializeField] private TextMeshProUGUI buttonText;

    private NetworkReadyTracker nrt;

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        nrt = FindObjectOfType<NetworkReadyTracker>();
        button.onClick.AddListener(() => ReadyBtnClick());
    }

    #endregion Unity Methods

    #region public Methods

    // public Methods.
    public void ReadyBtnClick()
    {
        // Change to unready.
        buttonText.text = "Unready";
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => UnreadyBtnClick());

        // Call the method.
        nrt.ReadyUpServerRpc();
    }

    public void UnreadyBtnClick()
    {
        // Change to ready.
        buttonText.text = "Ready";
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => ReadyBtnClick());

        // Call the method.
        nrt.UnreadyUpServerRpc();
    }

    #endregion public Methods
}