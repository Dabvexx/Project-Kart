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
    [SerializeField] private GameObject trollPanel;

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        trollPanel.SetActive(false);
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
        trollPanel.SetActive(true);
        //SpawnPanelServerRpc();
    }

    /*[ServerRpc(RequireOwnership = false)]
    private void SpawnPanelServerRpc()
    {
        GameObject go = Instantiate(readyUpPanel, new Vector3(Screen.width * .5f, Screen.height * .5f, 0), Quaternion.identity, transform);
        go.GetComponent<NetworkObject>().Spawn();
        Debug.Log("Test server Rpc");
    }*/

    #endregion Private Methods

    #region Public Methods

    // Public Methods.

    #endregion Public Methods
}