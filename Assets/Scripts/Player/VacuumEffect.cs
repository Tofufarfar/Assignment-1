using UnityEngine;

public class VacuumEffect : MonoBehaviour
{
    [SerializeField] PlayerStats _pStats;


    private void Start()
    {
        
    }
    private void OnEnable()
    {
        _pStats.OnPlayerStatsChanged += IncreaseVacuumSize;
    }

    private void OnDisable()
    {
        _pStats.OnPlayerStatsChanged -= IncreaseVacuumSize;
    }

    public void IncreaseVacuumSize()
    {
        float size = _pStats.VacuumEffect;
        transform.localScale = new Vector3(size,size, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out XPGem gem))
        { 
            gem.StartMagnet(transform.parent);
        }
    }
}
