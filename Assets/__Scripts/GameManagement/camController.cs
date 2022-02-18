using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class camController : MonoBehaviour
{
    private PlayerGlobalData playerTarget;
    CinemachineVirtualCamera virtualCamera;

    public float _minimum = 8f;
    public float _maximum = 4f;

    static float t = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
        playerTarget = FindObjectOfType<PlayerGlobalData>();
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        virtualCamera.Follow = playerTarget.transform;
        
        _minimum = virtualCamera.m_Lens.OrthographicSize;
    }

    IEnumerator Lerp(float start, float end)
    {
        t = 0f;
        while(virtualCamera.m_Lens.OrthographicSize != end)
        {
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(start, end, t);
            t += Time.deltaTime;
            yield return null;
        }
        yield return null;  
    }


    // Update is called once per frame
    void Update()
    {
               
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StopAllCoroutines();
            StartCoroutine(Lerp(virtualCamera.m_Lens.OrthographicSize, _maximum));

        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            StopAllCoroutines();
            StartCoroutine(Lerp(virtualCamera.m_Lens.OrthographicSize, _minimum));
        }
    }
}
