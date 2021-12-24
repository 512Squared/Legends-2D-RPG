/* UltimateMobileQuickbarButtonInfo.cs */
/* Written by Kaz Crowe */
using System;
using UnityEngine;

[Serializable]
public class UltimateMobileQuickbarButtonInfo
{
	/// <summary>
	/// The Ultimate Mobile Quickbar component that this information has been assigned to.
	/// </summary>
	public UltimateMobileQuickbar Quickbar
	{
		get;
		private set;
	}
	/// <summary>
	/// The index of the QuickbarParent that this information was assigned to.
	/// </summary>
	public int ParentIndex
	{
		get;
		private set;
	}
	/// <summary>
	/// The index of the QuickbarButton that this information is assigned to.
	/// </summary>
	public int ButtonIndex
	{
		get;
		private set;
	}

	public UltimateMobileQuickbar.QuickbarButton QuickbarButton
	{
		get
		{
			if( QuickbarButtonError )
				return null;

			return Quickbar.QuickbarParents[ ParentIndex ].QuickbarButtons[ ButtonIndex ];
		}
	}

	public int id;
	public string key;
	public Sprite icon;


	/// <summary>
	/// Assigns a new sprite to the button's icon image.
	/// </summary>
	/// <param name="newIcon">The new sprite to assign as the icon for the button.</param>
	public void UpdateIcon ( Sprite newIcon )
	{
		// Assign the new icon.
		icon = newIcon;

		// If the button is null, notify the user and return.
		if( QuickbarButtonError )
			return;

		// Apply the new icon to the button icon.
		Quickbar.QuickbarParents[ ParentIndex ].QuickbarButtons[ ButtonIndex ].buttonIcon.sprite = newIcon;
	}

	/// <summary>
	/// Updates the quickbar button with the cooldown information provided.
	/// </summary>
	/// <param name="current">The current value of the cooldown.</param>
	/// <param name="max">The max value of the cooldown.</param>
	public void UpdateCooldown ( float current, float max )
	{
		// If the button is null, notify the user and return.
		if( QuickbarButtonError )
			return;

		// Call the UpdateCooldown on the button this is assigned to.
		Quickbar.QuickbarParents[ ParentIndex ].QuickbarButtons[ ButtonIndex ].UpdateCooldown( current, max );
	}

	/// <summary>
	/// Updates the count text of the quickbar button with the information provided.
	/// </summary>
	/// <param name="currentCount">The current count to display on the quickbar button.</param>
	public void UpdateCount ( int currentCount )
	{
		// If the button is null, notify the user and return.
		if( QuickbarButtonError )
			return;

		// Call the UpdateCooldown on the button that this is assigned to.
		Quickbar.QuickbarParents[ ParentIndex ].QuickbarButtons[ ButtonIndex ].UpdateCount( currentCount );
	}

	/// <summary>
	/// Returns the existence of this information on a quickbar.
	/// </summary>
	public bool ExistsOnQuickbar ()
	{
		// If the quickbar is null, then return false.
		if( Quickbar == null )
			return false;

		// If the quickbar button is registered, then return true that this information is attached.
		if( Quickbar.QuickbarParents[ ParentIndex ].QuickbarButtons[ ButtonIndex ].Registered )
			return true;

		// Else, return false.
		return false;
	}

	/// <summary>
	/// Removes this information from the current button.
	/// </summary>
	public void RemoveFromQuickbar ()
	{
		// If the button is null, notify the user and return.
		if( QuickbarButtonError )
			return;

		// Call the ClearButtonInformation on the button that this is assigned to. The OnClearButtonInformation callback will reset the reference information.
		Quickbar.QuickbarParents[ ParentIndex ].QuickbarButtons[ ButtonIndex ].ClearButtonInformation();
	}

	/// <summary>
	/// [Internal] For use from the Ultimate Mobile Quickbar. Do not call from your custom scripts.
	/// </summary>
	public void RegisterQuickbarData ( UltimateMobileQuickbar quickbar, int parentIndex, int buttonIndex )
	{
		// Store the provided information since it was just registered.
		Quickbar = quickbar;
		ParentIndex = parentIndex;
		ButtonIndex = buttonIndex;

		// Subscribe to the OnClearButtonInformation and OnChangeParentIndex callbacks.
		quickbar.QuickbarParents[ ParentIndex ].QuickbarButtons[ ButtonIndex ].OnClearButtonInformation += OnClearButtonInformation;
		quickbar.QuickbarParents[ ParentIndex ].QuickbarButtons[ ButtonIndex ].OnChangeParentIndex += OnChangeParentIndex;
	}

	/// <summary>
	/// [Internal] This function is subscribed to the OnClearButtonInformation callback on the quickbar button that this is assigned to.
	/// </summary>
	void OnClearButtonInformation ()
	{
		// If the button is null, notify the user and return.
		if( QuickbarButtonError )
			return;

		// Reset this information since the button information was cleared.
		ParentIndex = -1;
		ButtonIndex = -1;
		Quickbar = null;
	}

	/// <summary>
	/// [Internal] This function is subscribed to the OnChangeParentIndex callback on the quickbar button that this is assigned to.
	/// </summary>
	void OnChangeParentIndex ( int previousIndex, int changedIndex )
	{
		if( previousIndex != ParentIndex )
			return;
		
		ParentIndex = changedIndex;
	}

	/// <summary>
	/// Returns true if the button is not assigned and displays an error.
	/// </summary>
	bool QuickbarButtonError
	{
		get
		{
			// If the button is null...
			if( Quickbar == null )
			{
				// Inform the user that there is no button and return true for there being an error.
				Debug.LogWarning( "Ultimate Mobile Quickbar\nThis information has not been registered to a Ultimate Mobile Quickbar." );
				return true;
			}

			return false;
		}
	}
}