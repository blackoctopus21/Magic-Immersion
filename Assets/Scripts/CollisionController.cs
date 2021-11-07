using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{


    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        var controller = other.GetComponent<EnemyController>();
        if (controller != null)
        {
            if (controller.state == EnemyController.State.FIRE && name == "FlameThrower") controller.IsHit();
            if (controller.state == EnemyController.State.WATER && name == "Shower") controller.IsHit();
            if (controller.state == EnemyController.State.SMOKE && name == "SmokeEffect") controller.IsHit();
            //Debug.Log("collide");
        }
    }
}
