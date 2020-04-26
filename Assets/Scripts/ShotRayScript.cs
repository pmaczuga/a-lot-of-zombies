using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotRayScript : MonoBehaviour
{
    public float timeToLive = 0.5f;

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DrawLine(Vector3 start, Vector3 end)
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        StartCoroutine(Live());
    }

    IEnumerator Live()
    {
        yield return new WaitForSeconds(timeToLive);

        Destroy(gameObject);
    }

}
