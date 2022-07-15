using UnityEngine;
using System.Reflection;

public class GameAssets : MonoBehaviour
{
    public static GameAssets _fetch;

    public static GameAssets Fetch
    {
        get
        {
            if (_fetch == null) { _fetch = Instantiate(Resources.Load<GameAssets>("GameAssets")); }

            return _fetch;
        }
    }

    public Transform pdDamagePopup;
    
}