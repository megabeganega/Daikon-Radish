using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootingAi : MonoBehaviour
{
    #region variables
    public int health;
    public Behaviour EnemyAiScript;
    public Animator ChaserStalker;
    public Animator Darkness;
    #endregion
    #region methods

    void Start()
    {
        GetComponent<Animator>().enabled = true;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            //Enemy Squish
            ChaserStalker.GetComponent<Animator>().Play("deathAnimation");
            EnemyAiScript.enabled = false;
            StartCoroutine(GameWon());
        }
    }

    IEnumerator GameWon()
    {
        yield return new WaitForSeconds(5);
        Darkness.GetComponent<Animator>().Play("DarknessToLightExitBed");
        SceneManager.LoadScene("GameWon");
    }
    #endregion

 
}