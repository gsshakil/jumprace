using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineIndicator : MonoBehaviour
{
    private LineRenderer lr;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if(Physics.Raycast(transform.position, transform.up * -1, out RaycastHit hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, new Vector3(0, hit.distance, 0));
            } else
            {
                lr.SetPosition(1, new Vector3(0, -100,0));
            }
        }
    }
}
