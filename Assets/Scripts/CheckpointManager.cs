using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    #region Variables

    // Variables.
    public List<GameObject> essentialCheckpoints;

    public int numCheckpoints;

    public int curCheckpoint;
    #endregion Variables

    #region Unity Methods

    private void Start()
    {

    }

    private void Update()
    {
    }

    #endregion Unity Methods

    #region Private Methods

    // Private Methods.

    #endregion Private Methods

    #region Public Methods

    // Public Methods.
    public void ValidateCheckpoint(int checkpointNum)
    {
        // Check if it is the next checkpoint
        if (checkpointNum == curCheckpoint + 1)
        {
            curCheckpoint++;
            // Reached finishline
            if (checkpointNum == numCheckpoints)
            {
                curCheckpoint = 0;
                // IncementLap
                // reset checkpoint count
                // call win functions
            }
            // UpdatePlace(CurCheckpoint)
        }
    }

    #endregion Public Methods
}