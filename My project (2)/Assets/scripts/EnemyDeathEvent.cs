using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathEvent : MonoBehaviour
{
    public GameObject vihu;
    public ExpCounter expcounter;
    public PlayerBehaviour playerbehaviour;
    void Start()
    {
        // JOS VIHU EI OLE TUNNETTU, EDELLINEN VIHU EI OLE OLEMASSA (:D)
        if (vihu.GetComponent<enemyStats>().enemyCurrentHealth <= 0)
        {
            DestroyEnemy();
        }
    }

    public void EnemyDeath() // tapahtuu kun vihu kuolee
    {
        expcounter.UpdateExp(10);
        playerbehaviour.LevelUp();
        DestroyEnemy();
    }

    public void DestroyEnemy()  // poistaa vihun
    {
        Destroy(vihu);
    }


}
