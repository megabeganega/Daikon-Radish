using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAi : MonoBehaviour
{
    #region variables
    public int health;
    #endregion
    #region methods
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            //add enemy death animation
            Destroy(gameObject);
        }
    #endregion
    }
}
