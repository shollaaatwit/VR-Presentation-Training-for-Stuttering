using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    LineRenderer lineRenderer;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Shoots out laser pointer for user
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            lineRenderer.SetPosition(0, this.transform.position);
            lineRenderer.SetPosition(1, hit.point);
        }
    }
}
