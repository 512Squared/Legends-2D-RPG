using Assets.HeroEditor4D.Common.CharacterScripts;
using UnityEngine;

public class TeamMemberBase : MonoBehaviour
{
    [SerializeField]
    private GameObject teamBase;
    
    
    [SerializeField]
    private PlayerStats playerStats;

    [SerializeField]
    private Character4D character4D;

   public Movement movement;


    private void Start()
    {
        teamBase.SetActive(playerStats.isTeamMember);
    }
    
    public void IsTeamMember(bool isTeamMember)
    {
        playerStats.isTeamMember = isTeamMember;
        teamBase.SetActive(playerStats.isTeamMember);
    }

    private void Update()
    {
        transform.position = playerStats.transform.position; 
    }
}