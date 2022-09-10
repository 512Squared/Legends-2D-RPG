using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    private List<Vector3> npcList = new();
    private List<UnitRTS> unitList = new();
    private PlayerStats[] playerList;

    private void Start()
    {
        playerList = GameManager.Instance.GetPlayerStats();
        foreach (PlayerStats player in playerList)
        {
            npcList.Add(player.transform.position);
            unitList.Add(player.GetComponent<UnitRTS>());
        }
    }

    private void MoveIntoFormation()
    {
        Vector3 moveToPosition = PlayerGlobalData.Instance.transform.position;
        List<Vector3> targetPositionList = new()
        {
            moveToPosition + new Vector3(0, 0),
            moveToPosition + new Vector3(10, 0),
            moveToPosition + new Vector3(20, 0),
            moveToPosition + new Vector3(30, 0),
            moveToPosition + new Vector3(40, 0)
        };

        foreach (UnitRTS unit in unitList.Where(unit => unit.GetComponent<PlayerStats>().isTeamMember))
        {
            unit.MoveTo(moveToPosition);
        }
    }
}