using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 649
public class RotateObject : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    [SerializeField] private ScrollRect mainScrollRect;

    private Transform modelTransform;
    private Vector3 mouseReference;
    private Vector3 mouseOffset;
    private Vector3 rotation = Vector3.zero;
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
            mouseOffset = (Input.mousePosition - mouseReference);
            rotation.y = -(mouseOffset.x + mouseOffset.y) * sensitivity;
            modelTransform.Rotate(rotation);
            mouseReference = Input.mousePosition;
        }
    }

    void OnMouseDown()
    {
        _isRotating = true;
        mouseReference = Input.mousePosition;
    }

    void OnMouseUp()
    {
        _isRotating = false;
    }
}
