using UnityEngine;
using System.Collections;
using Pathfinding;

[HelpURL("http://arongranberg.com/astar/docs/class_patrol_example.php")]
public class Patrol : MonoBehaviour {
    
    public Transform[] targets;

    int index;

    IAstarAI agent;

    void Awake () {
        agent = GetComponent<IAstarAI>();
    }

    void Update () {
        if (targets.Length == 0) return;

        bool search = false;

        // Check if the agent has reached the current target.
        // We must check for 'pathPending' because otherwise we might
        // detect that the agent has reached the *previous* target
        // because the new path has not been calculated yet.
        if (agent.reachedEndOfPath && !agent.pathPending) {
            index = index + 1;
            search = true;
        }

        // Wrap around to the start of the targets array if we have reached the end of it
        index = index % targets.Length;
        agent.destination = targets[index].position;

        // Immediately calculate a path to the target.
        // Note that this needs to be done after setting the destination.
        if (search) agent.SearchPath();
    }
}