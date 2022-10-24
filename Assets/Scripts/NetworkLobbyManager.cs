using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkLobbyManager : NetworkBehaviour
{
    #region Variables
    // Variables.
    
    #endregion
	
    #region Unity Methods
	
    void Start()
    {
        
    }
	
    void Update()
    {
        
    }
	
    #endregion
	
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
	
	#endregion
	
    #region Private Methods
    // Private Methods.
    
    #endregion
	
    #region Public Methods
    // Public Methods.
    
    #endregion
}