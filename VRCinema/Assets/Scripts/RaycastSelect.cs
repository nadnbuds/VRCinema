using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RaycastSelect : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Update ()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.forward), Mathf.Infinity);
        if (hit)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Button clickHandler = hit.collider.gameObject.GetComponent<Button>();
            Vector3[] pos = new Vector3[] { transform.position, hit.transform.position };
            lineRenderer.enabled = true;
            lineRenderer.SetPositions(pos);
            if (OVRInput.GetDown(OVRInput.Button.Any))
            {
                if (clickHandler != null)
                {
                    clickHandler.onClick.Invoke();
                }
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}
