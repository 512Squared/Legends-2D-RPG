using UnityEngine;
using UnityEngine.Audio;

public class DynamicAudio : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixerMain;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private SceneObjectsLoad sceneHome;

    private string currentScene;
    
    [Space]
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float sfxRadius;

    private Vector3 targetPos;

    [SerializeField]
    private Transform player;

    private Vector3 playerPos;


    private void Start()
    {
        targetPos = target.position;
        playerPos = player.position;
        audioMixerMain.SetFloat("SFXFire", Mathf.Log10(0) * 20);
    }

    private void FixedUpdate()
    {
        playerPos = player.position;
        float dist = Vector2.Distance(playerPos, targetPos);
        
        if (dist < sfxRadius)
        {
            audioMixerMain.SetFloat("SFXFire", Mathf.Log10(1 - (dist/sfxRadius)) * 20);
        }
    }

    public void SetScene(string scene, string arrivingFrom)
    {
        if (sceneHome.ToString() == scene)
        {
            audioSource.enabled = true;
            Debug.Log($"Audio source: {audioSource.name} | SFXHome Enum: {sceneHome.ToString()} | Scene: {scene} | Arriving from: {arrivingFrom} | status: {audioSource.enabled}");
            return;
        }
        
        audioSource.enabled = false;
    }
}