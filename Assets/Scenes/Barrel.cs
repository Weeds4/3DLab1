using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField ] private Material[] BarreMaterials;

    public int HitCount =0;

    private MeshRenderer _meshRenderer;
    private Material _selectedMaterial = null;

    public void Start(){
        int MaterialSize = BarreMaterials.Length;
        int Selectedndex = UnityEngine.Random.Range(0,MaterialSize);

        _selectedMaterial = BarreMaterials[Selectedndex];
        
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
        _meshRenderer.material = _selectedMaterial;
    }

    public void OnHitBullet(){
        HitCount++;
    }

    public void Update(){
        if(HitCount >= 5){
            Collider[] colls = Physics.OverlapSphere(transform.position,10f); 

            foreach(Collider coll in colls){
                Rigidbody rb = coll.GetComponent<Rigidbody>();
                if(rb != null){
                    rb.AddExplosionForce(1000f, transform.position, 10f, 300f);
                }
            }
        }
    }

}
