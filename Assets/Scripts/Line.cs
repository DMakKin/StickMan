using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private EdgeCollider2D edgCollider;
    [SerializeField] private LineRenderer lineRenderer;

    List<Vector2> points;
    public void UpdateLine(Vector2 mousePos)
    {
        if(points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePos);
            return;
        }

        if (Vector2.Distance(points.Last(), mousePos)> 0.1f)
            SetPoint(mousePos);
    }

    private void SetPoint(Vector2 point)
    {
        points.Add(point);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        edgCollider.points = points.ToArray();

    }

    private void Update()
    {        
        DestroyTheLine();
    }

    private void DestroyTheLine()
    {
        if (Input.GetButtonDown("Replay"))
        {            
            Destroy(gameObject);        
        }
    }
}
