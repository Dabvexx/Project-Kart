using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ReadyButtonSetup : NetworkBehaviour
{
    #region Variables

    // Variables.
    private NetworkManager nm;

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        nm = FindObjectOfType<NetworkManager>();
    }

    private void Awake()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {
            FindObjectOfType<NetworkReadyManager>().ReadyUp();
        });
    }

    private void Update()
    {
    }

    #endregion Unity Methods

    #region Private Methods

    // Private Methods.
    private void ReadyUp()
    {
        if (!IsOwner) return;
        Debug.Log(nm.ConnectedClientsList.Count);
        FindObjectOfType<NetworkReadyManager>().ValidateReady();
    }

    #endregion Private Methods

    #region Public Methods

    // Public Methods.

    #endregion Public Methods
}