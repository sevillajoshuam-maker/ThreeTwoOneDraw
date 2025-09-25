using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class PlayerDefense : MonoBehaviour
{
    PolygonCollider2D hitBox;

    public enum DefenseType
    {
        Defend,
        Deflect
    }

    private DefenseType defenseType;

    //Retrieve the collider attached to this game object
    void Awake()
    {
        hitBox = gameObject.GetComponent<PolygonCollider2D>();
    }

    //Turn on the collider when this method is called by the DefenseManager, which is called by a card's use() method
    public void defend(DefenseType defenseType)
    {
        this.defenseType = defenseType;
        StartCoroutine(colliderActivate(0.1F));
    }

    //Destroy any bullet in the collider when it is activated
    void OnTriggerEnter2D(Collider2D other)
    {
        BulletPrefab bullet = other.GetComponent<BulletPrefab>();
        if (!(bullet.shooter is Enemy))
        {
            BulletManager.Instance.playerBullet--;
        }
        SoundManager.playSound(SoundType.Defend);

        switch (defenseType)
        {
            case DefenseType.Defend:
                //Defend code
                //If the bullet is super, the defend reverts the sprite to non-super and takes away super status
                //Otherwise, the bullet is negated
                if (bullet.isSuper)
                {
                    bullet.loseSuper();
                }
                else
                {
                    Destroy(other.gameObject);
                }
                break;
            case DefenseType.Deflect:
                //Deflect code - RETURN non supper bullets to sender, DELETE super bullets (Assuming more powerful)
                //Debug.LogFormat("Deflect activated. Owner: {0}", other.gameObject.GetComponent<BulletPrefab>().shooter.name);
                if (bullet.isSuper)
                {
                    Destroy(other.gameObject);
                }
                else
                {
                    // Change owner of bullet in order to deflect
                    bullet.switchOwnership();
                    bullet.rendr.flipX = !bullet.rendr.flipX;   // Flip the bullet to face the other direction.
                }
                break;
            default:                    // Default, shouldn't be used
                Debug.LogWarningFormat("Wrong defenseType used: {0} \nOn bullet: {1}", defenseType, other.gameObject.GetComponent<BulletPrefab>().name);
                break;
        }
    }


    //Activates collider for passed seconds (should usually be as short as possible)
    private IEnumerator colliderActivate(float num)
    {
        hitBox.enabled = true;
        yield return new WaitForSeconds(num);
        hitBox.enabled = false;
    }
}
