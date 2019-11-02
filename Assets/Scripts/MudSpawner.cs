using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudSpawner : MonoBehaviour
{

    public GameObject mud;
    public GameObject bystander;

    public float maxTime = 5;
    public float minTime = 2;

    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;


    public float XOffset = 50f;


    GameObject player;

    void Start()
    {
        SetRandomTime();
        time = minTime;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {

        //Counts up
        time += Time.deltaTime;
        Debug.Log(time);

        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            SpawnObject();
            SetRandomTime();
        }

    }


    //Spawns the object and resets the time
    void SpawnObject()
    {
        time = 0;
        GameObject prefab = bystander;
        if (Random.Range(0f, 1f) > 0.5f)
            prefab = mud;
        GameObject spawnedObject = Instantiate(prefab);
        spawnedObject.transform.position = player.transform.position + new Vector3(XOffset, 0f, 0f);
        //spawnedObject.transform.position = new Vector3(player.transform.position.x, -4.5f, player.transform.position.z);
        //StartCoroutine(Cleanup(spawnedObject));
    }

    IEnumerator Cleanup(GameObject gameObject) {
        const float CleanupTime = 15f;
        yield return new WaitForSeconds(CleanupTime);
        if (gameObject != null)
            Destroy(gameObject);
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
}
