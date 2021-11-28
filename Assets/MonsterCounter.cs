using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCounter : MonoBehaviour
{
    private Spawner spawner;

    private List<GameObject> monsters;

    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("SpawnPlatform").GetComponent<Spawner>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        monsters = spawner.monsters;
        text.text = "Monsters: " + monsters.Count + " / 10";
    }
}
