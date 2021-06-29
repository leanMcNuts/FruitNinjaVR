using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject [] spawnTest;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruit());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnFruit()
    {
        while (true)
        {
            GameObject go = Instantiate(spawnTest[UnityEngine.Random.Range(0, spawnTest.Length)]);
            Rigidbody temp = go.GetComponent<Rigidbody>();

            temp.velocity = new Vector3(0f, 5f, .5f);
            //temp.useGravity = true;

            Vector3 pos = transform.position;
            pos.x += UnityEngine.Random.Range(-1f, 1f);
            go.transform.position = pos;

            yield return new WaitForSeconds(1f);
        }
    }
}
