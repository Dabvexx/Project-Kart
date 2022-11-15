using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Cinemachine;

/// <summary>
/// Simply sets the VCAM to follow your car
/// </summary>
public class SetFollowCamera : NetworkBehaviour
{
    #region Variables

    [SerializeField] private CinemachineFreeLook vcam;
    // Variables.

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        //var vcam = FindObjectOfType<CinemachineVirtualCamera>().GetComponent<CinemachineVirtualCamera>();
        if (IsLocalPlayer)
        {
            vcam = FindObjectOfType<CinemachineFreeLook>().GetComponent<CinemachineFreeLook>();
            vcam.Follow = transform;
            vcam.LookAt = transform;
        }
        //vcam.m_YAxis.Value = 4f;
        //vcam.m_XAxis.Value = 6f;
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

    #endregion Public Methods
}