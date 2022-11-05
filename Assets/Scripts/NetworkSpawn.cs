using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkSpawn : NetworkBehaviour
{
    #region Variables

    // Variables.
    [SerializeField] private GameObject spawnObj;

    public Transform spawnPoint;

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        SpawnObjectServerRpc();
    }

    private void Update()
    {
    }

    #endregion Unity Methods

    #region Private Methods

    // Private Methods.

    [ServerRpc(RequireOwnership = false)]
    private void SpawnObjectServerRpc(ServerRpcParams serverRpcParams = default)
    {
        enabled = IsServer;
        if (!enabled || spawnObj == null)
        {
            return;
        }

        var clientId = serverRpcParams.Receive.SenderClientId;

        GameObject go = Instantiate(spawnObj, spawnPoint.position, spawnPoint.rotation);
        var netObj = go.GetComponent<NetworkObject>();
        netObj.Spawn();
        netObj.ChangeOwnership(clientId);
    }

    #endregion Private Methods

    #region Public Methods

    // Public Methods.

    #endregion Public Methods
}