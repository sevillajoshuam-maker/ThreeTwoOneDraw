using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{

    public Enemy enemy;
    Animator animator;
    public EncounterControl encounterController;
    public bool ready = false;
    public System.Random random = new System.Random();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ready)
        {
            if ((animator != null) && (enemy != null) && encounterController != null)
            {
                ready = true;
            }
        }
        else
        {
            animator.SetInteger("IncomingBullets", BulletManager.Instance.playerBullet);
            animator.SetInteger("BulletCards", enemy.bulletCardCount);
            animator.SetInteger("SkillCards", enemy.skillCardCount);
            animator.SetInteger("DefendCards", enemy.defendCardCount);
            animator.SetFloat("Random", (float)random.NextDouble());
        }
    }

    public void SuggestType(string type)
    {
        enemy.suggestCardType(type);
    }
}
