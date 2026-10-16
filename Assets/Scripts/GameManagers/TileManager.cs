using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] Transform _cameraPos;
    [SerializeField] Grid _grid;

    float _xPosition, _yPosition;

    void FixedUpdate()
    {
        _xPosition = Mathf.Round(_cameraPos.position.x / _grid.cellSize.x) * _grid.cellSize.x;
        _yPosition = Mathf.Round(_cameraPos.position.y / _grid.cellSize.y) * _grid.cellSize.y;

        transform.position = new Vector3(_xPosition, _yPosition);
    }
}
