using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] MeleeStats _mStats;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.SendMessage("ApplyDamage", _mStats.Damage, SendMessageOptions.DontRequireReceiver);
        }
    }
}
