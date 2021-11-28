using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AgentMove : MonoBehaviour
{
    private List<GameObject> destinations;
    private NavMeshAgent agent;
    private Vector3 destinationPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        destinations = new List<GameObject>(GameObject.FindGameObjectsWithTag("AgentLocations"));
        agent = gameObject.GetComponent<NavMeshAgent>();
        
        ChooseNewDestination();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AgentLocations"))
        {
            float distance = ManhattanDistanceXZ(destinationPosition, other.transform.position);
            if (distance <= 0.2)
            {
                ChooseNewDestination();
            }
        }
    }

    void ChooseNewDestination()
    {
        destinationPosition = destinations[Random.Range(0,destinations.Count)].transform.position;
        agent.SetDestination(destinationPosition);
    }

    float ManhattanDistanceXZ(Vector3 a, Vector3 b)
    {
        return Math.Abs(a.x - b.x) + Math.Abs(a.z - b.z);
    }
}
