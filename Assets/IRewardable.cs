using System.Collections;
using UnityEngine;

public abstract class IRewardable<QuestRewards> : MonoBehaviour
{
    public abstract void Reward(QuestRewards value);

}
