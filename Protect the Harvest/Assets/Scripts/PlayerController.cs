using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if(Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            var horizontalMove = touch.deltaPosition.x;
            print("horizontalMove: " + horizontalMove);
            var movement = new Vector3(horizontalMove, 0f, 0f) * (moveSpeed * Time.deltaTime);

            transform.Translate(movement);
        }
    }

}