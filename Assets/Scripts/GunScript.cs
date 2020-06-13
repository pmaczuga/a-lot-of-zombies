using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public int damage = 10;
    public float range = 5;
    public float angle = 10.0f;
    public int shotsCount = 1;
    public GameObject shotRay;
    public AudioClip gunShotSound;

    protected Transform gunEnd;
    protected AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        gunEnd = transform.Find("GunEnd");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(gunEnd.position, -transform.up);
        if (PauseMenu.GameIsPaused == false && Input.GetButtonDown("Fire1"))
        {
            audioSource.PlayOneShot(gunShotSound);
            for (int i = 0; i < shotsCount; i++)
            {
                RaycastHit hit;
                Vector3 dir = -transform.up;
                dir = Quaternion.Euler(0, Random.Range(-angle, angle), 0) * dir;
                ShotRayScript shotRayInstance = Instantiate(shotRay, gunEnd.position, Quaternion.identity).GetComponent<ShotRayScript>();
                if (Physics.Raycast(gunEnd.position, dir, out hit, range))
                {
                    shotRayInstance.DrawLine(gunEnd.position, hit.point);
                    if (hit.collider.gameObject.tag == "Enemy")
                    {
                        CharachterBehaviour cb = hit.collider.gameObject.GetComponent<CharachterBehaviour>();
                        cb.ApplyDamage(damage);
                    }
                }
                else
                {
                    shotRayInstance.DrawLine(gunEnd.position, gunEnd.position + dir * range);
                }
            }
        }
    }
}
