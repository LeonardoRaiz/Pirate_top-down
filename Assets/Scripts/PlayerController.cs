using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D theRB;
    private Vector2 _direction;

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        OnInput();
        FollowMouse();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    private void OnMove()
    {
        theRB.MovePosition(theRB.position + _direction * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _direction.Normalize();
    }

    private void FollowMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3 shipPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - shipPos.x;
        mousePos.y = mousePos.y - shipPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

    }
}
