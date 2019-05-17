using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateObject : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity = 1f;

    [SerializeField] private ScrollRect mainScrollRect;
    [SerializeField] private Transform modelTransform;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation = Vector3.zero;
    private bool _isRotating;

    private void Awake()
    {
        modelTransform = gameObject.transform.GetChild(0);
    }

    void Update()
    {
        mainScrollRect.enabled = !_isRotating;
        if (_isRotating)
        {
            _mouseOffset = (Input.mousePosition - _mouseReference);
            _rotation.y = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;
            modelTransform.Rotate(_rotation);
            _mouseReference = Input.mousePosition;
        }
    }

    void OnMouseDown()
    {
        _isRotating = true;
        _mouseReference = Input.mousePosition;
    }

    void OnMouseUp()
    {
        _isRotating = false;
    }
}
