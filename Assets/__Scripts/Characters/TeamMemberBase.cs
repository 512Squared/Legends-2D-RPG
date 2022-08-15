using UnityEngine;

public class TeamMemberBase : MonoBehaviour
{
    [SerializeField]
    private GameObject teamBase;

    [SerializeField]
    private PlayerStats playerStats;


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