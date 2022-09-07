using System.IO;
using Assets.HeroEditor4D.Common.CharacterScripts;
using Sirenix.OdinInspector;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class CreatePlayerPNGs : SingletonMonobehaviour<CreatePlayerPNGs>
{
    #region public members

    [Tooltip("The camera that is used for off-screen rendering.")]
    public Camera offscreenCamera;

    [SerializeField] private Transform playerSeat;
    [SerializeField] private Transform characters;

    private Vector3 tempPosition;
    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;
    private float lightIntensity;

    [SerializeField] private Light2D globalLight;

    [SerializeField] private Image photoSnapshot;
    [SerializeField] private float global;

    #endregion


    [Button("RefreshImages")]
    public void Photobooth(PlayerStats stats, string receivedPath)
    {
        Character4D movement = stats.GetComponent<Character4D>();
        stats.TryGetComponent(out NPCMovement npc);
        stats.TryGetComponent(out PlayerGlobalData player);
        movement.SetDirection(Vector2.down);
        if (stats.playerName == "Thulgran") { SaveTempData(player); }
        else if (stats.playerName != "Thulgran") { SaveTempData(npc); }

        string path = receivedPath + "_front" + ".png";
        TakePicture(path);
        movement.SetDirection(Vector2.right);
        path = receivedPath + "_right" + ".png";
        TakePicture(path);
        if (stats.playerName == "Thulgran") { LoadTempData(player); }
        else if (stats.playerName != "Thulgran") { LoadTempData(npc); }

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }

    private void TakePicture(string path)
    {
        globalLight.intensity = global;
        RenderTexture renderTexture = new(512, 512, 24);
        offscreenCamera.targetTexture = renderTexture;
        offscreenCamera.clearFlags = CameraClearFlags.Depth;
        Texture2D offscreenTexture = new(offscreenCamera.targetTexture.width, offscreenCamera.targetTexture.height);
        RenderTexture.active = offscreenCamera.targetTexture;
        offscreenCamera.Render();
        offscreenTexture.ReadPixels(
            new Rect(0, 0, offscreenCamera.targetTexture.width, offscreenCamera.targetTexture.height),
            0,
            0);
        offscreenCamera.targetTexture = null;
        RenderTexture.active = null;
        offscreenTexture.Apply(false, false);
        offscreenCamera.enabled = false;
        byte[] bytes = offscreenTexture.EncodeToPNG();

        if (!Directory.Exists(Application.persistentDataPath + "/Resources/PNGs/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Resources/PNGs/");
        }

        File.WriteAllBytes(path, bytes);
        Destroy(offscreenTexture);
    }

    private void SaveTempData(NPCMovement npc)
    {
        lightIntensity = globalLight.intensity;
        npc.isPaused = true;
        tempPosition = npc.transform.position;
        bottomLeftEdge = npc.bottomLeftEdge;
        topRightEdge = npc.topRightEdge;
        npc.activeBase.SetActive(false);
        npc.SetPhotoBoothLimit();
        npc.transform.position = playerSeat.transform.position;
    }

    private void SaveTempData(PlayerGlobalData player)
    {
        lightIntensity = globalLight.intensity;
        player.isPaused = true;
        tempPosition = player.transform.position;
        bottomLeftEdge = player.bottomLeftEdge;
        topRightEdge = player.topRightEdge;
        player.activeBase.SetActive(false);
        player.SetPhotoBoothLimit();
        player.transform.position = playerSeat.transform.position;
    }

    private void LoadTempData(NPCMovement npc)
    {
        globalLight.intensity = lightIntensity;
        npc.transform.position = tempPosition;
        npc.transform.localScale = Vector3.one;
        npc.bottomLeftEdge = bottomLeftEdge;
        npc.topRightEdge = topRightEdge;
        npc.isPaused = false;
        npc.activeBase.SetActive(true);
    }

    private void LoadTempData(PlayerGlobalData player)
    {
        globalLight.intensity = lightIntensity;
        player.transform.position = tempPosition;
        player.bottomLeftEdge = bottomLeftEdge;
        player.topRightEdge = topRightEdge;
        player.isPaused = false;
        player.activeBase.SetActive(true);
    }
}