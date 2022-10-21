using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    #region Variables

    // Variables.
    [SerializeField] private Button HostBtn;

    [SerializeField] private Button serverBtn;

    [SerializeField] private Button clientBtn;

    #endregion Variables

    #region Unity Methods

    private void Awake()
    {
        serverBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
        });

        HostBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });

        clientBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
    }

    #endregion Unity Methods

    #region Private Methods

    // Private Methods.

    #endregion Private Methods

    #region Public Methods

    // Public Methods.

    #endregion Public Methods
}