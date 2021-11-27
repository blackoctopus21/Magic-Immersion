using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public State state;
    public Material fire;
    public Material water;
    public Material smoke;
    
    private int lives;
    public enum State
    {
        WATER,
        FIRE,
        SMOKE
    }
    // Start is called before the first frame update
    void Start()
    {
        state = (State) Random.Range(0, 3);
        lives = Random.Range(2, 5);
        SetUpEnemy();
        
        print("BEHOLDER POS " + transform.position + " " + Camera.main.WorldToScreenPoint(transform.position));
    }

    void SetUpEnemy()
    {
        ChangeColor();
        ChangeLayer();
    }

    void ChangeColor()
    {
        var cubeRenderer = gameObject.GetComponentInChildren(typeof(SkinnedMeshRenderer));
        var mesh = cubeRenderer.GetComponent<SkinnedMeshRenderer>();
        var color = "_Color";
        if (state == State.FIRE) mesh.material = fire;
        if (state == State.WATER) mesh.material = water;
        if (state == State.SMOKE) mesh.material = smoke;
    }

    public void IsHit()
    {
        State previousState = state;
        state = (State) Random.Range(0, 3);

        while (previousState == state)
        {
            state = (State) Random.Range(0, 3);
        }
        lives -= 1;
        if (lives < 1)
        {
            //Tu ho dame prec zo spawnera
            GameObject.Find("SpawnPlatform").GetComponent<Spawner>().monsters.Remove(gameObject);
            Destroy(gameObject);
        }
        else
        {
            SetUpEnemy();
        }
    }

    void ChangeLayer()
    {
        if (state == State.FIRE) gameObject.layer = 12;
        if (state == State.WATER) gameObject.layer = 13;
        if (state == State.SMOKE) gameObject.layer = 14;
    }
}
