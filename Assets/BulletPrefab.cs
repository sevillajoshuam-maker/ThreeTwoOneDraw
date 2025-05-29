using UnityEngine;

public class BulletPrefab : MonoBehaviour
{
    private AbstractBullet thisBullet;
    public SpriteRenderer rendr;

    private float pixelPerSecond;

    private static float pixelDistance = 11.53F;
    private static float feetDistance = 50F;
    private static float conversion = pixelDistance / feetDistance;

    private string shooter;

    public void setData(AbstractBullet bullet, string shooter){
        thisBullet = bullet;
        this.shooter = shooter;

        rendr = gameObject.GetComponent<SpriteRenderer>();
        rendr.sprite = thisBullet.bulletSprite;

        pixelPerSecond = (shooter == "PLAYER")? feetToPixel((float)thisBullet.SPEED) : -1 * feetToPixel((float)thisBullet.SPEED);
    }

    void FixedUpdate(){
        gameObject.transform.position += new Vector3(pixelPerSecond/50F, 0,0);

        if(shooter == "PLAYER" && this.transform.position.x >= EncounterControl.Instance.enemySpritePlaceholder.transform.position.x){
            Destroy(gameObject);
        }
        else if(shooter == "ENEMY" && this.transform.position.x <= EncounterControl.Instance.playerSpritePlaceholder.transform.position.x){
            Destroy(gameObject);
        }
    }  

    private static float feetToPixel(float feet){
        return feet * conversion;
    } 
}
