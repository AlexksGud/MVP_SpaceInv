using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private ParticleSystem shotEffect;
    [SerializeField] private Transform shotPosition;
    [SerializeField] private  float fireRate = 0.5f;

    private bool reload=false;
   
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !reload)
        {
            StartCoroutine(NextShotTimer());
            Instantiate(bulletPrefab,shotPosition.position,Quaternion.identity);
            shotEffect.Play();
           
            


        }
    }
    IEnumerator NextShotTimer()
    {
        reload = true;
        yield return new WaitForSecondsRealtime(fireRate);
        reload = false;
    }


}



