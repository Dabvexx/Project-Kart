using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    #region Variables
    // Variables.
    public int checkpointNum = 0;
    #endregion

    #region Unity Methods

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Enter Cp");
        // If a kart hits the checkpoint, validate checkpoint
        //if (other.gameObject.CompareTag("Kart"))
        //{
            Debug.Log($"Hit checkpoint {checkpointNum}");
            FindObjectOfType<CheckpointManager>().ValidateCheckpoint(checkpointNum);
        //}
    }

    #endregion

    #region Private Methods
    // Private Methods.

    #endregion

    #region Public Methods
    // Public Methods.

    #endregion
}
