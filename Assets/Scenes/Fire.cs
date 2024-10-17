using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Rigidbody rb;

    public Transform muzzle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward, ForceMode.Impulse);
        Destroy(this.gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

   void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Barrel"){
            // Destroy(other.gameObject);

            var barrel = other.gameObject.GetComponent<Barrel>();
            barrel.HitCount++;

            Debug.Log($"드럼통 HITcout" + barrel.HitCount.ToString());
            Destroy(gameObject);
        }
        
    }

    // public IEnumerator DestroyBullet()
    // {
    //     yield return new WaitForSeconds(3.0f);
    //     Destroy(this);

    // }
}