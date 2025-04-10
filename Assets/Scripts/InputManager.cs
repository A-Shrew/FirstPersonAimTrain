using System;
using UnityEngine.Events;
using UnityEngine;
using Unity.VisualScripting;

public class InputManager : MonoBehaviour
{
    public UnityEvent OnSpacePressed = new();
    public UnityEvent OnMousePressed = new();
    public UnityEvent<Vector2> OnMove = new();
    //public UnityEvent OnResetPressed = new UnityEvent();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacePressed?.Invoke();
        }

        Vector2 input = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            input += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            input += Vector2.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            input += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            input += Vector2.down;
        }

        OnMove?.Invoke(input);

        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    OnResetPressed?.Invoke();
        //}

        if (Input.GetMouseButton(0))
        {
            OnMousePressed?.Invoke();
        }
    }
}