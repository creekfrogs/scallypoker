using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    bool isSelected;
    Vector3 mousePosition;
    Renderer renderer;
    Outline outline;

    private void Awake()
    {
        outline = GetComponent<Outline>();
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        //Debug
        if (Input.GetKeyDown(KeyCode.F))
            Flip();
    }

    #region Interaction
    private void OnMouseEnter()
    {
        outline.enabled = true;
        isSelected = true;
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
        isSelected = false;
    }
    #endregion

    #region Draggable
    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }
    #endregion

    #region Flip
    public void Flip()
    {
        if(isSelected)
            transform.Rotate(0, 0, 180, Space.World);
    }
    #endregion
}
