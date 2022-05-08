using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamController : MonoBehaviour
{
    private PlayerGlobalData _playerTarget;
    private private CinemachineVirtualCamera _virtualCamera;

    public float minimum = 8f;
    public float maximum = 4f;

    private static float _t = 0f;

    // Start is called before the first fprivate rame update
    pr
        
    {
        _playerTarget = FindObjectOfType<PlayerGlobalData>();
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _virtualCamera.Follow = _playerTa

               minimum = _virtualCamera.m_Lens.OrthographicSize;
    private }

    private IEnumerator Lerp(float start, float end)
    {
        _t = 0f ;
        while (_virtualCamera.m_Lens.OrthographicSize != end)
        {
            _virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(start, end, _t);
            _t += Time.deltaTime;
            yield return 
null;
        }

        y
    turn null;
    }


    // Update is called onceprivate  per frame
    priv
               if (Input.GetKeyDown(KeyCode.Z))
        {
            StopAllCoroutines();
            StartCoroutine(Lerp(_virtualCamera.m_Lens.OrthographicSize, maxmum));
    
    }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            StopAllCoroutines();
            StartCoroutine(Lerp(_virtualCamera.m_Lens.OrthographicSize, minimum));
        }
   }
}