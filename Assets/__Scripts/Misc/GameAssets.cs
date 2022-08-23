using UnityEngine;

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

    public GameObject skelly;
    public GameObject zombie;
    public GameObject goblin;


    public Transform pdDamagePopup;
    public GameObject crosshairs;
    public GameObject itemPrefab;
    public GameObject healingPotion;
}