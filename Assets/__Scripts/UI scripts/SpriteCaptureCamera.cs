using UnityEngine;

namespace AeseriaGaming.Guildmaster.V2.Common
{
    [RequireComponent(typeof(Camera))]
    public class SpriteCaptureCamera : MonoBehaviour
    {
        private Camera _captureCamera;

        public Sprite CaptureSprite(int resolution)
        {
            return Sprite.Create(Capture(resolution, resolution), new Rect(0, 0, resolution, resolution), new Vector2(.5f, .5f));
        }

        public Texture2D Capture(int width, int height)
        {
            var cam = _captureCamera ??= GetComponent<Camera>();
            cam.enabled = true;

            var renderTexture = new RenderTexture(width, height, 24);
            var texture2D = new Texture2D(width, height, TextureFormat.ARGB32, false);

            cam.targetTexture = renderTexture;
            cam.Render();
            RenderTexture.active = renderTexture;
            texture2D.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            cam.targetTexture = null;
            RenderTexture.active = null;
            texture2D.Apply();
            Destroy(renderTexture);

            cam.enabled = false;

            return texture2D;
        }
    }
}