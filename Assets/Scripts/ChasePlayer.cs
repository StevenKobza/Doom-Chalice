using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    public Transform _player;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.destination = _player.position;
        //Debug.Log(agent.destination);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            agent.destination = _player.position;
        }
    }
}
