using System.IO;
using Assets.HeroEditor4D.Common.CharacterScripts;
#if UNITY_EDITOR
 using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class CreateUISprites : SingletonMonobehaviour<CreateUISprites>
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

    public void RefreshImages(PlayerStats player)
    {
        Character4D movement = player.GetComponent<Character4D>();
        PlayerGlobalData data = player.GetComponent<PlayerGlobalData>();
        movement.SetDirection(Vector2.down);
        SaveTempData(data);
        TakePicture(player, "front");
        movement.SetDirection(Vector2.right);
        TakePicture(player, "right");
        LoadTempData(data);
#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }

    private void TakePicture(PlayerStats player, string direction)
    {
        globalLight.intensity = global;
        RenderTexture renderTexture = new(512, 512, 24);
        offscreenCamera.targetTexture = renderTexture;
        offscreenCamera.clearFlags = CameraClearFlags.Depth;
        Texture2D offscreenTexture = new(offscreenCamera.targetTexture.width, offscreenCamera.targetTexture.height);
        RenderTexture.active = offscreenCamera.targetTexture;
        offscreenCamera.Render();
        offscreenTexture.ReadPixels(
            new Rect(0, 0, offscreenCamera.targetTexture.width, offscreenCamera.targetTexture.height), 0, 0);
        offscreenCamera.targetTexture = null;
        RenderTexture.active = null;
        offscreenTexture.Apply(false, false);
        offscreenCamera.enabled = false;
        byte[] bytes = offscreenTexture.EncodeToPNG();
        string path = Application.dataPath + "/Resources/PNGs/" + player.playerName + "_" + direction + ".png";
        File.WriteAllBytes(path, bytes);
        Destroy(offscreenTexture);
    }

    private void SaveTempData(PlayerGlobalData playerData)
    {
        lightIntensity = globalLight.intensity;
        playerData.isPaused = true;
        playerData.transform.SetParent(playerSeat);
        tempPosition = playerData.transform.position;
        bottomLeftEdge = playerData.bottomLeftEdge;
        topRightEdge = playerData.topRightEdge;
        playerData.activeBase.SetActive(false);
        playerData.SetPhotoBoothLimit();
        playerData.transform.position = playerSeat.transform.position;
        playerData.transform.localScale = Vector3.one;
    }

    private void LoadTempData(PlayerGlobalData playerData)
    {
        globalLight.intensity = lightIntensity;
        playerData.transform.SetParent(characters);
        playerData.transform.position = tempPosition;
        playerData.transform.localScale = Vector3.one;
        playerData.bottomLeftEdge = bottomLeftEdge;
        playerData.topRightEdge = topRightEdge;
        playerData.isPaused = false;
        playerData.activeBase.SetActive(true);
    }
}