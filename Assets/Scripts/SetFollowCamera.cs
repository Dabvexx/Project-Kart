using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SetFollowCamera : MonoBehaviour
{
    #region Variables

    // Variables.

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        //var vcam = FindObjectOfType<CinemachineVirtualCamera>().GetComponent<CinemachineVirtualCamera>();
        var vcam = FindObjectOfType<CinemachineFreeLook>().GetComponent<CinemachineFreeLook>();
        vcam.Follow = transform;
        vcam.LookAt = transform;
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