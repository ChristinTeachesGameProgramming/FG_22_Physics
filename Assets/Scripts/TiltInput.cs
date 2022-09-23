using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TiltInput : MonoBehaviour
{
    [SerializeField] private float _force = 5f;

    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        var mousePosition = Input.mousePosition;

        var castPoint = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            Debug.Log(hit.point);
            _rigidBody.angularVelocity = Vector3.zero;
            _rigidBody.AddForceAtPosition(Vector3.down * _force, hit.point);
        }
    }
}
