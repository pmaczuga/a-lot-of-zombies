using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    private WaveScript waveScript;
    public GameObject enemy;
    private int amount = 0;

    private bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        waveScript = GameObject.Find("WaveManager").GetComponent<WaveScript>();
        waveScript.AddSpawner(this);
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

    public void SetAmount(int amount)
    {
        this.amount = amount;
    }
}
