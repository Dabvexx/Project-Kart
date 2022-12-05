using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class CheckpointManager : MonoBehaviour
{
    #region Variables

    // Variables.
    // Text boxes
    public TextMeshProUGUI lapBox;
    public TextMeshProUGUI checkpointBox;

    // Checkpoint stuff
    public List<GameObject> essentialCheckpoints;

    public int numCheckpoints;

    public int curCheckpoint;

    public int lap;
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
                lap++;

                lapBox.text = $"Lap: {lap}";
                // reset checkpoint count
                // call win functions
            }
            // UpdatePlace(CurCheckpoint)
            checkpointBox.text = $"Checkpoint: {curCheckpoint}";
        }
    }

    #endregion Public Methods
}