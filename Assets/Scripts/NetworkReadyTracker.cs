using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NetworkReadyTracker : NetworkBehaviour
{
    #region Variables

    // Variables.

    [SerializeField] private int numTracks = 1;
    private NetworkManager nm;
    [SerializeField] private NetworkVariable<int> numReady = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        nm = FindObjectOfType<NetworkManager>();
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

    #region Public Methods

    // Public Methods.
    [ServerRpc(RequireOwnership = false)]
    public void ReadyUpServerRpc()
    {
        Debug.Log(OwnerClientId + "; Ready Up Request Sent");
        numReady.Value++;
        ValidateReady();
    }

    [ServerRpc(RequireOwnership = false)]
    public void UnreadyUpServerRpc()
    {
        Debug.Log(OwnerClientId + "; Ready Up Request Sent");
        numReady.Value--;
        //NetworkManager.OnClientConnectedCallback += SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        // spawn a player
    }

    public void ValidateReady()
    {
        Debug.Log("Validating Ready");
        // If everyone is ready load the next scene
        if (numReady.Value! >= nm.ConnectedClientsList.Count)
        {
            // Add 1 since int is exclusive in rand.
            // also this is a nightmare string to get the string of scene name by index, thank you ibx00
            //http://answers.unity.com/answers/1696751/view.html
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(Random.Range(1, numTracks + 1)));

            NetworkManager.SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }

    #endregion Public Methods
}