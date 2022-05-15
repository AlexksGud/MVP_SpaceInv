using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;

    public GameObject DestroyEffect; // префаб партикла

    private void Update()
    {
         transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speed,-3);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }


    public void ShowDestroy(Transform parent)
    {
        var obj = Instantiate
            (DestroyEffect,gameObject.transform.position,Quaternion.identity,parent);

        Destroy(this.gameObject);
        Destroy(obj.gameObject, 1f);
    }
}
