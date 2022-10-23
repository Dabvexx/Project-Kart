using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkReadyManager : NetworkBehaviour
{
    #region Variables

    // Variables.

    [SerializeField] private GameObject readyBtn;
    [SerializeField] private int numTracks;
    private NetworkManager nm;
    private int numReady = 0;

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        nm = FindObjectOfType<NetworkManager>();
    }

    private void Update()
    {
    }

    #endregion Unity Methods

    #region Networking Methods

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void OnGainedOwnership()
    {
        base.OnGainedOwnership();
    }

    public override void OnLostOwnership()
    {
        base.OnLostOwnership();
    }

    public override void OnNetworkDespawn()
    {
        base.OnNetworkDespawn();
    }

    public override void OnNetworkObjectParentChanged(NetworkObject parentNetworkObject)
    {
        base.OnNetworkObjectParentChanged(parentNetworkObject);
    }

    #endregion Networking Methods

    #region Private Methods

    // Private Methods.

    public void ReadyUp()
    {
        if (!IsOwner) return;
        Debug.Log(OwnerClientId + "; Num players" + nm.ConnectedClientsList.Count);
        ValidateReady();
    }

    private void UnreadyUp()
    {
    }

    public void ValidateReady()
    {
        // If everyone is ready load the next scene
        //if (numReady !>= nm.players)
        // Add 1 since int is exclusive.
        SceneManager.LoadScene(Random.Range(1, numTracks + 1));
    }

    #endregion Private Methods

    #region Public Methods

    // Public Methods.

    #endregion Public Methods
}