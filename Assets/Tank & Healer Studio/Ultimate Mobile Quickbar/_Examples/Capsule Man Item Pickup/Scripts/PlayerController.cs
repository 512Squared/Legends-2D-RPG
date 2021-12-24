using UnityEngine;

namespace UltimateMobileQuickbarExample.CharacterInventory2D
{
	[RequireComponent( typeof( Rigidbody2D ) )]
	public class PlayerController : MonoBehaviour
	{
		public float speed = 10;
		Rigidbody2D myRigidbody;
		SpriteRenderer mySpriteRenderer;

		
		void Start ()
		{
			myRigidbody = GetComponent<Rigidbody2D>();
			mySpriteRenderer = GetComponent<SpriteRenderer>();
		}
		
		void FixedUpdate ()
		{
			//Store the current horizontal input in the float moveHorizontal.
			float moveHorizontal = Input.GetAxis( "Horizontal" );

			//Store the current vertical input in the float moveVertical.
			float moveVertical = Input.GetAxis( "Vertical" );

			// If the horizontal input is not zero, then flip the x of the sprite based on the horizontal input.
			if( Mathf.Abs( moveHorizontal ) > 0 )
				mySpriteRenderer.flipX = Mathf.Sign( moveHorizontal ) == -1;
	
			// Store the position that the character is in into view port coordinates.
			Vector3 pos = Camera.main.WorldToViewportPoint( myRigidbody.position + ( new Vector2( moveHorizontal, moveVertical ) * speed ) );

			// Then clamp the position to not allow the character to leave the screen bounds.
			pos.x = Mathf.Clamp( pos.x, 0.05f, 0.95f );
			pos.y = Mathf.Clamp( pos.y, 0.1f, 0.9f );

			// Reconfigure the position into world position and apply it to the rigidbody.
			myRigidbody.MovePosition( Camera.main.ViewportToWorldPoint( pos ) );
		}
	}
}