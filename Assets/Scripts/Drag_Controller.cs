using UnityEngine;

public class Drag_Controller : MonoBehaviour
{

    private bool _isDragActive = false;
    private Vector2 _screenPosition;
    private Vector3 _worldPosition;
    private Draggable _lastDragged;

    // Update is called once per frame
    void Awake()
    {

    }

    void Update()
    {
        if (_isDragActive && (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            Drop();
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePose = Input.mousePosition;
            _screenPosition = new Vector2(mousePose.x, mousePose.y);
        }
        else if (Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else { return; }

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if (_isDragActive)
        {
            Drag();
        }

        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    _lastDragged = draggable;
                    InitDrag();
                }
            }
        }

        void InitDrag()
        {
            _isDragActive = true;
        }

        void Drag()
        {
            _lastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
        }

        void Drop()
        {
            _isDragActive = false;
        }
    }
}
