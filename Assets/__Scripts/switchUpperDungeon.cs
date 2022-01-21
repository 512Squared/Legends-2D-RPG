using UnityEngine;

public class switchUpperDungeon : MonoBehaviour
{
   

    void onTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerGlobalData>())
        {
            Debug.Log("TestTileWorking?");

        }
    }


}