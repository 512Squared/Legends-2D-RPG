using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.HeroEditor4D.Common.CharacterScripts;
using Pathfinding;
using UnityEngine;

public class NpcController : SingletonMonobehaviour<NpcController>
{
    private PlayerStats[] playerList;
    private List<PlayerStats> players;


    [SerializeField]
    private float distance;

    private void Start()
    {
        playerList = GameManager.Instance.GetPlayerStats();
        players = new List<PlayerStats>();
    }

    public Vector3 GetFormationPosition(Vector3 startPosition, string guid, Vector3 currentPosition)
    {
        players.Clear();
        for (int j = 0; j < playerList.Length; j++)
        {
            if (playerList[j].isTeamMember && playerList[j].playerName != "Thulgran")
            {
                players.Add(playerList[j]);
            }
        }

        PlayerStats[] playersInTeam = players.ToArray();

        for (int i = 0; i < playersInTeam.Length; i++)
        {
            float angle = i * (360f / players.Count);
            Vector3 dir = ApplyRotationToVector(new Vector3(1, 0), angle);
            Vector3 position = startPosition + (dir * distance);
            if (players[i].GetComponent<GenerateGUID>().GUID == guid)
            {
                return position;
            }
        }

        return currentPosition;
    }

    private static Vector3 ApplyRotationToVector(Vector3 vec, float angle)
    {
        return Quaternion.Euler(0, 0, angle) * vec;
    }
}