using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    public int amount = 0;

    private bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (amount > 0 && canSpawn)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            amount--;
            canSpawn = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canSpawn = false;
    }

    private void OnTriggerExit(Collider other)
    {
        canSpawn = true;
    }

    private void OnTriggerStay(Collider other)
    {
        canSpawn = false;
    }

    void SetAmount(int amount)
    {
        this.amount = amount;
    }
}
