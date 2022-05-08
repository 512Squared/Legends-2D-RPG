using System;
using UnityEngine;
using Cinemachine;

public class CameraZoom MonoBehaviour
{
   #region FIELDS

    private CinemachineComponentBase _componentBase;
    private float _cameraDistance;

    #endregion FIELDS

    #regi PROPERTIES

    #endregion PROPERTIES

    #region SERIALIZATION

    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float sensitivity = 10f;

    #endregion SERIALIZATION

    #region CALLBACKS

    private void Update()
    {
        if (virtualCamera.Follow == null)
        {
            virtualCamera.Follow = virtualCamera.Follow.Find("Player");
            virtualCamera.LookAt = virtualCamera.LookAt
.Find("Player");
        }

        if (virtualCamera == null)
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        if (_componentBase == null)
        {
            _componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }

        if (Input.GetAxis("Scrollwheel") != 0)
        {
            _cameraDistance = Input.GetAxis("Scrollwheel") *  sensitivity;
            if (_componentBase is CinemachineFramingTransposer)
            {
                (_componentBase as CinemachineFramingTransposer).m_CameraDistance -= _cameraDistance;
            }
      }
    }

    #endregion


    #region SUBSCRIBE

    #endregion SUBSCRIBERS

    #region INVOCATION
    #endregion INVOCATIONS

    #region COROUTIS

    #endregion COROUTNE

    #region METHODS

    #endregion METHODS
}