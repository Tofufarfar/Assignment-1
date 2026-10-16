using UnityEngine;

public class TileChunkRecycle : MonoBehaviour
{
    [SerializeField] Transform _player;
    public float MapSize = 80;
    float _halfSize;
    void Start()
    {
        _halfSize = MapSize / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;

        if (_player.position.x - newPos.x > _halfSize) newPos.x += MapSize;
        else if (newPos.x - _player.position.x > _halfSize) newPos.x -= MapSize;

        if (_player.position.y - newPos.y > _halfSize) newPos.y += MapSize;
        else if (newPos.y - _player.position.y > _halfSize) newPos.y -= MapSize;

        transform.position = newPos;
    }
}
