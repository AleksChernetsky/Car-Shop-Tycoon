using UnityEngine;
using UnityEngine.EventSystems;

public class CameraHandling : MonoBehaviour
{
    private Vector2 _worldStartPoint;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch currentTouch = Input.GetTouch(0);

            if (currentTouch.phase == TouchPhase.Began)
            {
                _worldStartPoint = GetWorldPoint(currentTouch.position);
            }

            if (currentTouch.phase == TouchPhase.Moved)
            {
                Vector2 worldDelta = GetWorldPoint(currentTouch.position) - _worldStartPoint;
                Camera.main.transform.Translate(-worldDelta.x, -worldDelta.y, 0);
            }
        }
    }

    private Vector2 GetWorldPoint(Vector2 screenPoint)
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(screenPoint), out hit);
        return hit.point;
    }
}
