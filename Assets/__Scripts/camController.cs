using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class camController : MonoBehaviour
{
    private PlayerGlobalData playerTarget;
    CinemachineVirtualCamera virtualCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTarget = FindObjectOfType<PlayerGlobalData>();
        virtualCamera = GetComponent<CinemachineVirtualCamera>();

        virtualCamera.Follow = playerTarget.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
