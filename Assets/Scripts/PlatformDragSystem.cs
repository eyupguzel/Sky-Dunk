using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformDragSystem : MonoBehaviour
{
    private bool onDrag;
    private GameObject _object;
    private Vector3 position;
    private void Update()
    {
        if(Input.touchCount > 0)
        {
          Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if(Physics.Raycast(ray,out hit))
                {
                    if (hit.collider.tag == "Platform")
                    {
                        _object = hit.collider.gameObject;

                        onDrag = true;
                    }
                }
            }
            else if(touch.phase == TouchPhase.Moved && onDrag)
            {
                position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.WorldToScreenPoint(_object.transform.position).z));
                position.z = 0;
                position.y = _object.transform.position.y;
                _object.transform.position = position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                onDrag = false;
            }
        }
    }
}
