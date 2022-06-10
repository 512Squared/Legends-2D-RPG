using System.Collections;
using UnityEngine;

public abstract class Rewardable<QuestRewards> : MonoBehaviour
{
    public abstract void Reward(QuestRewards value);

}
