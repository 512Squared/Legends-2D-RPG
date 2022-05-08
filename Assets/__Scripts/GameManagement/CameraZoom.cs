using System;
using UnityEngine;
using Cinemachine;

public class CameraZoom   : MonoBehaviour
{

    #region FIELDS

    CinemachineComponentBase componentBase;
    float cameraDistance;

    #endregion FIELDS

    #region PROPERTIES



    #endregion PROPERTIES

    #region SERIALIZATION

    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] float sensitivity = 10f;

    #endregion SERIALIZATION

    #region CALLBACKS

    private void Update()
    {
        if (virtualCamera.Follow == null)
        {
            virtualCamera.Follow = virtualCamera.Follow.Find("Player");
            virtualCamera.LookAt = virtualCamera.LookAt.Find("Player");
        }
        if (virtualCamera == null)
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        if (componentBase == null)
        {
            componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }

        if (Input.GetAxis("Scrollwheel") != 0)
        {
            cameraDistance = Input.GetAxis("Scrollwheel") * sensitivity;
            if(componentBase is CinemachineFramingTransposer)
                (componentBase as CinemachineFramingTransposer).m_CameraDistance -= cameraDistance;
        }
    }

    #endregion


    #region SUBSCRIBERS



    #endregion SUBSCRIBERS

    #region INVOCATIONS



    #endregion INVOCATIONS

    #region COROUTINES



    #endregion COROUTINES

    #region METHODS



    #endregion METHODS

}
