using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    public GameObject fireParticleSystem;
    public GameObject waterParticleSystem;
    public GameObject smokeParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch(String keyword)
    {
        if (keyword.Equals("fire"))
        {   
            DisableAllSystems();
            fireParticleSystem.SetActive(true);

        } else if (keyword.Equals("water"))
        {
            DisableAllSystems();
            waterParticleSystem.SetActive(true);
        } else if (keyword.Equals("smoke"))
        {
            DisableAllSystems();
            smokeParticleSystem.SetActive(true);
        }
    }

    private void DisableAllSystems()
    {
        fireParticleSystem.SetActive(false);
        waterParticleSystem.SetActive(false);
        smokeParticleSystem.SetActive(false);
    }
}
