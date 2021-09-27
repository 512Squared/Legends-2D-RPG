using UnityEngine;
using System.Collections;

namespace FM.Legacy{
	public class Scroller : MonoBehaviour {
		private float screenWidth, screenHeight;

		#region Input
		private bool pressed;
		private Vector2 initPosition;
		private Vector2 initMousePosition;
		#endregion

		#region PullBackToBounds
		private bool pullBack;
		private float edgeTarget;
		private float timeElapsedInLerp = 0f;
		private float oneFrameDistance;
		[SerializeField] private float extraSlideDuration;
		#endregion

		#region Kinetic Scrolling
		private float timeStart, timeEnd;
		private float positionStart, positionEnd;
		private float speed, distance, time;
		[SerializeField] float scrollFriction;
		private float initScrollPos;
		#endregion

		#region Size
		private RectTransform rectTransform;
		private Transform scrollPanel;
		[SerializeField] private RectTransform childRectTransform;
		[SerializeField] private float ignoreDisplacement;
		#endregion

		#region PageSelector
		private RectTransform selectedItem;
		private int selectedItemIndex = 0;
		private bool lerpToCurrentItem;
		private float targetCenterPosition;
		private float targetDiff;
		private float targetSelectPosition;
		private bool targetAquired;
		#endregion

		#region Selection From Other Inputs
		private int numberOfTracks;
		private bool keyboardInput;
		private bool changePanel;
		#endregion

		private OnItemSelected itemSelected;

		// Orientation Manager
		private bool horizontal = false;

		void Awake(){
			numberOfTracks = transform.childCount;
		}

		public void SetOnItemSelectedCallback(OnItemSelected _itemSelected){
			itemSelected = _itemSelected;
		}

		public void SetCurrentItem(RectTransform _selectedItem, int index){
			if(selectedItem != _selectedItem){
				selectedItem = _selectedItem;
				lerpToCurrentItem = true;
				selectedItemIndex = index;
				if(itemSelected != null){
					itemSelected.OnCurrentItemSelected(selectedItemIndex);
				}
				// Debug.Log("Selection: "+selectedItemIndex);
			}
		}

		public void SelectItem(int index, bool animate = false){
			selectedItemIndex = index;
			float position = (rectTransform.rect.width/2) - ((index * childRectTransform.rect.width) + childRectTransform.rect.width/2);
			if(animate){
				keyboardInput = true;
				StartCoroutine(MoveToSelectedPosition(position));
			}else{
				rectTransform.localPosition = new Vector3(position , rectTransform.localPosition.y, rectTransform.localPosition.z);
			}
		}

		IEnumerator MoveToSelectedPosition(float targetPosition){
			yield return new WaitForFixedUpdate();
			if(Mathf.Abs(targetPosition - rectTransform.localPosition.x) <= 50f){
				keyboardInput = false;
				rectTransform.localPosition = new Vector3(targetPosition , rectTransform.localPosition.y, rectTransform.localPosition.z);
				yield break;
			}
			if(targetPosition > rectTransform.localPosition.x){
				rectTransform.localPosition = new Vector3(rectTransform.localPosition.x + (Time.fixedDeltaTime * 5000f) , rectTransform.localPosition.y, rectTransform.localPosition.z);	
				StartCoroutine(MoveToSelectedPosition(targetPosition));
			}else if(targetPosition < rectTransform.localPosition.x){
				rectTransform.localPosition = new Vector3(rectTransform.localPosition.x - (Time.fixedDeltaTime * 5000f) , rectTransform.localPosition.y, rectTransform.localPosition.z);	
				StartCoroutine(MoveToSelectedPosition(targetPosition));
			}
		}

		void Start () {
			rectTransform = GetComponent<RectTransform>();
			scrollPanel = GetComponent<Transform>();


			Debug.Log(scrollPanel.position);
			Debug.Log(scrollPanel.localPosition);

			UpdateScreenConfig();
		}

		void UpdateScreenConfig(){
			screenHeight = Screen.height;
			screenWidth = Screen.width;
			targetCenterPosition = screenWidth / 2;
			edgeTarget = (rectTransform.rect.width / 2) - (childRectTransform.rect.width / 2);
		}

