using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AgentMove : MonoBehaviour
{
    private List<GameObject> points;
    private NavMeshAgent agent;
    private Vector3 goTo;
    // Start is called before the first frame update
    void Start()
    {
        points = new List<GameObject>();
        var locs = GameObject.FindGameObjectsWithTag("AgentLocations");
        foreach (var loc in locs)
        {
            points.Add(loc);
        }
        agent = gameObject.GetComponent<NavMeshAgent>();
        goTo = points[Random.Range(0,points.Count)].transform.position;
        agent.SetDestination(goTo);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSame())
        {
            chooseNewDest();
        }
    }
    
    Boolean isSame()
    {
        Vector3 actual = gameObject.transform.position;
        if (Math.Abs(goTo.x - actual.x) < 0.1 && Math.Abs(goTo.z - actual.z) < 0.1) return true;
        return false;
    }
    
    void chooseNewDest()
    {
        goTo = points[Random.Range(0,points.Count)].transform.position;
        agent.SetDestination(goTo);
    }
}
