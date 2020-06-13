using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    private List<SpawnerScript> spawners = new List<SpawnerScript>();
    private UIScript uiScript;
    public int waveSize = 3;
    public double waveMultiplier = 1.5;
    private int waveIndex = -1;
    private int enemiesLeft;
    private bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        uiScript = GameObject.Find("UIText").GetComponent<UIScript>();
    }

    // Update is called once per frame
    void Update()
    {
        uiScript.SetNumZombies(enemiesLeft);
        if (!pause && enemiesLeft == 0)
        {
            StartCoroutine(NextWave());
        }
    }

    IEnumerator NextWave()
    {
        pause = true;
        yield return new WaitForSeconds(5);

        waveIndex++;
        enemiesLeft = waveSize;

        pause = false;

        Debug.Log("Wave started: " + waveIndex);

        uiScript.SetCurrentWave(waveIndex);

        int[] amountPerSpawner = new int[spawners.Count];
        int i = 0;
        while (i < waveSize)
        {
            amountPerSpawner[i++ % spawners.Count]++;
        }

        for (i = 0; i < spawners.Count; i++)
        {
            spawners[i].SetAmount(amountPerSpawner[i]);
        }
        waveSize = (int)Math.Ceiling(waveSize * waveMultiplier);
    }

    public void AddSpawner(SpawnerScript spawner)
    {
        spawners.Add(spawner);
    }

    public void NotifyEnemyKilled()
    {
        enemiesLeft = Interlocked.Decrement(ref enemiesLeft);
    }
}
