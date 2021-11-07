using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    public GameObject topLeft;
    public GameObject bottomRight;

    private Vector3 posTop;
    private Vector3 posBottom;
    
    // Start is called before the first frame update
    void Start()
    {
        posTop = topLeft.transform.localPosition;
        posBottom = bottomRight.transform.localPosition;
        
        print(posTop);
        print(posBottom);
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        for (;;)
        {
            GameObject obj = Instantiate(enemy,transform);

            var x = Random.Range(posTop.x, posBottom.x);
            var z = Random.Range(posBottom.z, posTop.z);
        
            Vector3 newPos = new Vector3(x,0,z);
            print(newPos);
            obj.transform.localPosition = newPos;

            float scaleYZ = obj.transform.localScale.y;
            obj.transform.localScale = new Vector3(0.4915436f,scaleYZ,scaleYZ);

            print(obj.transform.position);

            yield return new WaitForSeconds(15);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
