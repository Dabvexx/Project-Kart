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

    #endregion Private Methods
}