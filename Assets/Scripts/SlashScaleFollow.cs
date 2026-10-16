using UnityEngine;

public class SlashScaleFollow : MonoBehaviour
{
    [SerializeField] Transform _slash;
    [SerializeField, Range(1f, 1.5f)] float _sizeMultiplier = 1f;

    Vector3 _slashBase;

    void Awake() => _slashBase = _slash.localScale;

    public void SetSizeMultiplier(float m)
    {
        _sizeMultiplier = Mathf.Clamp(m, 1f, 1.5f);
    }
    
    void Update()
    {
        _slash.localScale = _slashBase * _sizeMultiplier;
    }
}
