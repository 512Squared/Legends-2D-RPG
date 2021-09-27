using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace FM{
    public class CarouselViewMenu : MonoBehaviour {
        [MenuItem("GameObject/UI/CarouselView")]
        private static void AddCarouselView(){
            GameObject carouselView = Instantiate(Resources.Load("CarouselView") as GameObject);
            carouselView.name = "CarouselView";

            Canvas canvas = GameObject.FindObjectOfType<Canvas>();
            if(canvas != null){
                carouselView.transform.SetParent(canvas.transform);
                carouselView.GetComponent<CarouselView>().parentCanvas = canvas;
            }else{
                GameObject canvasClone = new GameObject();
                canvasClone.name = "Canvas";
                canvasClone.AddComponent(typeof(Canvas));
                canvasClone.AddComponent(typeof(CanvasScaler));
                canvasClone.AddComponent(typeof(GraphicRaycaster));

                canvas = canvasClone.GetComponent<Canvas>();

                canvasClone.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
                canvasClone.GetComponent<Canvas>().additionalShaderChannels = AdditionalCanvasShaderChannels.TexCoord1;

                canvasClone.GetComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                canvasClone.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1080, 1920);
                canvasClone.GetComponent<CanvasScaler>().screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
                canvasClone.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.5f;

                carouselView.transform.SetParent(canvasClone.transform);

                carouselView.GetComponent<CarouselView>().parentCanvas = canvas;
            }

            if(GameObject.FindObjectOfType<EventSystem>() == null){
                GameObject eventSystem = new GameObject();
                eventSystem.name = "EventSystem";
                eventSystem.AddComponent(typeof(EventSystem));
                eventSystem.AddComponent(typeof(StandaloneInputModule));
            }

            carouselView.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300f);
            carouselView.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 300f);

            carouselView.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

            Selection.objects = new Object[] { carouselView };

        }
    }
}
