using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook : MonoBehaviour
{
    #region Variables
    public GameObject player;
    private Transform playerpos;
    private float dist;
    public float howclose;
    #endregion
    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        playerpos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(playerpos.position, transform.position);
        //if player is within range of enemy
        if(dist <= howclose)
        {
            //looks at player
            transform.LookAt(player.transform);
        }
    }
    #endregion
}
