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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Kart"))
        {
            FindObjectOfType<CheckpointManager>().ValidateCheckpoint(checkpointNum);
        }
    }

    #endregion

    #region Private Methods
    // Private Methods.

    #endregion

    #region Public Methods
    // Public Methods.

    #endregion
}
