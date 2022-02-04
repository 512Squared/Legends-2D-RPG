/* UltimateMobileQuickbar.cs */
/* Written by Kaz Crowe */
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
[RequireComponent( typeof( CanvasGroup ) )]
[AddComponentMenu( "UI/Ultimate Mobile Quickbar" )]
public class UltimateMobileQuickbar : MonoBehaviour
{
	/* // √
	 * Support additional images for each button
		 * This means that we will need to be able to have a list of additional image components and allow them to be reorganized and placed where the user wants
		 * This also might make the sorting of children a little more complicated and unreliable. This may need to be a thing that we check the sort order multiple times if need be
			 * Something to keep in mind is that I can attempt a sort, and then check each button to see if the sibling index is reliable, and if not then attempt sort again and check. Continue until they line up.
			 * This will only need to be done to the newly created quickbar in play mode because it was just created. Right?
		 * I want to place a section right under Button Overlay that is for Additional Images.
			 * Inside this section you will be able to press a Create New Image button to create a new image. Also, make it available to assign a name for easy navigation. Assign a sprite for customization too.
		 * HOW WILL WE KEEP TRACK AND BE ABLE TO DELETE THESE IF THE USER DOESN'T WANT THEM?
			 * Will we have a list of objects inside each QuickbarButton to keep track of them? Each index in the list will be consistent, so that would work out well. Yeah, try that.
	 * 
	 * 
	 * 
	 * 
	 * 
	 * 
	 * 
	 */

	// INTERNAL CALCULATIONS //
	/// <summary>
	/// Returns the current state of the quickbar.
	/// </summary>
	public bool QuickbarActive
	{
		get;
		private set;
	}
	/// <summary>
	/// Returns the current active quickbar parent index.
	/// </summary>
	public int CurrentParentIndex
	{
		get;
		private set;
	}
	/// <summary>
	/// Returns the currently selected button index.
	/// </summary>
	public int CurrentButtonIndex
	{
		get;
		private set;
	}
	int CurrentButtonIndexOnDown
	{
		get;
		set;
	}
	float ButtonSize
	{
		get;
		set;
	}
	RectTransform baseTransform;
	public bool Transitioning
	{
		get;
		private set;
	}
	Vector2 relativeTransformSize, relativeTransformPosition;
	CanvasGroup canvasGroup;
	int interactPointerId = -10;
	Vector2 inputDownPosition = Vector2.zero;
	public Canvas ParentCanvas
	{
		get;
		private set;
	}
	RectTransform canvasRectTrans;

	// ---------------------------------------- //
	//           QUICKBAR POSITIONING           //
	// ---------------------------------------- //
	public RectTransform relativeTransform;
	public int buttonPerQuickbar = 4;
	public int quickbarCount = 1;
	public float overallAngle = 180.0f;
	public float centerAngle = -45.0f;
	public float buttonSize = 2.5f;
	public float buttonOrbitRadius = 0.75f;
	// Quickbar Set Display //
	public bool useSetDisplay = false;
	public bool setDisplayReverseOrder = false;
	public float setDisplayAngle = 0.0f;
	public float setDisplayAnglePer = 11.25f;
	public float setDisplayOrbitDistance = 0.5f;
	public float setDisplayImageSize = 1.0f;
	public float setDisplayDefaultScaleMultiplier = 0.9f;
	public Color setDisplayDefaultColor = new Color( 0.0f, 0.0f, 0.0f, 0.5f ), setDisplaySelectedColor = Color.white;
	public Sprite setDisplaySprite;
	// Transition Settings //
	public float transitionDuration = 0.25f;
	float transitionSpeed = 0.0f;

	// ------------------------------------- //
	//           QUICKBAR SETTINGS           //
	// ------------------------------------- //
	public Sprite buttonSprite;
	public Color buttonColor = Color.white;
	// Input Settings //
	public float quickbarButtonInputRadius = 1.0f;
	public float inputActiveScale = 0.9f;
	public enum ActionInvoke
	{
		OnButtonDown,
		OnButtonUp
	}
	public ActionInvoke actionInvoke = ActionInvoke.OnButtonUp;
	public enum SwipeTransition
	{
		Clockwise,
		CounterClockwise,
		Disabled
	}
	public SwipeTransition swipeTransition = SwipeTransition.Clockwise;
	public float swipeDistanceModifier = 0.25f;
	public float swipeHeadingThreshold = 0.75f;
	// Cooldown Settings //
	public Sprite cooldownSprite;
	public Color cooldownColor = new Color( 0.0f, 0.0f, 0.0f, 0.5f );
	public bool useCooldownText = false;
	public float textAnchorMod = 0.5f;
	public bool displayDecimalCooldown = false;
	public AnimationCurve cooldownTextScaleCurve = new AnimationCurve( new Keyframe[ 2 ] { new Keyframe( 0.0f, 1.0f ), new Keyframe( 1.0f, 1.0f ) } );
	// Icon Settings //
	public float iconScale = 1.0f;
	public bool useIconMask = false;
	public Sprite iconMaskSprite;
	// Count Text //
	public bool useCountText = false;
	public float countTextSize = 1.0f;
	public float countTextPosX = 50.0f, countTextPosY = 50.0f;
	public Sprite countTextBackgroundSprite;
	// Text Settings //
	public Color textColor = Color.white;
	public bool textOutline = false;
	public Color textOutlineColor = Color.black;
	// Button Overlay //
	public bool useButtonOverlay = false;
	public Sprite buttonOverlaySprite;
	public Color buttonOverlayColor = Color.white;

	[Serializable]
	public class QuickbarButton
	{
		// Reference //
		/// <summary>
		/// The quickbar that this button is attached to.
		/// </summary>
		public UltimateMobileQuickbar Quickbar
		{
			get;
			private set;
		}
		/// <summary>
		/// Returns the state of having information registered to this button.
		/// </summary>
		public bool Registered
		{
			get;
			private set;
		}
		/// <summary>
		/// Returns the state of the button being interactable.
		/// </summary>
		public bool Interactable
		{
			get;
			private set;
		}
		/// <summary>
		/// Returns the button index that this button is registered at.
		/// </summary>
		public int ButtonIndex
		{
			get;
			private set;
		}
		/// <summary>
		/// Returns the parent index of this button.
		/// </summary>
		public int ParentIndex
		{
			get;
			private set;
		}
		/// <summary>
		/// The current position of the button transform.
		/// </summary>
		public Vector2 ButtonPosition
		{
			get
			{
				// If the button transform is unassigned, then return a zero vector.
				if( buttonTransform == null )
					return Vector2.zero;
				
				return ( ( Vector2 )Quickbar.ParentCanvas.transform.InverseTransformPoint( buttonTransform.position ) * Quickbar.ParentCanvas.scaleFactor ) + ( ( Quickbar.canvasRectTrans.sizeDelta * Quickbar.ParentCanvas.scaleFactor ) / 2 );
			}
		}
		// Transform //
		public RectTransform buttonTransform;
		public Vector2 previousButtonPosition, nextButtonPosition, thisButtonPosition;
		// Cooldown //
		public Image cooldownImage;
		public Text cooldownText;
		// Icon //
		public Image buttonIcon;
		public Image buttonIconMask;
		// Overlay //
		public Image buttonOverlayImage;
		// Count Text //
		public Text countText;
		public Image countTextBackground;
		
		// CALLBACK VARIABLES //
		public int id;
		public string key;
		public Action OnButtonInteract;
		public event Action<int> OnButtonInteractWithId;
		public event Action<string> OnButtonInteractWithKey;
		public Action OnClearButtonInformation;
		public Action<int, int> OnChangeParentIndex;

		
		/// <summary>
		/// Updates the needed variables to display the current cooldown time of the button.
		/// </summary>
		/// <param name="currentTime">The current time of the cooldown.</param>
		/// <param name="maxTime">The max time of the cooldown.</param>
		public void UpdateCooldown ( float currentTime, float maxTime )
		{
			// If the button is currently interactable, then set that to false so the player cannot use items while it is in cooldown.
			if( Interactable )
				Interactable = false;

			// Configure the overall percentage of the cooldown with the values provided.
			float overallCooldownPercentage = currentTime / maxTime;

			// if the cooldown image is assigned, then set the fill amount.
			if( cooldownImage != null )
				cooldownImage.fillAmount = overallCooldownPercentage;
			
			// If the cooldown text is assigned...
			if( cooldownText != null )
			{
				// Round the current time value to the nearest int.
				int i = Mathf.RoundToInt( currentTime );

				// If the i value is greater than the current time provided by the user, then reduce i by one. This is because rounding will cause the time to be incorrect.
				if( i > currentTime )
					i -= 1;

				// Configure the string to display on the text by formatting it to a whole number.
				string textToDisplay = ( i + 1 ).ToString( "F0" );

				// If the user wants to show the decimal point however, then format the text for that.
				if( Quickbar.displayDecimalCooldown )
					textToDisplay = currentTime.ToString( "F1" );

				// Apply the configured string.
				cooldownText.text = textToDisplay;

				// Configure a time value that is between 0 and 1 so that the text can be scaled by the animation curve.
				float t = currentTime - i;

				// Evaluate the animation curve.
				cooldownText.rectTransform.localScale = Vector3.Lerp( Vector3.zero, Vector3.one, Quickbar.cooldownTextScaleCurve.Evaluate( -t + 1 ) );
			}

			// If the overall percentage of the cooldown is zero or less, then reset the cooldown since it is done.
			if( overallCooldownPercentage <= 0.0f )
				ResetCooldown();
		}

		/// <summary>
		/// Updates the item count on the quickbar button.
		/// </summary>
		/// <param name="currentCount">The current amount of the item count.</param>
		public void UpdateCount ( int currentCount )
		{
			// If the user doesn't want to use item count, or the count text is null.
			if( !Quickbar.useCountText || countText == null )
				return;

			// If the user wants to use a count text background and it is not active, then set it active.
			if( countTextBackground != null && !countTextBackground.gameObject.activeInHierarchy )
				countTextBackground.gameObject.SetActive( true );

			// Apply the count text.
			countText.text = currentCount.ToString();
		}

		/// <summary>
		/// Clears the button information.
		/// </summary>
		public void ClearButtonInformation ()
		{
			// Set Registered to false since the button is being cleared.
			Registered = false;

			// Reset the key and id values.
			key = "";
			id = -1;

			// Reset the button color.
			buttonTransform.GetComponent<Image>().color = Quickbar.buttonColor;

			// Reset the button icon.
			buttonIcon.sprite = null;
			buttonIcon.color = Color.clear;

			// Reset the cooldown image.
			cooldownImage.fillAmount = 0.0f;

			// Reset the cooldown text.
			if( cooldownText != null )
				cooldownText.text = "";

			// If the user has item count options, and the item count has been setup on this button...
			if( Quickbar.useCountText )
			{
				// If there are unique sprites being used for the item count, then the sprites need to be reset...
				if( countTextBackground != null )
					countTextBackground.gameObject.SetActive( false );

				// Reset the count text.
				if( countText != null )
					countText.text = "";
			}

			// Notify any button information subscribers that this button has not been cleared.
			if( OnClearButtonInformation != null )
				OnClearButtonInformation();

			// Reset callbacks.
			OnButtonInteract = null;
			OnButtonInteractWithId = null;
			OnButtonInteractWithKey = null;
			OnClearButtonInformation = null;
		}

		/// <summary>
		/// [Internal] Returns the result of the input being within range of the button.
		/// </summary>
		public bool IsInRange ( Vector2 inputPos )
		{
			// Configure the distance of the input, divided by the input radius.
			float inputDistance = Vector2.Distance( ButtonPosition, inputPos ) / ( ( buttonTransform.sizeDelta.x * Quickbar.ParentCanvas.scaleFactor ) * Quickbar.quickbarButtonInputRadius );
			
			// If the input distance is less than 0.5f (half of the button since the calculations are from center), then return true.
			if( Mathf.Abs( inputDistance ) <= 0.5f )
				return true;

			// Else return false.
			return false;
		}

		/// <summary>
		/// [Internal] Resets the cooldown variables.
		/// </summary>
		public void ResetCooldown ()
		{
			// If the button is not interactable, then reset it back to true so the player can use this button again.
			if( !Interactable )
				Interactable = true;

			// If the cooldown image is assigned, then reset the fill amount.
			if( cooldownImage != null )
				cooldownImage.fillAmount = 0.0f;

			// If the cooldown text is assigned, then reset it.
			if( cooldownText != null )
				cooldownText.text = "";
		}

		/// <summary>
		/// [Internal] Called when the input is pressed down.
		/// </summary>
		public void OnInputDown ()
		{
			// Scale the button for visual feedback.
			buttonTransform.localScale = Vector3.one * Quickbar.inputActiveScale;
		}

