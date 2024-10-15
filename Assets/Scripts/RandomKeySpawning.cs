using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomKeySpawning : MonoBehaviour
{
    public Transform oB;
    public GameObject KeyOnGround;
    public GameObject Key;
    
    //Array for Transforms
    public Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        //Random Object Position Spawn
        int indexNumber = Random.Range(0, spawnPoints.Length);
        oB.position = spawnPoints[indexNumber].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Key.activeSelf == true)
        {
            KeyOnGround.SetActive(false);
        }
    }
}
