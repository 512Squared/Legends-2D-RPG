using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace UltimateMobileQuickbarExample.CharacterInventory2D
{
	public class CharacterInventoryGameManager : MonoBehaviour
	{
		// TUTORIAL VARIABLES //
		public Text tutorialText;
		bool hasPickedUpItems, hasInteractedWithButton;
		
		// MENU VARIABLES //
		public SpriteRenderer backgroundSprite;

		// ITEM SPAWNING //
		float itemSpawningTimer = 0.0f;
		public float itemSpawningRate = 2.5f;
		public int startingItems = 3;
		Vector2 spawnRangeMin, spawnRangeMax;
		public GameObject itemBasePrefab;

		[System.Serializable]
		public class ItemInformation
		{
			public string name;
			public Sprite itemSprite;
			public int itemCount = 0;
			public UltimateMobileQuickbarButtonInfo buttonInfo;

			public void UseItem ()
			{
				// THIS IS WHERE YOUR ITEM LOGIC WOULD APPLY THE ITEMS EFFECT!!
				Debug.Log( "Using: " + name );
			}
		}
		public ItemInformation[] items;
		Dictionary<string, ItemInformation> itemDictionary = new Dictionary<string, ItemInformation>();

		[Header( "Player Skill" )]
		public Sprite skillIcon;
		public float skillCooldownTime = 10.0f;
		float cooldownTime = 0.0f;
		public UltimateMobileQuickbarButtonInfo buttonInfo;
		public Transform pickupSkill;
		SpriteRenderer skillRenderer;


		void Start ()
		{
			// Change the size of the background to fill up the camera space.
			backgroundSprite.size = new Vector2( ( ( Camera.main.orthographicSize * Screen.width ) / Screen.height ) * 2, Camera.main.orthographicSize * 2 );
			backgroundSprite.transform.position = Vector2.zero;

			// Configure the spawn ranges for the items.
			spawnRangeMin = ( -backgroundSprite.size / 2 ) * 0.95f;
			spawnRangeMax = ( backgroundSprite.size / 2 ) * 0.95f;

			// Set the base item prefab as inactive.
			itemBasePrefab.SetActive( false );

			// Loop through each of the items...
			for( int i = 0; i < items.Length; i++ )
			{
				// Apply the item information the radial button info for this item.
				items[ i ].buttonInfo.key = items[ i ].name;
				items[ i ].buttonInfo.icon = items[ i ].itemSprite;

				// Add the item to the dictionary with the name as the key.
				itemDictionary.Add( items[ i ].name, items[ i ] );
			}

			// Clear the radial menu button so that the menu starts with no items.
			UltimateMobileQuickbar.ClearQuickbar( "Player" );

			// This is for the tutorial text only //
			UltimateMobileQuickbar.GetUltimateMobileQuickbar( "Player" ).OnButtonInteract += OnButtonInteract;

			// Register the skill to the quickbar.
			buttonInfo.icon = skillIcon;
			UltimateMobileQuickbar.RegisterToQuickbar( "Player", DoCapsuleManSkill, buttonInfo, 0, 0 );
			skillRenderer = pickupSkill.GetComponent<SpriteRenderer>();

			for( int i = 0; i < startingItems; i++ )
			{
				CreateItem();
			}
		}

		void Update ()
		{
			// Increase the spawn timer.
			itemSpawningTimer += Time.deltaTime;

			// If the spawn timer is greater than the spawning rate...
			if( itemSpawningTimer >= itemSpawningRate )
			{
				// Reset the spawning timer.
				itemSpawningTimer -= itemSpawningRate;

				// Create an item in the scene.
				CreateItem();
			}

			if( cooldownTime > 0 )
			{
				cooldownTime -= Time.deltaTime;
				buttonInfo.UpdateCooldown( cooldownTime, skillCooldownTime );
			}
		}

		void CreateItem ()
		{
			// Instantiate a new item in the game.
			GameObject newItem = Instantiate( itemBasePrefab, new Vector3( Random.Range( spawnRangeMin.x, spawnRangeMax.x ), Random.Range( spawnRangeMin.y, spawnRangeMax.y ) ), Quaternion.identity );

			// Make sure that the item is active in the scene.
			newItem.SetActive( true );

			// Give the new item a random item from the list.
			ItemInformation randomItem = items[ Random.Range( 0, items.Length ) ];
			newItem.GetComponent<SpriteRenderer>().sprite = randomItem.itemSprite;
			newItem.GetComponent<WorldItem>().myManager = this;
			newItem.GetComponent<WorldItem>().myInformation = randomItem;
		}

		/// <summary>
		/// This function is called by the WorldItem that has been picked up.
		/// </summary>
		public void PickupItem ( ItemInformation itemInfo )
		{
			// Increase the item count.
			itemInfo.itemCount++;

			// If the item does not exist on the menu already, then add it to the menu.
			if( itemInfo.buttonInfo.ExistsOnQuickbar() == false )
				UltimateMobileQuickbar.RegisterToQuickbar( "Player", UseItem, itemInfo.buttonInfo );
			
			// Update the button text with the new count of the item.
			itemInfo.buttonInfo.UpdateCount( itemInfo.itemCount );
		}

		/// <summary>
		/// This function will be called from the radial button when it is interacted with. The itemKey parameter is how this script identifies which item was used.
		/// </summary>
		void UseItem ( string itemKey )
		{
			// If the dictionary does not contain the key sent, then return a warning message.
			if( !itemDictionary.ContainsKey( itemKey ) )
			{
				Debug.LogWarning( "Key does not exist in the dictionary." );
				return;
			}

			// Decrease the item count of the item, and update the radial button text.
			itemDictionary[ itemKey ].itemCount--;
			itemDictionary[ itemKey ].buttonInfo.UpdateCount( itemDictionary[ itemKey ].itemCount );

			// Call the UseItem() function for this item.
			itemDictionary[ itemKey ].UseItem();

			// If the item count has been depleted, delete the button.
			if( itemDictionary[ itemKey ].itemCount <= 0 )
				itemDictionary[ itemKey ].buttonInfo.RemoveFromQuickbar();
		}

		void DoCapsuleManSkill ()
		{
			if( cooldownTime > 0 )
				return;

			cooldownTime = skillCooldownTime;

			StartCoroutine( "CapsuleManSkill" );
		}

		IEnumerator CapsuleManSkill ()
		{
			skillRenderer.color = Color.white;

			for( float t = 0.0f; t < 1.0f; t += Time.deltaTime * 2 )
			{
				pickupSkill.localScale = Vector3.Lerp( Vector3.zero, Vector3.one * 2.5f, t );
				yield return null;
			}
			pickupSkill.localScale = Vector3.one * 2.5f;

			for( float t = 0.0f; t < 1.0f; t += Time.deltaTime * 5 )
			{
				skillRenderer.color = Color32.Lerp( Color.white, Color.clear, t );
				yield return null;
			}

			skillRenderer.color = Color.clear;
			pickupSkill.localScale = Vector3.zero;
		}

		// TUTORIAL FUNCTIONS //
		void OnButtonInteract ( int parentIndex, int buttonIndex )
		{
			if( !hasInteractedWithButton )
				tutorialText.text = "Awesome! When you interact with a quickbar, check out the Console to see that the quickbar called the right item.";

			hasInteractedWithButton = true;
		}
		// END TUTORIAL FUNCTIONS //
	}
}