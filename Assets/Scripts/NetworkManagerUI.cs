using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Netcode.Transports.UTP;
using TMPro;

public class NetworkManagerUI : MonoBehaviour
{
    #region Variables

    // Variables.
    [SerializeField] private TMP_InputField ipAddressInputField;
    
    // The buttons to start the server
    // The server button is unused.
    [SerializeField] private Button HostBtn;

    [SerializeField] private Button serverBtn;

    [SerializeField] private Button clientBtn;


    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject readyUpPanel;

    // Credit to Spessman for the setting IP code
    // https://www.youtube.com/watch?v=n2HFUmhSmq4&ab_channel=Spessman
    // (there is no github link so the video will do)
    // Also this didnt work but i left it just in case
    //public UnityTransport transport => (UnityTransport)NetworkManager.Singleton.NetworkConfig.NetworkTransport;
    //public void SetIP(string ip) => transport.ConnectionData.Address = ip;

    #endregion Variables

    #region Unity Methods

    
    private void Start()
    {
        readyUpPanel.SetActive(false);
    }

    private void Awake()
    {
        // Whenever any button is pressed, set IP to input field.
        serverBtn.onClick.AddListener(() =>
        {
            ShowReadyScreen();
            NetworkManager.Singleton.StartServer();
        });

        HostBtn.onClick.AddListener(() =>
        {
            //NetworkManager.Singleton.ConnectionApprovalCallback = ApprovalCheck;
            ShowReadyScreen();
            NetworkManager.Singleton.StartHost();
        });

        clientBtn.onClick.AddListener(() =>
        {
            ShowReadyScreen();
            NetworkManager.Singleton.StartClient();
        });
    }

    #endregion Unity Methods

    #region Private Methods

    // Private Methods.

    // bring up the ready panel UI
    private void ShowReadyScreen()
    {
        // Set the port to 6742 because that port is unused
        // NOTE TO SELF: open port 6742 on the firewall for presentation.
        //SetIP(TryParseIpAddressFromInputField().Host);
        mainMenuPanel.SetActive(false);
        readyUpPanel.SetActive(true);
    }

    /*private Uri TryParseIpAddressFromInputField()
    {
        UriBuilder uriBuilder = new UriBuilder();
        uriBuilder.Scheme = "kcp";
        if (ipAddressInputField)
        {
            uriBuilder.Host = ipAddressInputField.textComponent.text;
        }
        else
        {
            //uriBuilder.Host = "localhost";
        }

        var uri = new Uri(uriBuilder.ToString(), UriKind.Absolute);
        return uri;
    }*/

    #endregion Private Methods
}