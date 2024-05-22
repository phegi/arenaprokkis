using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathEvent : MonoBehaviour
{
    public GameObject vihu;
    public ExpCounter expcounter;
    public PlayerBehaviour playerbehaviour;
    public expBaari expBar;
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
        expcounter.UpdateExp(15); // lisaä pelaajan expinta
        playerbehaviour.LevelUp(); // chekkaa jos exp riittää leveliin
        expBar.UpdateExpBar();  // paivittää expbarin
        DestroyEnemy();
    }

    public void DestroyEnemy()  // poistaa vihun
    {
        Destroy(vihu);
    }


}
