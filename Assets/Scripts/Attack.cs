using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] MeleeStats _mStats;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.SendMessage("ApplyMeleeDamage", _mStats.Damage, SendMessageOptions.DontRequireReceiver);
        }
    }
}
