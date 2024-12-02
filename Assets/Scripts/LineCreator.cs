using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
    [SerializeField] private GameObject LinePrefab;
    [SerializeField] private LayerMask forbiddenToDraw;

    private bool canDraw;

    Line activeLine;     

    // Update is called once per frame
    void Update()
    {
        CreateLine(); 
    }

    private void CreateLine()
        {
            if (Input.GetMouseButtonDown(0))
            {
                canDraw = CanDraw();
                    if (canDraw == false) 
                    {
                        GameObject lineGo = Instantiate(LinePrefab);
                        activeLine = lineGo.GetComponent<Line>();
                    }                
            }

            canDraw = CanDraw();
            if (Input.GetMouseButtonUp(0) | canDraw)
            {
                activeLine = null;
            }

            if (activeLine != null)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                activeLine.UpdateLine(mousePos);
            }
        }

    private bool CanDraw()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos,Vector2.zero, Mathf.Infinity, forbiddenToDraw);

        if (hit.collider == null) {return false;} 
        else {return true;}        
    }
}