		/// <summary>
		/// [Internal] Called when the input is released or canceled.
		/// </summary>
		public void OnInputUp ()
		{
			// Reset the scale to one for visual feedback that the button is not being interacted with.
			buttonTransform.localScale = Vector3.one;
		}

		/// <summary>
		/// [Internal] Called when the button has been successfully interacted with.
		/// </summary>
		public void OnInteract ()
		{
			// If this button is not interactable, then return;
			if( !Interactable )
				return;

			// Call the OnButtonInteract if it has subscribers.
			if( OnButtonInteract != null )
				OnButtonInteract();

			// Call the OnButtonInteractWithId if it has subscribers.
			if( OnButtonInteractWithId != null )
				OnButtonInteractWithId( id );

			// Call the OnButtonInteractWithKey if it has subscribers.
			if( OnButtonInteractWithKey != null )
				OnButtonInteractWithKey( key );

			// Call the OnButtonInteract on the quickbar if it has subscribers.
			if( Quickbar.OnButtonInteract != null )
				Quickbar.OnButtonInteract.Invoke( ParentIndex, ButtonIndex );
		}
		
		/// <summary>
		/// [Internal] Registers the information to the quickbar button.
		/// </summary>
		/// <param name="ButtonCallback">The Callback function to call when interacted with.</param>
		/// <param name="buttonInfo">The information to apply to the button.</param>
		public void RegisterButtonInfo ( UltimateMobileQuickbarButtonInfo buttonInfo )
		{
			// Set Registered to true since we are assigning the information.
			Registered = true;

			// Assign the icon and color.
			buttonIcon.sprite = buttonInfo.icon;
			buttonIcon.color = Color.white;

			// Register the quickbar data.
			buttonInfo.RegisterQuickbarData( Quickbar, ParentIndex, ButtonIndex );

			// Register the id and key values.
			id = buttonInfo.id;
			key = buttonInfo.key;
		}
		
		/// <summary>
		/// [Internal] Assigns needed information to the button to allow for calculations.
		/// </summary>
		/// <param name="quickbar">The Ultimate Mobile Quickbar component that this is a part of.</param>
		/// <param name="parentIndex">The parent index of this button.</param>
		/// <param name="buttonIndex">This button index.</param>
		public void RegisterToQuickbarSet ( UltimateMobileQuickbar quickbar, int parentIndex, int buttonIndex )
		{
			// If the parent index is different for the index that was stored before...
			if( parentIndex != ParentIndex )
			{
				// Notify any subscribers to the OnChangeParentIndex callback that the parent index has changed.
				if( OnChangeParentIndex != null )
					OnChangeParentIndex( ParentIndex, parentIndex );
			}

			// Store the provided variables and set the initial information.
			Quickbar = quickbar;
			ParentIndex = parentIndex;
			ButtonIndex = buttonIndex;
			Interactable = true;
			
			// If the button icon is assigned...
			if( buttonIcon != null )
			{
				// If the sprite of the icon is assigned, then set the color to white.
				if( buttonIcon.sprite != null )
					buttonIcon.color = Color.white;
				// Else set the color to clear so that it is not visible.
				else
					buttonIcon.color = Color.clear;
			}
		}

		/// <summary>
		/// [Internal] Returns the result of the input heading towards the target.
		/// </summary>
		public bool InputHeadingToButton ( Vector2 input, bool checkNextButton )
		{
			// If the current button index was not stored when the input was down, then return false.
			if( Quickbar.CurrentButtonIndexOnDown < 0 )
				return false;
			
			// Set the target as either the next button position or the previous, depending on the parameter.
			Vector2 target = checkNextButton ? nextButtonPosition : previousButtonPosition;

			// Configure the heading to the target button position.
			Vector2 targetButtonHeading = target - thisButtonPosition;

			// Divide the heading by the heading magnitude. This will convert the values into easier values to work with. (0.0f - 1.0f)
			targetButtonHeading = targetButtonHeading / targetButtonHeading.magnitude;
			
			// Configure the input heading direction.
			Vector2 inputHeading = input - Quickbar.inputDownPosition;

			// Divide the input heading by the heading magnitude. This will convert the values into easier values to work with. (0.0f - 1.0f)
			inputHeading = inputHeading / inputHeading.magnitude;

			// Configure the input heading Dot product.
			float targetButtonInputDot = Vector2.Dot( targetButtonHeading, inputHeading );

			// If the input heading Dot is within the threshold, then return true.
			if( targetButtonInputDot > Quickbar.swipeHeadingThreshold )
				return true;

			// Else return false.
			return false;
		}
	}
	[Serializable]
	public class QuickbarParent
	{
		public UltimateMobileQuickbar quickbar;
		public RectTransform transform;
		public CanvasGroup canvasGroup;
		public RectTransform setDisplayTransform;
		public Image setDisplayImage;
		public List<QuickbarButton> QuickbarButtons = new List<QuickbarButton>();

		/// <summary>
		/// [INTERNAL] Enables this set display visually.
		/// </summary>
		public void QuickbarSetSelected ()
		{
			if( quickbar == null || !quickbar.useSetDisplay )
				return;

			setDisplayImage.color = quickbar.setDisplaySelectedColor;
			setDisplayTransform.localScale = Vector3.one;
		}

		/// <summary>
		/// [INTERNAL] Disables this set display visually.
		/// </summary>
		public void QuickbarSetDeselected ()
		{
			if( quickbar == null || !quickbar.useSetDisplay )
				return;

			setDisplayImage.color = quickbar.setDisplayDefaultColor;
			setDisplayTransform.localScale = Vector3.one * quickbar.setDisplayDefaultScaleMultiplier;
		}

		/// <summary>
		/// [INTERNAL] Deletes this parent set display.
		/// </summary>
		public void DeleteThisParent ()
		{
			if( quickbar == null )
				return;

			Destroy( setDisplayTransform.gameObject );
			Destroy( transform.gameObject );
			quickbar.QuickbarParents.Remove( this );
		}
	}
	public List<QuickbarParent> QuickbarParents = new List<QuickbarParent>();
	public RectTransform setDisplayParentTransform;

	// ------------------------------------ //
	//           SCRIPT REFERENCE           //
	// ------------------------------------ //
	static Dictionary<string, UltimateMobileQuickbar> UltimateMobileQuickbars = new Dictionary<string, UltimateMobileQuickbar>();
	public string quickbarName = string.Empty;
	// Action Subscriptions //
	/// <summary>
	/// This callback will be called when a button has been found. The returned integer will be the index of the button.
	/// </summary>
	public event Action<int, int> OnButtonFound;
	/// <summary>
	/// This callback will be called when a button has been interacted with.
	/// </summary>
	public event Action<int, int> OnButtonInteract;
	/// <summary>
	/// This callback will be called when the quickbar has been enabled.
	/// </summary>
	public event Action OnQuickbarEnabled;
	/// <summary>
	/// This callback will be called when the quickbar has been disabled.
	/// </summary>
	public event Action OnQuickbarDisabled;
	/// <summary>
	/// This callback will be called when the quickbar's positioning has been updated.
	/// </summary>
	public event Action OnUpdateQuickbarPositioning;
	/// <summary>
	/// This callback is invoked when the quickbar transitions to another quickbar set.
	/// </summary>
	public event Action OnTransitionQuickbar;
	/// <summary>
	/// This action is invoked when a new quickbar set is created.
	/// </summary>
	public event Action OnCreateNewQuickbar;


	void Awake ()
	{
		// Loop through each quickbar parent...
		for( int i = 0; i < QuickbarParents.Count; i++ )
		{
			// Loop through each button in this quickbar parent...
			for( int n = 0; n < QuickbarParents[ i ].QuickbarButtons.Count; n++ )
			{
				// Do the button setup.
				QuickbarParents[ i ].QuickbarButtons[ n ].RegisterToQuickbarSet( this, i, n );

				// If the button isn't registered, then clear it on start.
				if( Application.isPlaying && !QuickbarParents[ i ].QuickbarButtons[ n ].Registered )
					QuickbarParents[ i ].QuickbarButtons[ n ].ClearButtonInformation();
			}
		}

		// If the game is not running, then return.
		if( !Application.isPlaying )
			return;

		// If the name is assigned...
		if( quickbarName != string.Empty )
		{
			// Check to see if the dictionary already contains this name, and if so, remove the current one.
			if( UltimateMobileQuickbars.ContainsKey( quickbarName ) )
				UltimateMobileQuickbars.Remove( quickbarName );

			// Register this into the dictionary.
			UltimateMobileQuickbars.Add( quickbarName, this );
		}
	}

	void Start ()
	{
		// Reset the indexes.
		CurrentButtonIndex = -10;
		CurrentButtonIndexOnDown = -10;
		CurrentParentIndex = 0;
		interactPointerId = -10;

		// Configure the transition speed.
		transitionSpeed = 1.0f / transitionDuration;

		// Update the positioning.
		UpdateQuickbarPositioning();

		// Set the QuickbarActive reference to true.
		QuickbarActive = true;
		
		// Then try to get the parent canvas component.
		UpdateParentCanvas();

		// If it is null, then log a error and return.
		if( ParentCanvas == null )
		{
			if( Application.isPlaying )
			{
				Debug.LogError( "Ultimate Mobile Quickbar\nThis component is not with a Canvas object. Disabling this component to avoid any errors." );
				enabled = false;
			}
			return;
		}
	}

	void Update ()
	{
		// The button will be updated constantly when the game is not being run.
		if( !Application.isPlaying )
		{
			UpdateQuickbarPositioning();
			return;
		}

		// If there are touches on the screen...
		if( Input.touchCount > 0 )
		{
			// Loop through each finger on the screen...
			for( int fingerId = 0; fingerId < Input.touchCount; fingerId++ )
			{
				// If a finger id has been stored, and this finger id is not the same as the stored finger id, then continue.
				if( interactPointerId >= 0 && interactPointerId != Input.GetTouch( fingerId ).fingerId )
					continue;
				
				// Process the touch input.
				ProcessInput( new Vector2( Input.GetTouch( fingerId ).position.x, Input.GetTouch( fingerId ).position.y ), Input.GetTouch( fingerId ).phase == TouchPhase.Began, Input.GetTouch( fingerId ).phase == TouchPhase.Ended, fingerId );
			}
		}
		// Else reset the stored pointer id.
		else
			interactPointerId = -10;

		#if UNITY_EDITOR
		if( Input.touchCount == 0 )
		{
			// Process the mouse input.
			ProcessInput( Input.mousePosition, Input.GetMouseButtonDown( 0 ), Input.GetMouseButtonUp( 0 ), 1 );
		}
		#endif

		// Check for the relative transform to have changed position/size.
		CheckForRelativeTransformChange();
	}
	