		void Update () {
			#region Orientation
			if(Screen.width > Screen.height){
				if(!horizontal){
					horizontal = true;
					UpdateScreenConfig();
				}
			}else{
				if(horizontal){
					horizontal = false;
					UpdateScreenConfig();
				}
			}
			#endregion
			if(keyboardInput){
				return;
			}
			if(Input.GetAxis("Horizontal") > 0){
				if(!changePanel){
					SlideRight();
					changePanel = true;
				}
			}else if(Input.GetAxis("Horizontal") < 0){
				if(!changePanel){
					SlideLeft();
					changePanel = true;
				}
			}else{
				changePanel = false;
			}
			// Debug.Log("speed: "+speed +", lerp: "+lerpToCurrentItem +", pressed: "+pressed);
			if(transform.childCount == 0){
				return;
			}
			if(pullBack && !pressed){
				float targetX = 0f;
				if(scrollPanel.localPosition.x < 0){
					targetX = -edgeTarget;
				}else if(scrollPanel.localPosition.x > 0){
					targetX = edgeTarget;
				}

				LerpResult lerpResult = Utils.ConstantLerp(new Vector3(scrollPanel.localPosition.x, scrollPanel.localPosition.y, scrollPanel.localPosition.z), new Vector3(targetX, scrollPanel.localPosition.y, scrollPanel.localPosition.z), extraSlideDuration, timeElapsedInLerp);
				timeElapsedInLerp += lerpResult.timeThisFrame;

				scrollPanel.localPosition = lerpResult.result;
				// Debug.Log("x: "+scrollPanel.localPosition.x + ", target: "+targetX);
				if(Mathf.Abs(scrollPanel.localPosition.x - targetX) <= oneFrameDistance + 10f){
					timeElapsedInLerp = 0f;
					scrollPanel.localPosition = new Vector3(targetX, scrollPanel.localPosition.y, scrollPanel.localPosition.z);
					pullBack = false;
				}
				return;
			}

			if(speed != 0 && !pressed){
				if(speed > 0){
					speed -= scrollFriction;
				}else{
					speed += scrollFriction;
				}

				if(Mathf.Abs(speed) < scrollFriction){
					speed = 0f;
				}

				scrollPanel.position = new Vector3(scrollPanel.position.x + (speed * Time.deltaTime), scrollPanel.position.y, scrollPanel.position.z);

			}

			if(speed == 0 && lerpToCurrentItem && !pressed){
				// Debug.Log("my pos: "+transform.position.x + ", currentItemPos: "+selectedItem.position.x + ", name: "+selectedItem.name);

				if(!targetAquired){
					// Debug.Log("item: "+selectedItem.name);
					targetDiff = targetCenterPosition - selectedItem.position.x;
					targetSelectPosition = transform.position.x + targetDiff;
					targetAquired = true;
				}

				LerpResult lerpResult = Utils.ConstantLerp(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(targetSelectPosition, transform.position.y, transform.position.z), extraSlideDuration, timeElapsedInLerp);
				timeElapsedInLerp += lerpResult.timeThisFrame;

				scrollPanel.position = lerpResult.result;
				// Debug.Log("x: "+transform.position.x + ", target: "+targetSelectPosition);
				if(Mathf.Abs(transform.position.x - targetSelectPosition) <= oneFrameDistance + 10f){
					timeElapsedInLerp = 0f;
					scrollPanel.position = new Vector3(targetSelectPosition, transform.position.y, transform.position.z);
					lerpToCurrentItem = false;
					targetAquired = false;
				}
			}

			if(Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)){
				float mousePos = Input.mousePosition.y  - (screenHeight/2);
				if(mousePos < rectTransform.localPosition.y - (rectTransform.rect.height/2) || mousePos > rectTransform.localPosition.y + (rectTransform.rect.height/2)){
					return;
				}
				pressed = true;
				initPosition = scrollPanel.position;
				initMousePosition = Input.mousePosition;

				timeStart = Time.time;
				positionStart = Input.mousePosition.x;
				
				lerpToCurrentItem = false;
				targetAquired = false;
			}
			if(Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) && pressed){
				pressed = false;

				timeEnd = Time.time;
				positionEnd = Input.mousePosition.x;
				time = timeEnd - timeStart;
				distance = positionEnd - positionStart;
				speed = distance/time;
				// Debug.Log("time: "+ time +", distance: "+distance + ", speed: "+speed);
				lerpToCurrentItem = true;
			}

			Vector2 mousePosition = Input.mousePosition;
			float diff = mousePosition.x - initMousePosition.x;

			// Debug.Log("localposition: " + scrollPanel.localPosition.x);
			// Debug.Log("edgetarget: " + edgeTarget);
			// Debug.Log("allowed x: "+ (edgeTarget + ignoreDisplacement));

			if(Mathf.Abs(scrollPanel.localPosition.x) >= (rectTransform.rect.width/2) - (childRectTransform.rect.width/2) + ignoreDisplacement){
				timeElapsedInLerp = 0f;
				pullBack = true;
				oneFrameDistance = (Mathf.Abs(scrollPanel.localPosition.x) - edgeTarget) * (1/extraSlideDuration) * Time.deltaTime;
				speed = 0f;
				return;
			}

			if(pressed){
				scrollPanel.position = new Vector2(initPosition.x + diff, scrollPanel.position.y);
				initScrollPos = rectTransform.localPosition.x;
			}
		}

		public int GetCurrentItem(){
			return selectedItemIndex;
		}

		public void SlideRight(){
			if(keyboardInput){
				return;
			}
			if(selectedItemIndex + 1 < numberOfTracks){
				SelectItem(selectedItemIndex + 1, true);
			}
		}

		public void SlideLeft(){
			if(keyboardInput){
				return;
			}
			if(selectedItemIndex - 1 >= 0){
				SelectItem(selectedItemIndex - 1, true);
			}
		}

		public bool IsScrolling(){
			// Debug.Log(rectTransform.localPosition.x +", "+initScrollPos);
			if(Mathf.Abs(rectTransform.localPosition.x - initScrollPos) >= 0.1f || speed > 0 || lerpToCurrentItem){
				return true;
			}
			return false;
		}

	}

	public interface OnItemSelected{
		void OnCurrentItemSelected(int index);
	}
}