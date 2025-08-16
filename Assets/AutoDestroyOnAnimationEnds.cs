using UnityEngine;

public class AutoDestroyOnAnimationEnds : MonoBehaviour
{
    [SerializeField] float extraDelay = 0f; 
    Animator anim;

    void Awake() => anim = GetComponent<Animator>();

    void Update()
    {
        var st = anim.GetCurrentAnimatorStateInfo(0);
        if (!anim.IsInTransition(0) && st.normalizedTime >= 1f)
        {
            Destroy(gameObject, extraDelay);
        }
    }
}
