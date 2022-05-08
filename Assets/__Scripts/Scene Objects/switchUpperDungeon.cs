using UnityEngine;

public class SwitchUpperDungeon : MonoBehaviour
{
    private te void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerGlobalData>())
        {
            Debug.Log("TestTileWorking?);
        }
   
}