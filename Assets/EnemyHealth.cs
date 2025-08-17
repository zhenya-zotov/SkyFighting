using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHP = 3f;
    private float hp;

    void Awake() => hp = maxHP;

    public bool TakeDamage(float dmg)
    {
        hp -= dmg;
        if (hp <= 0f)
        {
            
            SkyCoinCounter.Instance.AddCoin(1);
            Destroy(gameObject);
            return true;
        }

        return false;
    }
}
