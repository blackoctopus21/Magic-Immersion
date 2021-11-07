using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PositionFixer : MonoBehaviour
{

    public List<GameObject> children; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fixPosition()
    {
        Camera camera = Camera.main;
        Transform pos = GetComponent<Transform>();
        GameObject obj = new GameObject("Anchor");
        transform.position = pos.position;
        transform.rotation = pos.rotation;
        obj.transform.parent = camera.transform;

        //prenastavit deti
        

        while (transform.childCount != 0)
        {
            Transform child = transform.GetChild(0);
            print(child.name);
            child.parent = obj.transform;
        }

        //gameObject.SetActive(false);
    }
}
