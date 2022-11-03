using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkSpawn : NetworkBehaviour
{
    #region Variables
    // Variables.
    [SerializeField] GameObject spawnObj;
    #endregion

    #region Unity Methods

    void Start()
    {
        SpawnObjectServerRpc();
    }

    void Update()
    {
        
    }

    #endregion

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

        GameObject go = Instantiate(spawnObj, Vector3.zero, Quaternion.identity);
        var netObj = go.GetComponent<NetworkObject>();
        netObj.Spawn();
        netObj.ChangeOwnership(clientId);
    }
    #endregion

    #region Public Methods
    // Public Methods.
    
    #endregion
}
