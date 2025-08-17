using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHP = 3f;
    public int rewardForDestroy = 1;
    private float hp;

    void Awake() => hp = maxHP;

    public bool TakeDamage(float dmg)
    {
        hp -= dmg;
        if (hp <= 0f)
        {
            
            SkyCoinCounter.Instance.AddCoin(rewardForDestroy);
            KillerCounter.Instance.AddKill(rewardForDestroy);
            Destroy(gameObject);
            return true;
        }

        return false;
    }
}
