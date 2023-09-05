using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlatformSTG2 : MonoBehaviour
{
    public GameObject prefabObj;
    public GameObject spawnLocation;
    private bool hasSpawned = false;
    private GameObject spawnedPlatform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(hasSpawned == false)
        {
            spawnedPlatform = Instantiate(prefabObj, spawnLocation.transform.position, Quaternion.identity);
            Debug.Log("cighuer1");
            hasSpawned = true;
        }
    }
    
    public void ResetObject()
    {
        if(hasSpawned)
        {
            Destroy(spawnedPlatform);
            hasSpawned = false;
        }
    }
}