	/// <summary>
	///  [Internal] Processes the provided input to the quickbar buttons.
	/// </summary>
	void ProcessInput ( Vector2 input, bool inputDown, bool inputUp, int pointerId )
	{
		// If the quickbar is cleared out or it is not active, then just return.
		if( QuickbarParents.Count == 0 || !QuickbarActive )
			return;
		
		// Loop through each button in the current parent.
		for( int i = 0; i < QuickbarParents[ CurrentParentIndex ].QuickbarButtons.Count; i++ )
		{
			// If the input is within range of the button...
			if( QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ i ].IsInRange( input ) )
			{
				// If the currently selected button is different or if there was not one selected before...
				if( CurrentButtonIndex != i )
				{
					// If the index was actually assigned, and it is within range...
					if( CurrentButtonIndex >= 0 && CurrentButtonIndex < QuickbarParents[ CurrentParentIndex ].QuickbarButtons.Count )
					{
						// Check for a transition since the input has changed buttons.
						CheckForTransition( input );

						// This means that there was one of the buttons selected before this. Notify the button.
						QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ CurrentButtonIndex ].OnInputUp();

						// Reset the stored button index when the input was caught down.
						CurrentButtonIndexOnDown = -10;
					}

					// Invoke callback since a button has been found.
					if( OnButtonFound != null )
						OnButtonFound( CurrentParentIndex, i );
				}

				// Store this index.
				CurrentButtonIndex = i;

				// If the input is down...
				if( inputDown )
				{
					// Store this index as down.
					CurrentButtonIndexOnDown = i;

					// Store the input position since the input is down.
					inputDownPosition = input;	

					// Store the pointer id to check if it's the same when the input is released.
					interactPointerId = pointerId;

					// If this button is interactable...
					if( QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ i ].Interactable )
					{
						// Call the OnInputDown of this button.
						QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ i ].OnInputDown();

						// If the user wants to invoke the callbacks when the button is pressed down, then call the OnInteract function of this button.
						if( actionInvoke == ActionInvoke.OnButtonDown )
							QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ i ].OnInteract();
					}
				}
				// Else if the input is up...
				else if( inputUp )
				{
					// If this button is interactable...
					if( QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ i ].Interactable )
					{
						// Call the OnInputUp since the input was released.
						QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ i ].OnInputUp();

						// If the index that was stored on down is the same as this index, and the user wants to invoke the callbacks on release...
						if( CurrentButtonIndexOnDown == CurrentButtonIndex && actionInvoke == ActionInvoke.OnButtonUp )
						{
							// Reset the stored input information here just in case the user causes an error from the OnInteract callback.
							inputDownPosition = Vector2.zero;
							CurrentButtonIndex = -10;
							CurrentButtonIndexOnDown = -10;
							interactPointerId = -10;

							// Call the OnInteract callback.
							QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ i ].OnInteract();
						}
					}
					
					// Reset the stored input information.
					inputDownPosition = Vector2.zero;
					CurrentButtonIndex = -10;
					CurrentButtonIndexOnDown = -10;
					interactPointerId = -10;
				}

				// Break the loop.
				break;
			}

			// If this loop has reached the end of the button list and no buttons have been found worthy...
			if( i == QuickbarParents[ CurrentParentIndex ].QuickbarButtons.Count - 1 )
			{
				// If the stored current button index is assigned and within range...
				if( CurrentButtonIndex >= 0 && CurrentButtonIndex < QuickbarParents[ CurrentParentIndex ].QuickbarButtons.Count )
				{
					// Call OnInputUp since there are no buttons in range.
					QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ CurrentButtonIndex ].OnInputUp();

					// Check for a transition since the input is released.
					CheckForTransition( input );
				}

				// Reset the stored input information.
				CurrentButtonIndex = -1;
				CurrentButtonIndexOnDown = -1;
				interactPointerId = -10;
			}
		}
	}

	// ORIGINAL FOR REFERENCE //
	//void ProcessInput ( Vector2 input, bool inputDown, bool inputUp, int pointerId )
	//{
	//	// If the quickbar is cleared out or it is not active, then just return.
	//	if( QuickbarParents.Count == 0 || !QuickbarActive )
	//		return;

	//	// Loop through each button in the current parent.
	//	for( int i = 0; i < QuickbarParents[ CurrentParentIndex ].QuickbarButtons.Count; i++ )
	//	{
	//		// If the input is within range of the button...
	//		if( QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ i ].IsInRange( input ) )
	//		{
	//			// If the currently selected button is different or if there was not one selected before...
	//			if( CurrentButtonIndex != i )
	//			{
	//				// If the index was actually assigned, and it is within range...
	//				if( CurrentButtonIndex >= 0 && CurrentButtonIndex < QuickbarParents[ CurrentParentIndex ].QuickbarButtons.Count )
	//				{
	//					// Check for a transition since the input has changed buttons.
	//					CheckForTransition( input );

	//					// This means that there was one of the buttons selected before this. Notify the button.
	//					QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ CurrentButtonIndex ].OnInputUp();

	//					// Reset the stored button index when the input was caught down.
	//					CurrentButtonIndexOnDown = -10;
	//				}

	//				// Invoke callback since a button has been found.
	//				if( OnButtonFound != null )
	//					OnButtonFound( CurrentParentIndex, i );
	//			}

	//			// Store this index.
	//			CurrentButtonIndex = i;

	//			// If the input is down...
	//			if( inputDown )
	//			{
	//				// Store this index as down.
	//				CurrentButtonIndexOnDown = i;

	//				// Store the input position since the input is down.
	//				inputDownPosition = input;

	//				// Store the pointer id to check if it's the same when the input is released.
	//				interactPointerId = pointerId;

	//				// If this button is interactable...
	//				if( QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ i ].Interactable )
	//				{
	//					// Call the OnInputDown of this button.
	//					QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ i ].OnInputDown();

	//					// If the user wants to invoke the callbacks when the button is pressed down, then call the OnInteract function of this button.
	//					if( actionInvoke == ActionInvoke.OnButtonDown )
	//						QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ i ].OnInteract();
	//				}
	//			}
	//			// Else if the input is up...
	//			else if( inputUp )
	//			{
	//				// If this button is interactable...
	//				if( QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ i ].Interactable )
	//				{
	//					// Call the OnInputUp since the input was released.
	//					QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ i ].OnInputUp();

	//					// If the index that was stored on down is the same as this index, and the user wants to invoke the callbacks on release...
	//					if( CurrentButtonIndexOnDown == CurrentButtonIndex && actionInvoke == ActionInvoke.OnButtonUp )
	//					{
	//						// Reset the stored input information here just in case the user causes an error from the OnInteract callback.
	//						inputDownPosition = Vector2.zero;
	//						CurrentButtonIndex = -10;
	//						CurrentButtonIndexOnDown = -10;
	//						interactPointerId = -10;

	//						// Call the OnInteract callback.
	//						QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ i ].OnInteract();
	//					}
	//				}

	//				// Reset the stored input information.
	//				inputDownPosition = Vector2.zero;
	//				CurrentButtonIndex = -10;
	//				CurrentButtonIndexOnDown = -10;
	//				interactPointerId = -10;
	//			}

	//			// Break the loop.
	//			break;
	//		}

	//		// If this loop has reached the end of the button list and no buttons have been found worthy...
	//		if( i == QuickbarParents[ CurrentParentIndex ].QuickbarButtons.Count - 1 )
	//		{
	//			// If the stored current button index is assigned and within range...
	//			if( CurrentButtonIndex >= 0 && CurrentButtonIndex < QuickbarParents[ CurrentParentIndex ].QuickbarButtons.Count )
	//			{
	//				// Call OnInputUp since there are no buttons in range.
	//				QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ CurrentButtonIndex ].OnInputUp();

	//				// Check for a transition since the input is released.
	//				CheckForTransition( input );
	//			}

	//			// Reset the stored input information.
	//			CurrentButtonIndex = -1;
	//			CurrentButtonIndexOnDown = -1;
	//			interactPointerId = -10;
	//		}
	//	}
	//}

	/// <summary>
	/// Checks for the input being in the direction of a transition.
	/// </summary>
	void CheckForTransition ( Vector2 input )
	{
		// If the quickbar is currently transitioning, or if the swipe transition option is disabled, then just return.
		if( Transitioning || swipeTransition == SwipeTransition.Disabled )
			return;

		// If the current button was stored, and there are more than one parent quickbar...
		if( CurrentButtonIndexOnDown >= 0 && QuickbarParents.Count > 1 )
		{
			// Configure the distance of the swipe.
			float distance = Vector2.Distance( inputDownPosition, input ) / ButtonSize;

			// If the distance is greater than the swipe modifier set by the user...
			if( distance > swipeDistanceModifier )
			{
				// If the input is heading to the next button...
				if( QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ CurrentButtonIndexOnDown ].InputHeadingToButton( input, swipeTransition == SwipeTransition.Clockwise ) )
				{
					// Configure the next parent index.
					int nextParentIndex = CurrentParentIndex < ( QuickbarParents.Count - 1 ) ? CurrentParentIndex + 1 : 0;

					// If the transition duration is greater than zero, then the user wants to transition the quickbar over time, so start the coroutine.
					if( transitionDuration > 0 )
						StartCoroutine( TransitionQuickbar( QuickbarParents[ CurrentParentIndex ], QuickbarParents[ nextParentIndex ], swipeTransition == SwipeTransition.Clockwise ) );
					// Else just transition the menu instantly.
					else
						TransitionInstant( QuickbarParents[ CurrentParentIndex ], QuickbarParents[ nextParentIndex ] );

					// Store the new current parent index.
					CurrentParentIndex = nextParentIndex;
				}
				// Else if the input is heading to the previous button...
				else if( QuickbarParents[ CurrentParentIndex ].QuickbarButtons[ CurrentButtonIndexOnDown ].InputHeadingToButton( input, swipeTransition == SwipeTransition.CounterClockwise ) )
				{
					// Configure the next parent index.
					int nextParentIndex = CurrentParentIndex > 0 ? CurrentParentIndex - 1 : ( QuickbarParents.Count - 1 );

					// If the transition duration is greater than zero, then the user wants to transition the quickbar over time, so start the coroutine.
					if( transitionDuration > 0 )
						StartCoroutine( TransitionQuickbar( QuickbarParents[ CurrentParentIndex ], QuickbarParents[ nextParentIndex ], swipeTransition == SwipeTransition.CounterClockwise ) );
					// Else just transition the menu instantly.
					else
						TransitionInstant( QuickbarParents[ CurrentParentIndex ], QuickbarParents[ nextParentIndex ] );

					// Store the new current parent index.
					CurrentParentIndex = nextParentIndex;
				}
			}
		}
	}

	/// <summary>
	/// Transitions the current parent and the target parent over time.
	/// </summary>
	IEnumerator TransitionQuickbar ( QuickbarParent currentParent, QuickbarParent targetParent, bool clockwise )
	{
		// Set Transitioning to true so that the player cannot try to transition while it is currently transitioning.
		Transitioning = true;

		// Update the parent set display images.
		currentParent.QuickbarSetDeselected();
		targetParent.QuickbarSetSelected();

		// Set the target to active.
		targetParent.transform.gameObject.SetActive( true );

		// For loop over time according to the transition speed.
		for( float t = 0.0f; t < 1.0f; t += Time.deltaTime * transitionSpeed )
		{
			// Smoothly transition the rotation from the current rotation to the targeted rotation.
			currentParent.transform.localRotation = Quaternion.Slerp( Quaternion.identity, Quaternion.Euler( 0, 0, clockwise ? 180 : -180 ), t );
			targetParent.transform.localRotation = Quaternion.Slerp( Quaternion.Euler( 0, 0, clockwise ? -180 : 180 ), Quaternion.identity, t );

			// Smoothly lerp the alpha of the canvas group.
			currentParent.canvasGroup.alpha = Mathf.Lerp( 1.0f, 0.0f, t );
			targetParent.canvasGroup.alpha = Mathf.Lerp( 0.0f, 1.0f, t );

			// Yield a frame.
			yield return null;
		}

		// Finalize the rotation of the parent transforms.
		currentParent.transform.localRotation = Quaternion.Euler( 0, 0, 180 );
		targetParent.transform.localRotation = Quaternion.identity;

		// Finalize the alpha of the parent canvas groups.
		currentParent.canvasGroup.alpha = 0.0f;
		targetParent.canvasGroup.alpha = 1.0f;

		// Set the current parent to inactive since the transition is finished.
		currentParent.transform.gameObject.SetActive( false );

		// Notify any subscribers to this event that the quickbar has transitioned.
		if( OnTransitionQuickbar != null )
			OnTransitionQuickbar();

		// Set Transitioning to false so that the player can transition the menu again.
		Transitioning = false;
	}

	/// <summary>
	/// Transitions the quickbar sets instantly.
	/// </summary>
	/// <param name="currentParent">The currently selected parent quickbar.</param>
	/// <param name="targetParent">The targeted parent quickbar.</param>
	void TransitionInstant ( QuickbarParent currentParent, QuickbarParent targetParent )
	{
		// De-select the current parent.
		currentParent.QuickbarSetDeselected();

		// Set the target parent active.
		targetParent.transform.gameObject.SetActive( true );

		// Select the target parent.
		targetParent.QuickbarSetSelected();

		// Update the rotation of the parents to reflect the change.
		currentParent.transform.localRotation = Quaternion.Euler( 0, 0, 180 );
		targetParent.transform.localRotation = Quaternion.identity;

		// Update the alpha of the parents to reflect the current state.
		currentParent.canvasGroup.alpha = 0.0f;
		targetParent.canvasGroup.alpha = 1.0f;

		// Set the current parent to inactive since the transition is complete.
		currentParent.transform.gameObject.SetActive( false );

		// Notify any subscribers to this event that the quickbar has transitioned.
		if( OnTransitionQuickbar != null )
			OnTransitionQuickbar();
	}

	/// <summary>
	/// Checks the stored values of the relative transform against the current information to see if there is a difference.
	/// </summary>
	void CheckForRelativeTransformChange ()
	{
		// If the stored size or position is different that the current, then update the positioning.
		if( relativeTransformSize != relativeTransform.sizeDelta || relativeTransformPosition != ( Vector2 )relativeTransform.position )
			UpdateQuickbarPositioning();
	}

	/// <summary>
	/// Creates a new quickbar set with buttons.
	/// </summary>
	void CreateNewQuickbar ()
	{
		// Create a new base game object and add a RectTransform component.
		GameObject newGameObject = new GameObject();
		newGameObject.AddComponent<RectTransform>();

		// Store the parents count as the target parent index since the array hasn't been added to yet.
		int parentIndex = QuickbarParents.Count;

		// Instantiate a new parent gameobject.
		GameObject parentGameObject = Instantiate( newGameObject, Vector3.zero, Quaternion.identity );

		// Add a canvas group and change the options of the canvas group.
		CanvasGroup cg = parentGameObject.AddComponent<CanvasGroup>();
		cg.interactable = false;
		cg.blocksRaycasts = false;
		cg.ignoreParentGroups = false;
		cg.alpha = 0.0f;

		// Name the object and set the parent.
		parentGameObject.name = "Quickbar Set " + parentIndex.ToString( "00" );
		parentGameObject.transform.SetParent( transform );

		// Store the rect transform of this parent and adjust it's position settings.
		RectTransform parentTrans = parentGameObject.GetComponent<RectTransform>();
		parentTrans.anchorMin = new Vector2( 0.0f, 0.0f );
		parentTrans.anchorMax = new Vector2( 1.0f, 1.0f );
		parentTrans.offsetMin = Vector2.zero;
		parentTrans.offsetMax = Vector2.zero;
		parentTrans.localPosition = Vector3.zero;
		parentTrans.localScale = Vector3.one;

		// Now modify the base game object in preparation for creating the other objects. These will be visible so add renderer and image components.
		newGameObject.AddComponent<CanvasRenderer>();
		newGameObject.AddComponent<Image>();

		// Add a new parent to the parents list and increase quickbarCount.
		QuickbarParents.Add( new QuickbarParent() );
		quickbarCount++;

		// Store the quickbar, RectTransform, and CanvasGroup into the parent class variables.
		QuickbarParents[ parentIndex ].quickbar = this;
		QuickbarParents[ parentIndex ].transform = parentTrans;
		QuickbarParents[ parentIndex ].canvasGroup = cg;

		// If the user wants to display the sets...
		if( useSetDisplay )
		{
			// Create the set display game object, set the parent to the set display holder, and set the name of the object.
			GameObject setDisplayObject = Instantiate( newGameObject, Vector3.zero, Quaternion.identity );
			setDisplayObject.transform.SetParent( setDisplayParentTransform.transform );
			setDisplayObject.gameObject.name = "Set Display Image " + parentIndex.ToString( "00" );

			// Store the set display image component and set the sprite and color.
			Image setDisplayImage = setDisplayObject.GetComponent<Image>();
			setDisplayImage.sprite = setDisplaySprite;
			setDisplayImage.color = setDisplayDefaultColor;
			setDisplayImage.raycastTarget = false;

			// Store this set display transform and set the scale.
			RectTransform parentSetDisplayTrans = setDisplayObject.GetComponent<RectTransform>();
			parentSetDisplayTrans.localPosition = Vector3.zero;
			parentSetDisplayTrans.localScale = Vector3.one * setDisplayDefaultScaleMultiplier;

			// Assign the parent's setDisplayTransform and setDisplayImage variables for reference.
			QuickbarParents[ parentIndex ].setDisplayTransform = parentSetDisplayTrans;
			QuickbarParents[ parentIndex ].setDisplayImage = setDisplayImage;
		}

		// Clear the new parent's QuickbarButtons list.
		QuickbarParents[ parentIndex ].QuickbarButtons.Clear();

		for( int i = 0; i < buttonPerQuickbar; i++ )
		{
			// -------< QUICKBAR BUTTON >------- //
			// Create the button game object, set the parent, and change the name.
			GameObject baseButton = Instantiate( newGameObject, Vector3.zero, Quaternion.identity );
			baseButton.transform.SetParent( QuickbarParents[ parentIndex ].transform );
			baseButton.gameObject.name = "Quickbar Button " + i.ToString( "00" );

			// Store the RectTransform component and modify it for positioning in the UpdateQuickbarPositioning function.
			RectTransform baseButtonTrans = baseButton.GetComponent<RectTransform>();
			baseButtonTrans.anchorMin = new Vector2( 0.5f, 0.5f );
			baseButtonTrans.anchorMax = new Vector2( 0.5f, 0.5f );
			baseButtonTrans.pivot = new Vector2( 0.5f, 0.5f );
			baseButtonTrans.localPosition = Vector3.zero;
			baseButtonTrans.localScale = Vector3.one;

			// Store the image component and update the sprite and color.
			Image baseButtonImage = baseButton.GetComponent<Image>();
			baseButtonImage.sprite = buttonSprite;
			baseButtonImage.color = buttonColor;
			baseButtonImage.raycastTarget = false;

			// -------< ICON >------- //
			// Create the button icon game object. Then set the parent as the baseButton's transform, and change the name.
			GameObject buttonIcon = Instantiate( newGameObject, Vector3.zero, Quaternion.identity );
			buttonIcon.transform.SetParent( baseButtonTrans );
			buttonIcon.gameObject.name = "Button Icon " + i.ToString( "00" );

			// Store the RectTransform component and set it to fill up the parent transform.
			RectTransform buttonIconTrans = buttonIcon.GetComponent<RectTransform>();
			buttonIconTrans.anchorMin = new Vector2( 0.0f, 0.0f );
			buttonIconTrans.anchorMax = new Vector2( 1.0f, 1.0f );
			buttonIconTrans.offsetMin = Vector2.zero;
			buttonIconTrans.offsetMax = Vector2.zero;
			buttonIconTrans.localPosition = Vector3.zero;
			buttonIconTrans.localScale = Vector3.one;

			// Store the buttonIcon image component and clear the sprite and update the color to clear.
			Image buttonIconImage = buttonIcon.GetComponent<Image>();
			buttonIconImage.sprite = null;
			buttonIconImage.color = Color.clear;
			buttonIconImage.raycastTarget = false;

			// -------< COOLDOWN >------- //
			// Create the cooldown game object, set the parent, and change the name.
			GameObject buttonCooldown = Instantiate( newGameObject, Vector3.zero, Quaternion.identity );
			buttonCooldown.transform.SetParent( baseButtonTrans );
			buttonCooldown.gameObject.name = "Cooldown Image " + i.ToString( "00" );

			// Store the cooldown Image component.
			Image buttonCooldownImage = buttonCooldown.GetComponent<Image>();
			buttonCooldownImage.color = cooldownColor;
			buttonCooldownImage.sprite = cooldownSprite;
			buttonCooldownImage.type = Image.Type.Filled;
			buttonCooldownImage.fillMethod = QuickbarParents[ 0 ].QuickbarButtons[ 0 ].cooldownImage.fillMethod;
			buttonCooldownImage.fillAmount = 0.0f;
			buttonCooldownImage.raycastTarget = false;

			// Store the cooldown transform.
			RectTransform buttonCooldownTrans = buttonCooldown.GetComponent<RectTransform>();
			buttonCooldownTrans.anchorMin = new Vector2( 0.0f, 0.0f );
			buttonCooldownTrans.anchorMax = new Vector2( 1.0f, 1.0f );
			buttonCooldownTrans.offsetMin = Vector2.zero;
			buttonCooldownTrans.offsetMax = Vector2.zero;
			buttonCooldownTrans.localPosition = Vector3.zero;
			buttonCooldownTrans.localScale = Vector3.one;

			// Add a new quickbar button to this parent, and store the created components into this child for reference later.
			QuickbarParents[ parentIndex ].QuickbarButtons.Add( new QuickbarButton() );
			QuickbarParents[ parentIndex ].QuickbarButtons[ i ].buttonTransform = baseButtonTrans;
			QuickbarParents[ parentIndex ].QuickbarButtons[ i ].cooldownImage = buttonCooldownImage;
			QuickbarParents[ parentIndex ].QuickbarButtons[ i ].buttonIcon = buttonIconImage;

			// If the user wants to show a cooldown text...
			if( useCooldownText )
			{
				// Create a new game object for the cooldown text, add a RectTransform and a CanvasRenderer component.
				GameObject newTextObject = new GameObject();
				newTextObject.AddComponent<RectTransform>();
				newTextObject.AddComponent<CanvasRenderer>();

				// Create the cooldown text object, set the parent and name.
				GameObject cooldownTextObject = Instantiate( newTextObject, Vector3.zero, Quaternion.identity );
				cooldownTextObject.transform.SetParent( QuickbarParents[ parentIndex ].QuickbarButtons[ i ].buttonTransform );
				cooldownTextObject.gameObject.name = "Cooldown Text " + i.ToString( "00" );

				RectTransform cooldownTextTrans = newTextObject.GetComponent<RectTransform>();
				cooldownTextTrans.localPosition = Vector3.zero;
				cooldownTextTrans.localScale = Vector3.one;

				// Store the text component and modify the settings.
				Text cooldownText = cooldownTextObject.AddComponent<Text>();
				cooldownText.text = "";
				cooldownText.alignment = TextAnchor.MiddleCenter;
				cooldownText.resizeTextForBestFit = true;
				cooldownText.resizeTextMinSize = 0;
				cooldownText.resizeTextMaxSize = 300;
				cooldownText.font = QuickbarParents[ 0 ].QuickbarButtons[ 0 ].cooldownText.font;
				cooldownText.color = textColor;
				cooldownText.raycastTarget = false;
				
				// If the user wants a text outline on the cooldown text...
				if( textOutline )
				{
					// Add a outline component and update the color.
					Outline textOutline = cooldownTextObject.AddComponent<Outline>();
					textOutline.effectColor = textOutlineColor;
				}

				// Store the created objects into the quickbar button for reference.
				QuickbarParents[ parentIndex ].QuickbarButtons[ i ].cooldownText = cooldownText;

				// Destroy the temporary text object that was created.
				Destroy( newTextObject );
			}
			
			// If the user wants to show item count text...
			if( useCountText )
			{
				// Create a new gameobject for the item count text.
				GameObject newTextObject = new GameObject();
				newTextObject.AddComponent<RectTransform>();
				newTextObject.AddComponent<CanvasRenderer>();

				// Create the new object and set parent.
				GameObject countTextObject = Instantiate( newTextObject, Vector3.zero, Quaternion.identity );
				countTextObject.transform.SetParent( QuickbarParents[ parentIndex ].QuickbarButtons[ i ].buttonTransform );
				countTextObject.gameObject.name = "Count Text " + i.ToString( "00" );

				RectTransform countTextTrans = newTextObject.GetComponent<RectTransform>();
				countTextTrans.localPosition = Vector3.zero;
				countTextTrans.localScale = Vector3.one;

				// Add a text component and modify the values.
				Text textComponent = countTextObject.AddComponent<Text>();
				textComponent.text = "";
				textComponent.alignment = TextAnchor.MiddleCenter;
				textComponent.resizeTextForBestFit = true;
				textComponent.resizeTextMinSize = 0;
				textComponent.resizeTextMaxSize = 300;
				textComponent.font = QuickbarParents[ 0 ].QuickbarButtons[ 0 ].countText.font;
				textComponent.color = textColor;
				textComponent.raycastTarget = false;

				// Store the text component.
				QuickbarParents[ parentIndex ].QuickbarButtons[ i ].countText = textComponent;

				// If the user wants to use an outline on the text, then add the component and apply the outline color.
				if( textOutline )
				{
					Outline textOutline = countTextObject.AddComponent<Outline>();
					textOutline.effectColor = textOutlineColor;
				}

				// Destroy the temporary created object.
				Destroy( newTextObject );

				// If the user wants to display a count text background.
				if( countTextBackgroundSprite != null )
				{
					// Create a new game object for the count text background.
					GameObject countTextBackground = Instantiate( newGameObject, Vector3.zero, Quaternion.identity );
					countTextBackground.transform.SetParent( QuickbarParents[ parentIndex ].QuickbarButtons[ i ].buttonTransform );
					countTextBackground.transform.SetAsLastSibling();
					countTextBackground.gameObject.name = "Count Text Background " + i.ToString( "00" );

					// Store the button overlay RectTransform and modify it.
					RectTransform countTextBackgroundTrans = countTextBackground.GetComponent<RectTransform>();
					countTextBackgroundTrans.anchorMin = new Vector2( 0.0f, 0.0f );
					countTextBackgroundTrans.anchorMax = new Vector2( 1.0f, 1.0f );
					countTextBackgroundTrans.offsetMin = Vector2.zero;
					countTextBackgroundTrans.offsetMax = Vector2.zero;
					countTextBackgroundTrans.localPosition = Vector3.zero;
					countTextBackgroundTrans.localScale = Vector3.one;

					// Store the overlay image component and apply the sprite and color.
					Image countTextBackgroundImage = countTextBackground.GetComponent<Image>();
					countTextBackgroundImage.color = buttonColor;
					countTextBackgroundImage.sprite = countTextBackgroundSprite;
					countTextBackgroundImage.raycastTarget = false;

					// Store this image to the quickbar button for reference.
					QuickbarParents[ parentIndex ].QuickbarButtons[ i ].countTextBackground = countTextBackgroundImage;

					// Set the background as inactive to start with.
					countTextBackground.SetActive( false );
				}
			}

			// If the user wants to use the button overlay...
			if( useButtonOverlay )
			{
				// Create a new game object for the button overlay.
				GameObject buttonOverlayObject = Instantiate( newGameObject, Vector3.zero, Quaternion.identity );
				buttonOverlayObject.transform.SetParent( QuickbarParents[ parentIndex ].QuickbarButtons[ i ].buttonTransform );
				buttonOverlayObject.transform.SetAsLastSibling();
				buttonOverlayObject.gameObject.name = "Button Overlay " + i.ToString( "00" );

				// Store the button overlay RectTransform and modify it.
				RectTransform buttonOverlayTrans = buttonOverlayObject.GetComponent<RectTransform>();
				buttonOverlayTrans.anchorMin = new Vector2( 0.0f, 0.0f );
				buttonOverlayTrans.anchorMax = new Vector2( 1.0f, 1.0f );
				buttonOverlayTrans.offsetMin = Vector2.zero;
				buttonOverlayTrans.offsetMax = Vector2.zero;
				buttonOverlayTrans.localPosition = Vector3.zero;
				buttonOverlayTrans.localScale = Vector3.one;

				// Store the overlay image component and apply the sprite and color.
				Image buttonOverlayImage = buttonOverlayObject.GetComponent<Image>();
				buttonOverlayImage.color = buttonOverlayColor;
				buttonOverlayImage.sprite = buttonOverlaySprite;
				buttonOverlayImage.raycastTarget = false;

				// Store this image to the quickbar button for reference.
				QuickbarParents[ parentIndex ].QuickbarButtons[ i ].buttonOverlayImage = buttonOverlayImage;
			}

			// If the user wants to use a mask for the button...
			if( useIconMask )
			{
				// Create the mask object.
				GameObject iconMaskObject = Instantiate( newGameObject, Vector3.zero, Quaternion.identity );
				iconMaskObject.transform.SetParent( QuickbarParents[ parentIndex ].QuickbarButtons[ i ].buttonTransform );
				iconMaskObject.transform.SetSiblingIndex( QuickbarParents[ 0 ].QuickbarButtons[ 0 ].buttonIconMask.transform.GetSiblingIndex() );
				iconMaskObject.gameObject.name = "Icon Mask " + i.ToString( "00" );

				// Store the RectTransform component and modify it.
				RectTransform iconMaskTrans = iconMaskObject.GetComponent<RectTransform>();
				iconMaskTrans.anchorMin = new Vector2( 0.0f, 0.0f );
				iconMaskTrans.anchorMax = new Vector2( 1.0f, 1.0f );
				iconMaskTrans.offsetMin = Vector2.zero;
				iconMaskTrans.offsetMax = Vector2.zero;
				iconMaskTrans.localPosition = Vector3.zero;
				iconMaskTrans.localScale = Vector3.one;

				// Store the image component and apply the sprite.
				Image iconMaskImage = iconMaskObject.GetComponent<Image>();
				iconMaskImage.sprite = iconMaskSprite;
				iconMaskImage.raycastTarget = false;

				// Add a mask component and disable showMaskGraphic.
				Mask iconMaskComponent = iconMaskObject.AddComponent<Mask>();
				iconMaskComponent.showMaskGraphic = false;

				// Store the mask image to the quickbar button.
				QuickbarParents[ parentIndex ].QuickbarButtons[ i ].buttonIconMask = iconMaskImage;

				// Set the parent of the icon to this mask transform.
				buttonIcon.transform.SetParent( iconMaskObject.transform );
			}
			// Else the user is not using a mask, so just set the sibling index to the same as the first index button.
			else
				buttonIcon.transform.SetSiblingIndex( QuickbarParents[ 0 ].QuickbarButtons[ 0 ].buttonIcon.transform.GetSiblingIndex() );

			// Set the sibling index to the same as the first index button.
			buttonCooldown.transform.SetSiblingIndex( QuickbarParents[ 0 ].QuickbarButtons[ 0 ].cooldownImage.transform.GetSiblingIndex() );

			// Set the sibling index to the same as the first index button.
			if( useCooldownText )
				QuickbarParents[ parentIndex ].QuickbarButtons[ i ].cooldownText.transform.SetSiblingIndex( QuickbarParents[ 0 ].QuickbarButtons[ 0 ].cooldownText.transform.GetSiblingIndex() );

			// Set the sibling index to the same as the first index button.
			if( useButtonOverlay )
				QuickbarParents[ parentIndex ].QuickbarButtons[ i ].buttonOverlayImage.transform.SetSiblingIndex( QuickbarParents[ 0 ].QuickbarButtons[ 0 ].buttonOverlayImage.transform.GetSiblingIndex() );

			// Set the sibling index to the same as the first index button.
			if( useCountText )
			{
				QuickbarParents[ parentIndex ].QuickbarButtons[ i ].countText.transform.SetSiblingIndex( QuickbarParents[ 0 ].QuickbarButtons[ 0 ].countText.transform.GetSiblingIndex() );

				// If the count text background is assigned, then set the sibling index.
				if( countTextBackgroundSprite != null )
					QuickbarParents[ parentIndex ].QuickbarButtons[ i ].countTextBackground.transform.SetSiblingIndex( QuickbarParents[ 0 ].QuickbarButtons[ 0 ].countTextBackground.transform.GetSiblingIndex() );
			}
		}

		// Update the quickbar's positioning because there is another quickbar.
		UpdateQuickbarPositioning();

		// Destroy the temporary game object.
		Destroy( newGameObject );

		// Notify any subscribers that a new quickbar set has been created.
		if( OnCreateNewQuickbar != null )
			OnCreateNewQuickbar();
	}

	/// <summary>
	/// Loops through each button to find the next available one. If no button is available, this function will create a new quickbar and return the first button in that quickbar.
	/// </summary>
	int[] FindNextAvailableQuickbarButton ()
	{
		// Loop through each parent.
		for( int i = 0; i < QuickbarParents.Count; i++ )
		{
			// Loop through each child in this parent.
			for( int n = 0; n < QuickbarParents[ i ].QuickbarButtons.Count; n++ )
			{
				// If the button in not currently registered to anything, then return these indexes.
				if( !QuickbarParents[ i ].QuickbarButtons[ n ].Registered )
					return new int[ 2 ] { i, n };
			}
		}

		// If we have reached this part of code without finding any available buttons, then create a new quickbar set.
		CreateNewQuickbar();

		// Return the first button of the new quickbar set.
		return new int[ 2 ] { QuickbarParents.Count - 1, 0 };
	}

	/// <summary>
	/// Confirms the existence of the quickbar button index.
	/// </summary>
	/// <param name="parentIndex">The targeted parent index.</param>
	/// <param name="buttonIndex">The targeted button index.</param>
	bool ConfirmQuickbarButtonIndex ( int parentIndex, int buttonIndex )
	{
		// If the index is greater than the parent list count, then inform the user and return false.
		if( parentIndex > QuickbarParents.Count - 1 || parentIndex < 0 )
		{
			Debug.LogWarning( "Ultimate Mobile Quickbar - The parent index is out of range for this quickbar." );
			return false;
		}

		// If the index is greater than the button list count, then inform the user and return false.
		if( buttonIndex > QuickbarParents[ parentIndex ].QuickbarButtons.Count - 1 || buttonIndex < 0 )
		{
			Debug.LogWarning( "Ultimate Mobile Quickbar - The button index is out of range for this quickbar." );
			return false;
		}

		return true;
	}

	/// <summary>
	/// This function is called by Unity when the parent of this transform changes.
	/// </summary>
	void OnTransformParentChanged ()
	{
		UpdateParentCanvas();
	}

	/// <summary>
	/// Updates the parent canvas if it has changed.
	/// </summary>
	public void UpdateParentCanvas ()
	{
		// Store the parent of this object.
		Transform parent = transform.parent;

		// If the parent is null, then just return.
		if( parent == null )
			return;

		// While the parent is assigned...
		while( parent != null )
		{
			// If the parent object has a Canvas component, then assign the ParentCanvas and transform.
			if( parent.transform.GetComponent<Canvas>() )
			{
				ParentCanvas = parent.transform.GetComponent<Canvas>();
				canvasRectTrans = ParentCanvas.GetComponent<RectTransform>();
				return;
			}

			// If the parent does not have a canvas, then store it's parent to loop again.
			parent = parent.transform.parent;
		}
	}

	// -------------------------------------------------- < PUBLIC FUNCTIONS FOR THE USER > -------------------------------------------------- //
	/// <summary>
	/// Updates the positioning of the quickbar.
	/// </summary>
	public void UpdateQuickbarPositioning ()
	{
		// Try to get the parent canvas component.
		UpdateParentCanvas();

		// If it is null, then log a error and return.
		if( ParentCanvas == null )
		{
			if( Application.isPlaying )
				Debug.LogError( "Ultimate Mobile Quickbar\nThere is no parent canvas object. Please make sure that the Ultimate Mobile Quickbar is placed within a canvas." );

			return;
		}

		// If the base transform is null, then attempt to find it.
		if( baseTransform == null )
			baseTransform = GetComponent<RectTransform>();

		// Reset the baseTransform scale and rotation.
		baseTransform.localScale = Vector3.one;
		baseTransform.localRotation = Quaternion.identity;

		// If the relative transform is null return to avoid errors.
		if( relativeTransform == null )
			return;
		
		// If the canvas group is null, then attempt to find it also.
		if( canvasGroup == null )
			canvasGroup = GetComponent<CanvasGroup>();

		// Store the relative transform size and position so that if it changes after this, the quickbar will know to update its own positioning.
		relativeTransformSize = relativeTransform.sizeDelta;
		relativeTransformPosition = relativeTransform.position;

		// Store the calculated center position based off of the relative transform.
		Vector2 calculatedPosition = ( Vector2 )ParentCanvas.transform.InverseTransformPoint( relativeTransform.position ) - new Vector2( relativeTransform.sizeDelta.x * relativeTransform.pivot.x, relativeTransform.sizeDelta.y * relativeTransform.pivot.y ) + ( relativeTransform.sizeDelta / 2 );

		// Assign the position and size delta of the relative transform.
		baseTransform.localPosition = calculatedPosition;
		baseTransform.sizeDelta = relativeTransform.sizeDelta;

		// If there are no parents then return to avoid errors.
		if( QuickbarParents.Count == 0 || QuickbarParents[ 0 ].transform == null )
			return;

		// Configure the angle per button.
		float angle = overallAngle / buttonPerQuickbar;

		// Convert the angle into radians. Here we are applying the angle as negative since we want the buttons to go clockwise.
		float angleInRadians = ( centerAngle <= 0 ? -angle : angle ) * Mathf.Deg2Rad;

		// Calculate the start angle so that it is easier for the user to understand in the scene.
		float modStartAngle = 90 - ( centerAngle <= 0 ? -centerAngle + ( overallAngle / 2 ) : -centerAngle - ( overallAngle / 2 ) );

		// Store the button size so that it only needs to be calculated once.
		ButtonSize = ( ( relativeTransform.sizeDelta.x / 10 ) * buttonSize );

		// Loop through all of the parents.
		for( int i = 0; i < QuickbarParents.Count; i++ )
		{
			// If the quickbar parent is null, then break the loop to avoid errors.
			if( QuickbarParents[ i ].transform == null )
				break;

			// Force the rotation to zero before any calculations.
			QuickbarParents[ i ].transform.localRotation = Quaternion.identity;

			// Loop through each button inside this parent index.
			for( int n = 0; n < QuickbarParents[ i ].QuickbarButtons.Count; n++ )
			{
				if( QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform == null )
					break;

				// Assign the size of the button.
				QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform.sizeDelta = new Vector2( ButtonSize, ButtonSize );

				// Configure a new position for the button.
				Vector3 buttonPosition = Vector3.zero;

				// Calculate the position of the button according to the user options.
				buttonPosition.x -= ( Mathf.Cos( ( angleInRadians * n ) - ( modStartAngle * Mathf.Deg2Rad ) - ( -angleInRadians / 2 ) ) * ( relativeTransform.sizeDelta.x * buttonOrbitRadius ) );
				buttonPosition.y -= ( Mathf.Sin( ( angleInRadians * n ) - ( modStartAngle * Mathf.Deg2Rad ) - ( -angleInRadians / 2 ) ) * ( relativeTransform.sizeDelta.x * buttonOrbitRadius ) );

				// Apply the new position to the transform, a default scale of one, as well as a zero rotation.
				QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform.localPosition = buttonPosition;
				QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform.localScale = Vector3.one;
				QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform.localRotation = Quaternion.identity;

				// Call the button setup function.
				QuickbarParents[ i ].QuickbarButtons[ n ].RegisterToQuickbarSet( this, i, n );

				// If the icon is assigned, then apply the users scale modifier.
				if( QuickbarParents[ i ].QuickbarButtons[ n ].buttonIcon != null )
					QuickbarParents[ i ].QuickbarButtons[ n ].buttonIcon.GetComponent<RectTransform>().localScale = Vector3.one * iconScale;
				
				// If the cooldown text is assigned...
				if( QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText != null )
				{
					QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.rectTransform.localPosition = Vector3.zero;

					// Configure the anchors by the users options.
					QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.rectTransform.anchorMin = new Vector2( 0.0f, Mathf.Lerp( 0.5f, 0.0f, textAnchorMod ) );
					QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.rectTransform.anchorMax = new Vector2( 1.0f, ( 1.0f - Mathf.Lerp( 0.5f, 0.0f, textAnchorMod ) ) );

					// Zero the offset to make it take up the whole of the anchors.
					QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.rectTransform.offsetMin = Vector2.zero;
					QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.rectTransform.offsetMax = Vector2.zero;
				}

				// If the count text is assigned...
				if( QuickbarParents[ i ].QuickbarButtons[ n ].countText != null )
				{
					// Ensure that the scale of the text is 1.
					QuickbarParents[ i ].QuickbarButtons[ n ].countText.rectTransform.localScale = Vector3.one;

					// Configure a the position of the text by multiplying the button's size by -0.5 and 0.5.
					QuickbarParents[ i ].QuickbarButtons[ n ].countText.rectTransform.localPosition = QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform.sizeDelta * ( new Vector2( countTextPosX - 50, countTextPosY - 50 ) / 100 );
					
					// Configure the size of the text.
					QuickbarParents[ i ].QuickbarButtons[ n ].countText.rectTransform.sizeDelta = new Vector2( QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform.sizeDelta.x * ( countTextSize * 2 ), QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform.sizeDelta.y * countTextSize );
				}

				// Configure the position of the button on the left.
				Vector2 leftButtonPosition = Vector3.zero;
				leftButtonPosition.x -= ( Mathf.Cos( ( angleInRadians * ( n - 1 ) ) - ( modStartAngle * Mathf.Deg2Rad ) - ( -angleInRadians / 2 ) ) * ( relativeTransform.sizeDelta.x * buttonOrbitRadius ) );
				leftButtonPosition.y -= ( Mathf.Sin( ( angleInRadians * ( n - 1 ) ) - ( modStartAngle * Mathf.Deg2Rad ) - ( -angleInRadians / 2 ) ) * ( relativeTransform.sizeDelta.x * buttonOrbitRadius ) );

				// Configure the position of the button on the right.
				Vector2 rightButtonPosition = Vector3.zero;
				rightButtonPosition.x -= ( Mathf.Cos( ( angleInRadians * ( n + 1 ) ) - ( modStartAngle * Mathf.Deg2Rad ) - ( -angleInRadians / 2 ) ) * ( relativeTransform.sizeDelta.x * buttonOrbitRadius ) );
				rightButtonPosition.y -= ( Mathf.Sin( ( angleInRadians * ( n + 1 ) ) - ( modStartAngle * Mathf.Deg2Rad ) - ( -angleInRadians / 2 ) ) * ( relativeTransform.sizeDelta.x * buttonOrbitRadius ) );

				// Store the calculated button position for simplified calculations later.
				QuickbarParents[ i ].QuickbarButtons[ n ].thisButtonPosition = buttonPosition;

				// If the center angle is over to the left from center...
				if( centerAngle <= 0 )
				{
					// Store the previous button position as the left button, and the next button as the right.
					QuickbarParents[ i ].QuickbarButtons[ n ].previousButtonPosition = leftButtonPosition;
					QuickbarParents[ i ].QuickbarButtons[ n ].nextButtonPosition = rightButtonPosition;
				}
				// Else the center angle is to the right from center...
				else
				{
					// So store the next button as the left button, and the previous button as the right.
					QuickbarParents[ i ].QuickbarButtons[ n ].nextButtonPosition = leftButtonPosition;
					QuickbarParents[ i ].QuickbarButtons[ n ].previousButtonPosition = rightButtonPosition;
				}
			}

			// If the user wants to use a quickbar set display, and (if quickbar parents are populated OR if the application is not playing so that the set display will show up so that it can be edited)
			if( useSetDisplay && ( QuickbarParents.Count > 1 || !Application.isPlaying ) && setDisplayParentTransform != null )
			{
				// If the set display parent is not active in the scene, then set it to active.
				if( !setDisplayParentTransform.gameObject.activeInHierarchy )
					setDisplayParentTransform.gameObject.SetActive( true );

				// Configure half the total angle that will be needed for all the set display objects.
				float halfTotalAngle = ( setDisplayAnglePer * QuickbarParents.Count ) / 2;

				// Configure the starting angle of the set display according to how many will be shown.
				float setDisplayModStartAngle = setDisplayReverseOrder ? setDisplayAngle - halfTotalAngle : setDisplayAngle + halfTotalAngle;

				// Configure the set display angle into radians for reference.
				float setDisplayAngleInRadians = ( setDisplayReverseOrder ? -setDisplayAnglePer : setDisplayAnglePer ) * Mathf.Deg2Rad;

				// Store a Vector3 starting at zero (center).
				Vector3 setDisplayPosition = Vector3.zero;

				// Modify the position by the information above and find the position that the images need to be.
				setDisplayPosition.x -= ( Mathf.Cos( ( setDisplayAngleInRadians * i ) - ( 90 * Mathf.Deg2Rad ) - ( setDisplayModStartAngle * Mathf.Deg2Rad ) - ( -setDisplayAngleInRadians / 2 ) ) * ( relativeTransform.sizeDelta.x * setDisplayOrbitDistance ) );
				setDisplayPosition.y -= ( Mathf.Sin( ( setDisplayAngleInRadians * i ) - ( 90 * Mathf.Deg2Rad ) - ( setDisplayModStartAngle * Mathf.Deg2Rad ) - ( -setDisplayAngleInRadians / 2 ) ) * ( relativeTransform.sizeDelta.x * setDisplayOrbitDistance ) );

				// Apply the size of the set display image.
				QuickbarParents[ i ].setDisplayTransform.sizeDelta = new Vector2( ( relativeTransform.sizeDelta.x / 10 ) * setDisplayImageSize, ( relativeTransform.sizeDelta.x / 10 ) * setDisplayImageSize );

				// Apply the position of the set display image.
				QuickbarParents[ i ].setDisplayTransform.localPosition = setDisplayPosition;

				// Set the scale and color according to if this parent is selected or not.
				QuickbarParents[ i ].setDisplayTransform.localScale = CurrentParentIndex == i ? Vector3.one : Vector3.one * setDisplayDefaultScaleMultiplier;
				QuickbarParents[ i ].setDisplayTransform.GetComponent<Image>().color = CurrentParentIndex == i ? setDisplaySelectedColor : setDisplayDefaultColor;

				// Configure the needed rotation offset of the set display image.
				float rotationOffset = ( setDisplayReverseOrder ? setDisplayAngle : -setDisplayAngle ) - ( setDisplayAnglePer * ( QuickbarParents.Count - 1 ) / 2 );

				// Configure the rotation offset into a Euler angle to apply.
				Vector3 newRotation = new Vector3( 0, 0, 180 + ( setDisplayReverseOrder ? ( -setDisplayAnglePer * i ) - rotationOffset : ( setDisplayAnglePer * i ) + rotationOffset ) );

				// Apply the configured Euler rotation to the set display transform.
				QuickbarParents[ i ].setDisplayTransform.localRotation = Quaternion.Euler( newRotation );
			}
			// Else the user does not want to show the set display, or the parent count is not greater than one...
			else
			{
				// So if the parent transform is assigned and the gameobject is active in the scene, then disable it in the scene.
				if( setDisplayParentTransform != null && setDisplayParentTransform.gameObject.activeInHierarchy )
					setDisplayParentTransform.gameObject.SetActive( false );
			}

			// If the index is the same as our currently selected parent index, then make sure it is currently selected and active.
			if( i == CurrentParentIndex )
			{
				QuickbarParents[ i ].transform.localRotation = Quaternion.identity;
				QuickbarParents[ i ].QuickbarSetSelected();
				QuickbarParents[ i ].canvasGroup.alpha = 1.0f;
				QuickbarParents[ i ].transform.gameObject.SetActive( true );
			}
			// Else, this parent index is not currently selected, so make sure it is deselected.
			else
			{
				QuickbarParents[ i ].transform.localRotation = Quaternion.Euler( 0, 0, 180 );
				QuickbarParents[ i ].QuickbarSetDeselected();
				QuickbarParents[ i ].canvasGroup.alpha = 0.0f;
				QuickbarParents[ i ].transform.gameObject.SetActive( false );
			}
		}

		// Notify any subscribers that the positioning has been updated.
		if( OnUpdateQuickbarPositioning != null )
			OnUpdateQuickbarPositioning();
	}

	/// <summary>
	/// Enables the quickbar and makes it active.
	/// </summary>
	public void EnableQuickbar ()
	{
		// If the quickbar is already active, then just return.
		if( QuickbarActive )
			return;

		// Set QuickbarActive to true for reference.
		QuickbarActive = true;

		// Set the alpha of the canvas group to full.
		canvasGroup.alpha = 1.0f;

		// Notify any subscribers that the quickbar has been enabled.
		if( OnQuickbarEnabled != null )
			OnQuickbarEnabled.Invoke();
	}

	/// <summary>
	/// Disables the quickbar.
	/// </summary>
	public void DisableQuickbar ()
	{
		// If the quickbar is already disabled, then just return.
		if( !QuickbarActive )
			return;

		// Set QuickbarActive to false for reference.
		QuickbarActive = false;

		// Set the alpha of the canvas group to zero.
		canvasGroup.alpha = 0.0f;

		// Notify any subscribers that the quickbar has been disable.
		if( OnQuickbarDisabled != null )
			OnQuickbarDisabled.Invoke();
	}

	/// <summary>
	/// Changes to the target quickbar set.
	/// </summary>
	/// <param name="quickbarIndex">The index of the targeted quickbar set.</param>
	/// <param name="instantTransition">Determines whether or not to perform an instant transition.</param>
	public void ChangeToQuickbarSet ( int quickbarIndex, bool instantTransition = false )
	{
		// If the target index is less than zero, then set it to zero to avoid unwanted behavior.
		if( quickbarIndex < 0 )
			quickbarIndex = 0;

		// Else if the index is greater than the quickbar set count, then set it to being the last index of the quickbar parents.
		else if( quickbarIndex > QuickbarParents.Count - 1 )
			quickbarIndex = QuickbarParents.Count - 1;
		
		// If the target index is the same as the current index, or if the quickbar is currently in the middle of a transition, then return.
		if( quickbarIndex == CurrentParentIndex || Transitioning )
			return;

		// If the user wants the transition to be instant, then call the TransititonInstant function.
		if( instantTransition )
			TransitionInstant( QuickbarParents[ CurrentParentIndex ], QuickbarParents[ quickbarIndex ] );
		// Else the user wants to transition over time...
		else
		{
			// Configure what the rotation should be if the quickbar index would be increasing.
			bool clockwiseRotation = swipeTransition == SwipeTransition.Clockwise;

			// If the target quickbar index is less that the current quickbar, then reverse the rotation.
			if( quickbarIndex < CurrentParentIndex )
				clockwiseRotation = !clockwiseRotation;

			// Start the coroutine.
			StartCoroutine( TransitionQuickbar( QuickbarParents[ CurrentParentIndex ], QuickbarParents[ quickbarIndex ], clockwiseRotation ) );
		}

		// Set the current parent index to this index.
		CurrentParentIndex = quickbarIndex;
	}

	/// <summary>
	/// Cycles through the quickbar sets.
	/// </summary>
	/// <param name="instantTransition">Determines whether or not to perform an instant transition.</param>
	public void CycleQuickbarSets ( bool instantTransition = false )
	{
		// If the quickbar is in the middle of a transition, or if the parent count is only one, then return.
		if( Transitioning || QuickbarParents.Count == 1 )
			return;

		// Attempt to increase the target parent index.
		int targetParentIndex = CurrentParentIndex + 1;

		// If the target index is greater than the max index, then set loop around back to zero.
		if( targetParentIndex >= QuickbarParents.Count )
			targetParentIndex = 0;

		// If the user wants to transition instantly, then just do the transition.
		if( instantTransition )
			TransitionInstant( QuickbarParents[ CurrentParentIndex ], QuickbarParents[ targetParentIndex ] );
		// Else transition over time, start the coroutine.
		else
			StartCoroutine( TransitionQuickbar( QuickbarParents[ CurrentParentIndex ], QuickbarParents[ targetParentIndex ], swipeTransition == SwipeTransition.Clockwise ) );

		// Assign the current parent index to the target.
		CurrentParentIndex = targetParentIndex;
	}

	/// <summary>
	/// Adds a new quickbar set to this quickbar.
	/// </summary>
	public void AddNewQuickbarSet ()
	{
		CreateNewQuickbar();
	}

	/// <summary>
	/// Removes any extra quickbar sets from the quickbar.
	/// </summary>
	public void RemoveEmptyQuickbarSets ()
	{
		// Loop through the quickbar parents starting at the end of the list.
		for( int i = QuickbarParents.Count - 1; i >= 0; i-- )
		{
			// Temporary bool to know if this quickbar is populated at all.
			bool quickbarPopulated = false;

			// Loop through each button in this parent.
			for( int n = 0; n < QuickbarParents[ i ].QuickbarButtons.Count; n++ )
			{
				// If this button is registered...
				if( QuickbarParents[ i ].QuickbarButtons[ n ].Registered )
				{
					// Then set the temp bool to true since this quickbar button is populated.
					quickbarPopulated = true;

					// Break the loop since this quickbar is populated.
					break;
				}
			}

			// If after checking each button this quickbar is not populated, and there is more than just one quickbar, then delete this parent.
			if( !quickbarPopulated && QuickbarParents.Count > 1 )
				QuickbarParents[ i ].DeleteThisParent();
		}

		// If the current parent index is greater than the count, then set it to the end of the list to display.
		if( CurrentParentIndex > QuickbarParents.Count - 1 )
			CurrentParentIndex = QuickbarParents.Count - 1;
		
		// Reset stored indexes.
		CurrentButtonIndex = -10;
		CurrentButtonIndexOnDown = -10;

		// Update quickbar positioning.
		UpdateQuickbarPositioning();
	}

	/// <summary>
	/// Clears the quickbar of all information and removes excess quickbar parents.
	/// </summary>
	public void ClearQuickbar ()
	{
		// Loop through the quickbar parents (excluding index 0), starting at the last index and counting down, and deleting that parent.
		for( int i = QuickbarParents.Count - 1; i > 0; i-- )
			QuickbarParents[ i ].DeleteThisParent();

		// Then, for each button in quickbar 0, clear the button information.
		for( int i = 0; i < QuickbarParents[ 0 ].QuickbarButtons.Count; i++ )
			QuickbarParents[ 0 ].QuickbarButtons[ i ].ClearButtonInformation();

		// Reset stored indexes.
		CurrentParentIndex = 0;
		CurrentButtonIndex = -10;
		CurrentButtonIndexOnDown = -10;

		// Update quickbar positioning.
		UpdateQuickbarPositioning();
	}

	/// <summary>
	/// Registers the information to the first button that is not registered.
	/// </summary>
	/// <param name="ButtonCallback">The action callback to call when this new button is being interacted with.</param>
	/// <param name="newButtonInfo">The new button information to apply to the quickbar button.</param>
	/// <param name="focus">Determines if the quickbar should change to show the new registered information.</param>
	public void RegisterToQuickbar ( Action ButtonCallback, UltimateMobileQuickbarButtonInfo newButtonInfo, bool focus = false )
	{
		// Find the parent and button index to register to.
		int[] buttonToRegisterTo = FindNextAvailableQuickbarButton();

		// Register the information to the targeted button.
		QuickbarParents[ buttonToRegisterTo[ 0 ] ].QuickbarButtons[ buttonToRegisterTo[ 1 ] ].RegisterButtonInfo( newButtonInfo );
		QuickbarParents[ buttonToRegisterTo[ 0 ] ].QuickbarButtons[ buttonToRegisterTo[ 1 ] ].OnButtonInteract += ButtonCallback;

		// If the user wants to focus on the new item that was added to the quickbar and the target parent isn't active, then change the quickbar.
		if( focus && buttonToRegisterTo[ 0 ] != CurrentParentIndex )
			ChangeToQuickbarSet( buttonToRegisterTo[ 0 ], true );
	}

	/// <summary>
	/// Registers the information to the first button that is not registered.
	/// </summary>
	/// <param name="ButtonCallback">The action callback to call when this new button is being interacted with.</param>
	/// <param name="newButtonInfo">The new button information to apply to the quickbar button.</param>
	/// <param name="focus">Determines if the quickbar should change to show the new registered information.</param>
	public void RegisterToQuickbar ( Action<int> ButtonCallback, UltimateMobileQuickbarButtonInfo newButtonInfo, bool focus = false )
	{
		// Find the parent and button index to register to.
		int[] buttonToRegisterTo = FindNextAvailableQuickbarButton();

		// Register the information to the targeted button.
		QuickbarParents[ buttonToRegisterTo[ 0 ] ].QuickbarButtons[ buttonToRegisterTo[ 1 ] ].RegisterButtonInfo( newButtonInfo );
		QuickbarParents[ buttonToRegisterTo[ 0 ] ].QuickbarButtons[ buttonToRegisterTo[ 1 ] ].OnButtonInteractWithId += ButtonCallback;

		// If the user wants to focus on the new item that was added to the quickbar and the target parent isn't active, then change the quickbar.
		if( focus && buttonToRegisterTo[ 0 ] != CurrentParentIndex )
			ChangeToQuickbarSet( buttonToRegisterTo[ 0 ], true );
	}

	/// <summary>
	/// Registers the information to the first button that is not registered.
	/// </summary>
	/// <param name="ButtonCallback">The action callback to call when this new button is being interacted with.</param>
	/// <param name="newButtonInfo">The new button information to apply to the quickbar button.</param>
	/// <param name="focus">Determines if the quickbar should change to show the new registered information.</param>
	public void RegisterToQuickbar ( Action<string> ButtonCallback, UltimateMobileQuickbarButtonInfo newButtonInfo, bool focus = false )
	{
		// Find the parent and button index to register to.
		int[] buttonToRegisterTo = FindNextAvailableQuickbarButton();

		// Register the information to the targeted button.
		QuickbarParents[ buttonToRegisterTo[ 0 ] ].QuickbarButtons[ buttonToRegisterTo[ 1 ] ].RegisterButtonInfo( newButtonInfo );
		QuickbarParents[ buttonToRegisterTo[ 0 ] ].QuickbarButtons[ buttonToRegisterTo[ 1 ] ].OnButtonInteractWithKey += ButtonCallback;

		// If the user wants to focus on the new item that was added to the quickbar and the target parent isn't active, then change the quickbar.
		if( focus && buttonToRegisterTo[ 0 ] != CurrentParentIndex )
			ChangeToQuickbarSet( buttonToRegisterTo[ 0 ], true );
	}

	/// <summary>
	/// Registers the information to the targeted button on the quickbar.
	/// </summary>
	/// <param name="ButtonCallback">The action callback to call when this new button is being interacted with.</param>
	/// <param name="newButtonInfo">The new button information to apply to the quickbar button.</param>
	/// <param name="parentIndex">The targeted parent index.</param>
	/// <param name="buttonIndex">The targeted button index.</param>
	/// <param name="focus">Determines if the quickbar should change to show the new registered information.</param>
	public void RegisterToQuickbar ( Action ButtonCallback, UltimateMobileQuickbarButtonInfo newButtonInfo, int parentIndex, int buttonIndex, bool focus = false )
	{
		// If the targeted quickbar button index does not exist, then just return.
		if( !ConfirmQuickbarButtonIndex( parentIndex, buttonIndex ) )
			return;

		// If the targeted button is occupied, clear it before continuing.
		if( QuickbarParents[ parentIndex ].QuickbarButtons[ buttonIndex ].Registered )
			QuickbarParents[ parentIndex ].QuickbarButtons[ buttonIndex ].ClearButtonInformation();

		// Register the information to the targeted button.
		QuickbarParents[ parentIndex ].QuickbarButtons[ buttonIndex ].RegisterButtonInfo( newButtonInfo );
		QuickbarParents[ parentIndex ].QuickbarButtons[ buttonIndex ].OnButtonInteract += ButtonCallback;

		// If the user wants to focus on the new item that was added to the quickbar and the target parent isn't active, then change the quickbar.
		if( focus && parentIndex != CurrentParentIndex )
			ChangeToQuickbarSet( parentIndex, true );
	}

	/// <summary>
	/// Registers the information to the targeted button on the quickbar.
	/// </summary>
	/// <param name="ButtonCallback">The action callback to call when this new button is being interacted with.</param>
	/// <param name="newButtonInfo">The new button information to apply to the quickbar button.</param>
	/// <param name="parentIndex">The targeted parent index.</param>
	/// <param name="buttonIndex">The targeted button index.</param>
	/// <param name="focus">Determines if the quickbar should change to show the new registered information.</param>
	public void RegisterToQuickbar ( Action<int> ButtonCallback, UltimateMobileQuickbarButtonInfo newButtonInfo, int parentIndex, int buttonIndex, bool focus = false )
	{
		// If the targeted quickbar button index does not exist, then just return.
		if( !ConfirmQuickbarButtonIndex( parentIndex, buttonIndex ) )
			return;

		// If the targeted button is occupied, clear it before continuing.
		if( QuickbarParents[ parentIndex ].QuickbarButtons[ buttonIndex ].Registered )
			QuickbarParents[ parentIndex ].QuickbarButtons[ buttonIndex ].ClearButtonInformation();

		// Register the information to the targeted button.
		QuickbarParents[ parentIndex ].QuickbarButtons[ buttonIndex ].RegisterButtonInfo( newButtonInfo );
		QuickbarParents[ parentIndex ].QuickbarButtons[ buttonIndex ].OnButtonInteractWithId += ButtonCallback;

		// If the user wants to focus on the new item that was added to the quickbar and the target parent isn't active, then change the quickbar.
		if( focus && parentIndex != CurrentParentIndex )
			ChangeToQuickbarSet( parentIndex, true );
	}

	/// <summary>
	/// Registers the information to the targeted button on the quickbar.
	/// </summary>
	/// <param name="ButtonCallback">The action callback to call when this new button is being interacted with.</param>
	/// <param name="newButtonInfo">The new button information to apply to the quickbar button.</param>
	/// <param name="parentIndex">The targeted parent index.</param>
	/// <param name="buttonIndex">The targeted button index.</param>
	/// <param name="focus">Determines if the quickbar should change to show the new registered information.</param>
	public void RegisterToQuickbar ( Action<string> ButtonCallback, UltimateMobileQuickbarButtonInfo newButtonInfo, int parentIndex, int buttonIndex, bool focus = false )
	{
		// If the targeted quickbar button index does not exist, then just return.
		if( !ConfirmQuickbarButtonIndex( parentIndex, buttonIndex ) )
			return;

		// If the targeted button is occupied, clear it before continuing.
		if( QuickbarParents[ parentIndex ].QuickbarButtons[ buttonIndex ].Registered )
			QuickbarParents[ parentIndex ].QuickbarButtons[ buttonIndex ].ClearButtonInformation();

		// Register the information to the targeted button.
		QuickbarParents[ parentIndex ].QuickbarButtons[ buttonIndex ].RegisterButtonInfo( newButtonInfo );
		QuickbarParents[ parentIndex ].QuickbarButtons[ buttonIndex ].OnButtonInteractWithKey += ButtonCallback;

		// If the user wants to focus on the new item that was added to the quickbar and the target parent isn't active, then change the quickbar.
		if( focus && parentIndex != CurrentParentIndex )
			ChangeToQuickbarSet( parentIndex, true );
	}
	// ------------------------------------------------ < END PUBLIC FUNCTIONS FOR THE USER > ------------------------------------------------ //

	/// <summary>
	/// Confirms the existence of the quickbar that has been registered with the targeted name.
	/// </summary>
	/// <param name="quickbarName">The string name that the quickbar has been registered with.</param>
	static bool ConfirmUltimateMobileQuickbar ( string quickbarName )
	{
		// If the static quickbar dictionary does not contain the targeted key, then inform the user and return false.
		if( !UltimateMobileQuickbars.ContainsKey( quickbarName ) )
		{
			Debug.LogWarning( "Ultimate Mobile Quickbar - There is no Ultimate Mobile Quickbar registered with the name: " + quickbarName + " in the scene." );
			return false;
		}
		return true;
	}

	// ----------------------------------------------------- < PUBLIC STATIC FUNCTIONS > ----------------------------------------------------- //
	/// <summary>
	/// Returns the targeted Ultimate Mobile Quickbar component.
	/// </summary>
	/// <param name="quickbarName">The registered name of the targeted Ultimate Mobile Quickbar.</param>
	public static UltimateMobileQuickbar GetUltimateMobileQuickbar ( string quickbarName )
	{
		// If the targeted quickbar does not exist, then return null.
		if( !ConfirmUltimateMobileQuickbar( quickbarName ) )
			return null;

		// Return the targeted Ultimate Mobile Quickbar.
		return UltimateMobileQuickbars[ quickbarName ];
	}

	/// <summary>
	/// Updates the positioning of the targeted Ultimate Mobile Quickbar.
	/// </summary>
	/// <param name="quickbarName">The registered name of the targeted Ultimate Mobile Quickbar.</param>
	public static void UpdateQuickbarPositioning ( string quickbarName )
	{
		// If the targeted quickbar does not exist, then return.
		if( !ConfirmUltimateMobileQuickbar( quickbarName ) )
			return;

		// Call the local UpdateQuickbarPositioning function on the targeted quickbar.
		UltimateMobileQuickbars[ quickbarName ].UpdateQuickbarPositioning();
	}

	/// <summary>
	/// Enables the targeted Ultimate Mobile Quickbar.
	/// </summary>
	/// <param name="quickbarName">The registered name of the targeted Ultimate Mobile Quickbar.</param>
	public static void EnableQuickbar ( string quickbarName )
	{
		// If the targeted quickbar does not exist, then return.
		if( !ConfirmUltimateMobileQuickbar( quickbarName ) )
			return;

		// Call the local EnableQuickbar function on the targeted quickbar.
		UltimateMobileQuickbars[ quickbarName ].EnableQuickbar();
	}

	/// <summary>
	/// Disables the targeted Ultimate Mobile Quickbar.
	/// </summary>
	/// <param name="quickbarName">The registered name of the targeted Ultimate Mobile Quickbar.</param>
	public static void DisableQuickbar ( string quickbarName )
	{
		// If the targeted quickbar does not exist, then return.
		if( !ConfirmUltimateMobileQuickbar( quickbarName ) )
			return;

		// Call the local DisableQuickbar function on the targeted quickbar.
		UltimateMobileQuickbars[ quickbarName ].DisableQuickbar();
	}

	/// <summary>
	/// Changes the quickbar set on the targeted Ultimate Mobile Quickbar.
	/// </summary>
	/// <param name="quickbarName">The registered name of the targeted Ultimate Mobile Quickbar.</param>
	/// <param name="quickbarIndex">The index of the targeted quickbar set.</param>
	/// <param name="instantTransition">Determines whether or not to perform an instant transition.</param>
	public static void ChangeToQuickbarSet ( string quickbarName, int quickbarIndex, bool instantTransition = false )
	{
		// If the targeted quickbar does not exist, then return.
		if( !ConfirmUltimateMobileQuickbar( quickbarName ) )
			return;

		// Call the local ChangeToQuickbarSet function on the targeted quickbar.
		UltimateMobileQuickbars[ quickbarName ].ChangeToQuickbarSet( quickbarIndex, instantTransition );
	}

	/// <summary>
	/// Cycles through the quickbar sets on the targeted Ultimate Mobile Quickbar.
	/// </summary>
	/// <param name="quickbarName">The registered name of the targeted Ultimate Mobile Quickbar.</param>
	/// <param name="instantTransition">Determines whether or not to perform an instant transition.</param>
	public static void CycleQuickbarSets ( string quickbarName, bool instantTransition = false )
	{
		// If the targeted quickbar does not exist, then return.
		if( !ConfirmUltimateMobileQuickbar( quickbarName ) )
			return;

		// Call the local CycleQuickbarSets function on the targeted quickbar.
		UltimateMobileQuickbars[ quickbarName ].CycleQuickbarSets();
	}

	/// <summary>
	/// Adds a new quickbar set to the targeted Ultimate Mobile Quickbar.
	/// </summary>
	/// <param name="quickbarName">The registered name of the targeted Ultimate Mobile Quickbar.</param>
	public static void AddNewQuickbarSet ( string quickbarName )
	{
		// If the targeted quickbar does not exist, then return.
		if( !ConfirmUltimateMobileQuickbar( quickbarName ) )
			return;

		// Call the local AddNewQuickbarSet function on the targeted quickbar.
		UltimateMobileQuickbars[ quickbarName ].AddNewQuickbarSet();
	}

	/// <summary>
	/// Removes any extra quickbar sets from the targeted Ultimate Mobile Quickbar that are not populated with any button information.
	/// </summary>
	/// <param name="quickbarName">The registered name of the targeted Ultimate Mobile Quickbar.</param>
	public static void RemoveEmptyQuickbarSets ( string quickbarName )
	{
		// If the targeted quickbar does not exist, then return.
		if( !ConfirmUltimateMobileQuickbar( quickbarName ) )
			return;

		// Call the local AddNewQuickbarSet function on the targeted quickbar.
		UltimateMobileQuickbars[ quickbarName ].AddNewQuickbarSet();
	}
	
	/// <summary>
	/// Clears the targeted Ultimate Mobile Quickbar of all information and removes excess quickbar parents.
	/// </summary>
	/// <param name="quickbarName">The registered name of the targeted Ultimate Mobile Quickbar.</param>
	public static void ClearQuickbar ( string quickbarName )
	{
		// If the targeted quickbar does not exist, then return.
		if( !ConfirmUltimateMobileQuickbar( quickbarName ) )
			return;

		// Call the local ClearQuickbar function on the targeted quickbar.
		UltimateMobileQuickbars[ quickbarName ].ClearQuickbar();
	}

	/// <summary>
	/// Registers the information to the first button that is not registered on the targeted Ultimate Mobile Quickbar.
	/// </summary>
	/// <param name="quickbarName">The registered name of the targeted Ultimate Mobile Quickbar.</param>
	/// <param name="ButtonCallback">The action callback to call when this new button is being interacted with.</param>
	/// <param name="newButtonInfo">The new button information to apply to the quickbar button.</param>
	/// <param name="focus">Determines if the quickbar should change to show the new registered information.</param>
	public static void RegisterToQuickbar ( string quickbarName, Action ButtonCallback, UltimateMobileQuickbarButtonInfo newButtonInfo, bool focus = false )
	{
		// If the targeted quickbar does not exist, then return.
		if( !ConfirmUltimateMobileQuickbar( quickbarName ) )
			return;

		// Call the local RegisterToQuickbar function with the provided parameters.
		UltimateMobileQuickbars[ quickbarName ].RegisterToQuickbar( ButtonCallback, newButtonInfo, focus );
	}

	/// <summary>
	/// Registers the information to the first button that is not registered on the targeted Ultimate Mobile Quickbar.
	/// </summary>
	/// <param name="quickbarName">The registered name of the targeted Ultimate Mobile Quickbar.</param>
	/// <param name="ButtonCallback">The action callback to call when this new button is being interacted with.</param>
	/// <param name="newButtonInfo">The new button information to apply to the quickbar button.</param>
	/// <param name="focus">Determines if the quickbar should change to show the new registered information.</param>
	public static void RegisterToQuickbar ( string quickbarName, Action<int> ButtonCallback, UltimateMobileQuickbarButtonInfo newButtonInfo, bool focus = false )
	{
		// If the targeted quickbar does not exist, then return.
		if( !ConfirmUltimateMobileQuickbar( quickbarName ) )
			return;

		// Call the local RegisterToQuickbar function with the provided parameters.
		UltimateMobileQuickbars[ quickbarName ].RegisterToQuickbar( ButtonCallback, newButtonInfo, focus );
	}

	/// <summary>
	/// Registers the information to the first button that is not registered on the targeted Ultimate Mobile Quickbar.
	/// </summary>
	/// <param name="quickbarName">The registered name of the targeted Ultimate Mobile Quickbar.</param>
	/// <param name="ButtonCallback">The action callback to call when this new button is being interacted with.</param>
	/// <param name="newButtonInfo">The new button information to apply to the quickbar button.</param>
	/// <param name="focus">Determines if the quickbar should change to show the new registered information.</param>
	public static void RegisterToQuickbar ( string quickbarName, Action<string> ButtonCallback, UltimateMobileQuickbarButtonInfo newButtonInfo, bool focus = false )
	{
		// If the targeted quickbar does not exist, then return.
		if( !ConfirmUltimateMobileQuickbar( quickbarName ) )
			return;

		// Call the local RegisterToQuickbar function with the provided parameters.
		UltimateMobileQuickbars[ quickbarName ].RegisterToQuickbar( ButtonCallback, newButtonInfo, focus );
	}

	/// <summary>
	/// Registers the information to the targeted button on the targeted Ultimate Mobile Quickbar.
	/// </summary>
	/// <param name="quickbarName">The registered name of the targeted Ultimate Mobile Quickbar.</param>
	/// <param name="ButtonCallback">The action callback to call when this new button is being interacted with.</param>
	/// <param name="newButtonInfo">The new button information to apply to the quickbar button.</param>
	/// <param name="parentIndex">The targeted parent index.</param>
	/// <param name="buttonIndex">The targeted button index to register to.</param>
	/// <param name="focus">Determines if the quickbar should change to show the new registered information.</param>
	public static void RegisterToQuickbar ( string quickbarName, Action ButtonCallback, UltimateMobileQuickbarButtonInfo newButtonInfo, int parentIndex, int buttonIndex, bool focus = false )
	{
		// If the targeted quickbar does not exist, then return.
		if( !ConfirmUltimateMobileQuickbar( quickbarName ) )
			return;

		// Call the local RegisterToQuickbar function with the provided parameters.
		UltimateMobileQuickbars[ quickbarName ].RegisterToQuickbar( ButtonCallback, newButtonInfo, parentIndex, buttonIndex, focus );
	}

	/// <summary>
	/// Registers the information to the targeted button on the targeted Ultimate Mobile Quickbar.
	/// </summary>
	/// <param name="quickbarName">The registered name of the targeted Ultimate Mobile Quickbar.</param>
	/// <param name="ButtonCallback">The action callback to call when this new button is being interacted with.</param>
	/// <param name="newButtonInfo">The new button information to apply to the quickbar button.</param>
	/// <param name="parentIndex">The targeted parent index.</param>
	/// <param name="buttonIndex">The targeted button index to register to.</param>
	/// <param name="focus">Determines if the quickbar should change to show the new registered information.</param>
	public static void RegisterToQuickbar ( string quickbarName, Action<int> ButtonCallback, UltimateMobileQuickbarButtonInfo newButtonInfo, int parentIndex, int buttonIndex, bool focus = false )
	{
		// If the targeted quickbar does not exist, then return.
		if( !ConfirmUltimateMobileQuickbar( quickbarName ) )
			return;

		// Call the local RegisterToQuickbar function with the provided parameters.
		UltimateMobileQuickbars[ quickbarName ].RegisterToQuickbar( ButtonCallback, newButtonInfo, parentIndex, buttonIndex, focus );
	}

	/// <summary>
	/// Registers the information to the targeted button on the targeted Ultimate Mobile Quickbar.
	/// </summary>
	/// <param name="quickbarName">The registered name of the targeted Ultimate Mobile Quickbar.</param>
	/// <param name="ButtonCallback">The action callback to call when this new button is being interacted with.</param>
	/// <param name="newButtonInfo">The new button information to apply to the quickbar button.</param>
	/// <param name="parentIndex">The targeted parent index.</param>
	/// <param name="buttonIndex">The targeted button index to register to.</param>
	/// <param name="focus">Determines if the quickbar should change to show the new registered information.</param>
	public static void RegisterToQuickbar ( string quickbarName, Action<string> ButtonCallback, UltimateMobileQuickbarButtonInfo newButtonInfo, int parentIndex, int buttonIndex, bool focus = false )
	{
		// If the targeted quickbar does not exist, then return.
		if( !ConfirmUltimateMobileQuickbar( quickbarName ) )
			return;

		// Call the local RegisterToQuickbar function with the provided parameters.
		UltimateMobileQuickbars[ quickbarName ].RegisterToQuickbar( ButtonCallback, newButtonInfo, parentIndex, buttonIndex, focus );
	}
	// --------------------------------------------------- < END PUBLIC STATIC FUNCTIONS > --------------------------------------------------- //
}