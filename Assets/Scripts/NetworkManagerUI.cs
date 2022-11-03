using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkManagerUI : MonoBehaviour
{
    #region Variables

    // Variables.

    [SerializeField] private Button HostBtn;

    [SerializeField] private Button serverBtn;

    [SerializeField] private Button clientBtn;

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject readyUpPanel;

    #endregion Variables

    #region Unity Methods

    
    private void Start()
    {
        readyUpPanel.SetActive(false);
    }

    private void Awake()
    {
        serverBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
            ShowReadyScreen();
        });

        HostBtn.onClick.AddListener(() =>
        {
            //NetworkManager.Singleton.ConnectionApprovalCallback = ApprovalCheck;
            NetworkManager.Singleton.StartHost();
            ShowReadyScreen();
        });

        clientBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
            ShowReadyScreen();
        });
    }

    #endregion Unity Methods

    #region Private Methods

    // Private Methods.

    private void ShowReadyScreen()
    {
        mainMenuPanel.SetActive(false);
        readyUpPanel.SetActive(true);
    }

    private void ApprovalCheck(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
    {
        // The client identifier to be authenticated
        var clientId = request.ClientNetworkId;

        // Additional connection data defined by user code
        var connectionData = request.Payload;

        // Your approval logic determines the following values
        response.Approved = true;
        response.CreatePlayerObject = true;

        // The prefab hash value of the NetworkPrefab, if null the default NetworkManager player prefab is used
        response.PlayerPrefabHash = null;

        // Position to spawn the player object (if null it uses default of Vector3.zero)
        response.Position = Vector3.zero;

        // Rotation to spawn the player object (if null it uses the default of Quaternion.identity)
        response.Rotation = Quaternion.identity;

        // If additional approval steps are needed, set this to true until the additional steps are complete
        // once it transitions from true to false the connection approval response will be processed.
        response.Pending = false;
    }

    #endregion Private Methods
}