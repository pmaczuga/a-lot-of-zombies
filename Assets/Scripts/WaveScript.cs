using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    private List<SpawnerScript> spawners = new List<SpawnerScript>();
    private UIScript uiScript;
    public GameObject deathScreen;
    public int[] waveSizes = { 3, 6, 12, 24, 48 };
    private int waveIndex = -1;
    private int enemiesLeft;
    // Start is called before the first frame update
    void Start()
    {
        uiScript = GameObject.Find("UIText").GetComponent<UIScript>();
        uiScript.SetTotalWaves(waveSizes.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesLeft > 0)
        {
            return;
        }
        if (waveIndex + 1 == waveSizes.Length)
        {
            deathScreen.SetActive(true);
            return;
        }
        StartCoroutine(NextWave());
    }

    IEnumerator NextWave()
    {
        waveIndex++;
        enemiesLeft = waveSizes[waveIndex];

        yield return new WaitForSeconds(5);

        Debug.Log("Wave started: " + waveIndex);
        uiScript.SetCurrentWave(waveIndex);

        int[] amountPerSpawner = new int[spawners.Count];
        int i = 0;
        while (i < waveSizes[waveIndex])
        {
            amountPerSpawner[i++ % spawners.Count]++;
        }

        for (i = 0; i < spawners.Count; i++)
        {
            spawners[i].SetAmount(amountPerSpawner[i]);
        }
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
