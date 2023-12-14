using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    private PlayerInput _input;
    private Camera _camera;
    private float _xBoard = 8.2f;
    private float _yBoard = 4.3f;
    private float _speed = 15;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _camera = Camera.main;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 nextPosition = _camera.ScreenToWorldPoint(_input.MousePosition);
        nextPosition.x = SetBoards(nextPosition.x, _xBoard);
        nextPosition.y = SetBoards(nextPosition.y, _yBoard);
        transform.position = Vector2.MoveTowards(transform.position, nextPosition, _speed * Time.deltaTime);
    }

    private float SetBoards(float nextPosition, float board)
    {
        return Mathf.Clamp(nextPosition, -board, board);
    }
}
