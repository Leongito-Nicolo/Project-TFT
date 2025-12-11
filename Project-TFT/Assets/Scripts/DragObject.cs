using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 offset;
    private Plane dragPlane;
    private Camera cam;
    private Vector3 originalPosition;

    public LayerMask mask;
    public bool isDeployed;

    void Awake()
    {
        cam = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!GameManager.Instance.canDrag) return;

        originalPosition = transform.position;

        dragPlane = new Plane(Vector3.up, transform.position);

        Ray ray = cam.ScreenPointToRay(eventData.position);
        dragPlane.Raycast(ray, out float distance);

        Vector3 hitPoint = ray.GetPoint(distance);

        offset = transform.position - hitPoint;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!GameManager.Instance.canDrag) return;

        Ray ray = cam.ScreenPointToRay(eventData.position);

        if (dragPlane.Raycast(ray, out float distance))
        {
            Vector3 hitPoint = ray.GetPoint(distance);
            Vector3 newPosition = hitPoint + offset;

            newPosition.y = transform.position.y;

            transform.position = newPosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!GameManager.Instance.canDrag) return;

        if (Physics.Raycast(transform.position + Vector3.up * 2f, Vector3.down, 10f, mask) && Physics.OverlapSphere(transform.position, .1f).ToArray().Length == 1)
        {
            transform.position = new Vector3(
                Mathf.RoundToInt(transform.position.x - 0.5f) + 0.5f,
                transform.position.y,
                Mathf.RoundToInt(transform.position.z - 0.5f) + 0.5f
            );
            isDeployed = true;
        }
        else
        {
            transform.position = originalPosition;
        }
    }
}
