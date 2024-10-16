using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameM : MonoBehaviour
{
    public float distance = 8;
    public float height = 3;
    public float dampingTrace = 20;

    public Transform targetTr;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,
                                          targetTr.position - targetTr.forward * distance + Vector3.up * height,
                                          Time.deltaTime * dampingTrace);

        transform.LookAt(targetTr.position + Vector3.up * 1.0f);
    }
}