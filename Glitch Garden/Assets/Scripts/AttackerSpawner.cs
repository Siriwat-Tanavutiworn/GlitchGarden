using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] int countOfEnemy = 5;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefeb;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        var randomEnemy = Random.Range(0, attackerPrefeb.Length);
        Spawn(attackerPrefeb[randomEnemy]);
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
