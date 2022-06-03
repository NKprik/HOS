using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;

    public Transform player;
    public Transform spawnPoint;
    public int spwaDelay = 2;
    void Start()
    {
        if ( gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    public IEnumerator RespawnPlayer ()
    {
        yield return new WaitForSeconds(spwaDelay);

        Instantiate(player, spawnPoint.position, spawnPoint.rotation);
    }

    public static void KillPlayer (PlayerCombat player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }
    
}
