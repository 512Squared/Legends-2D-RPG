using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FM {
    public class CarouselView : MonoBehaviour, IBeginDragHandler, IEndDragHandler {
        public Canvas parentCanvas;
        public float maxScale = 1f;
        public float minScale = 0.7f;
        public float axisSlideDuration = 0.3f;

        private RectTransform contentT;

        private RectTransform rectT;
        private ScrollRect scrollT;

        bool isPressed;
        bool isSnapping;
        Coroutine snapper;

        private float viewWidth;
        [HideInInspector] public int selectedIndex = -1;
        [HideInInspector] public Transform selectedItem;

        [HideInInspector] public System.Action<int> OnItemClick;

        bool scrolling;

        public void OnBeginDrag(PointerEventData eventData) {
            isPressed = true;
            if (snapper != null) {
                StopCoroutine(snapper);
                isSnapping = false;
            }
        }

        public void OnEndDrag(PointerEventData eventData) {
            isPressed = false;
        }

        void Start() {
            scrolling = false;
            contentT = transform.Find("Viewport").Find("Content").GetComponent<RectTransform>();
            rectT = GetComponent<RectTransform>();
            scrollT = GetComponent<ScrollRect>();

            System.Action Init = () => {
                viewWidth = (rectT.rect.width) / 2f;
            };

            Init();

            GetComponent<DeviceOrientation>().AddOnOrienationChange((DeviceOrientation.Orientation or) => {
                Init();
            });

            scrollT.onValueChanged.AddListener((Vector2 value) => {
                if (!isPressed) {
                    if (Mathf.Abs(scrollT.velocity.x) < 500f) {
                        if (!isSnapping) {
                            scrollT.StopMovement();
                            snapper = StartCoroutine(Tween(contentT, new Vector2(-(selectedItem.localPosition.x - (viewWidth)), contentT.localPosition.y), 0.1f));
                        }
                    } else {
                        scrolling = true;
                    }
                }
            });
        }

        void OnGUI() {
            if (isSnapping) {
                return;
            }
            if (Input.GetAxis("Horizontal") > 0) {
                Next();
            }
            if (Input.GetAxis("Horizontal") < 0) {
                Previous();
            }
        }

        public void Next() {
            if (scrolling) {
                return;
            }
            if (selectedIndex >= contentT.childCount - 1) {
                return;
            }
            selectedIndex++;
            Move();
        }

        public void Previous() {
            if (scrolling) {
                return;
            }
            if (selectedIndex <= 0) {
                return;
            }
            selectedIndex--;
            Move();
        }

        public void SelectIndex(int index, bool animate) {
            if (scrolling) {
                return;
            }
            if (index < 0 || index > contentT.childCount - 1) {
                Debug.LogError("Index Out of Bound!");
                return;
            }
            selectedIndex = index;
            if (animate) {
                Move();
            } else {
                SetPosition();
            }
        }

        void Move() {
            scrolling = true;
            selectedItem = contentT.GetChild(selectedIndex);
            scrollT.StopMovement();
            snapper = StartCoroutine(Tween(contentT, new Vector2(-(selectedItem.localPosition.x - (viewWidth)), contentT.localPosition.y), axisSlideDuration));
        }

        void SetPosition() {
            selectedItem = contentT.GetChild(selectedIndex);
            scrollT.StopMovement();
            snapper = StartCoroutine(Tween(contentT, new Vector2(-(selectedItem.localPosition.x - (viewWidth)), contentT.localPosition.y), 0.1f));
        }

        IEnumerator Tween(RectTransform item, Vector2 destination, float duration) {
            isSnapping = true;
            int approxNoOfFrames = Mathf.RoundToInt(duration / Time.deltaTime);
            float posDiff = destination.x - item.localPosition.x;
            float eachFrameProgress = posDiff / approxNoOfFrames;
            for (int i = 0; i < approxNoOfFrames; i++) {
                yield return new WaitForEndOfFrame();
                item.localPosition = new Vector2(item.localPosition.x + eachFrameProgress, destination.y);
            }
            yield return new WaitForEndOfFrame();
            item.localPosition = destination;
            isSnapping = false;
            scrolling = false;
        }

        public int GetCurrentItem() {
            return selectedIndex;
        }

        public void AddOnItemSelectedListener(System.Action<int> Callback) {
            OnItemClick += Callback;
        }

    }
}