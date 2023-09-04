using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnhaz : MonoBehaviour
{
    public GameObject prefab;
    public GameObject spawn;
    public GameObject pos;
    public bool hasSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "spawnCheck" && hasSpawned == false)
        {
            Instantiate(prefab, spawn.transform.position, Quaternion.identity);
            hasSpawned = true;
            Debug.Log("spawned");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
