/* UltimateMobileQuickbarReadme.cs */
/* Written by Kaz Crowe */
using UnityEngine;

//[CreateAssetMenu( fileName = "README", menuName = "Tank and Healer Studio/Ultimate Mobile Quickbar README File", order = 1 )]
public class UltimateMobileQuickbarReadme : ScriptableObject
{
	public Texture2D icon;
	public Texture2D settings;
	public Texture2D scriptReference;
	
	// GIZMO COLORS //
	[HideInInspector]
	public Color colorDefault = new Color( 1.0f, 1.0f, 1.0f, 0.5f );
	[HideInInspector]
	public Color colorValueChanged = new Color( 0.80f, 0, 1.0f, 1.0f );
	
	public static int ImportantChange = 0;// UPDATE ON IMPORTANT CHANGES //
	public class VersionHistory
	{
		public string versionNumber = "";
		public string[] changes;
	}
	public VersionHistory[] versionHistory = new VersionHistory[]
	{
		// VERSION 1.1.0
		new VersionHistory ()
		{
			versionNumber = "1.1.0",
			changes = new string[]
			{
				// GENERAL CHANGES //
				"Added support for different canvas render modes and canvas scale modes",
			},
		},
		// VERSION 1.0.0
		new VersionHistory ()
		{
			versionNumber = "1.0.0",
			changes = new string[]
			{
				"Initial release",
			},
		},
	};
}