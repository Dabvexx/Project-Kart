using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

/// <summary>
/// Spawn an object on the server with ownership to the client who requested the spawn
/// the server is not authoritative because that would be really annoying to make the server keep track of where everyone is
/// </summary>
public class NetworkSpawn : NetworkBehaviour
{
    #region Variables

    // Variables.
    [SerializeField] private GameObject spawnObj;

    public Transform spawnPoint;

    // List of spawn points to start
    // after each spawn remove from list and decrement amount of useable spawners
    // or spawn at spawner matching client ID

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        SpawnObjectServerRpc();
    }

    #endregion Unity Methods

    #region Private Methods

    // Private Methods.

    [ServerRpc(RequireOwnership = false)]
    private void SpawnObjectServerRpc(ServerRpcParams serverRpcParams = default)
    {
        // Only run this if you are the server and enabled.
        enabled = IsServer;
        if (!enabled || spawnObj == null)
        {
            return;
        }

        // Get the client ID
        var clientId = serverRpcParams.Receive.SenderClientId;

        // Instantiate object over the server and give ownership to the client
        GameObject go = Instantiate(spawnObj, spawnPoint.position, spawnPoint.rotation);
        var netObj = go.GetComponent<NetworkObject>();
        netObj.Spawn();
        netObj.ChangeOwnership(clientId);
    }

    #endregion Private Methods
}