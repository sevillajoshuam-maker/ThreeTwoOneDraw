using UnityEngine;

public class BulletPrefab : MonoBehaviour
{
    private AbstractBullet thisBullet;
    public SpriteRenderer rendr;

    private float pixelPerSecond;

    //The length of the field in pixels and feet
    private static float pixelDistance = 11.53F;
    private static float feetDistance = 50F;
    private static float conversion = pixelDistance / feetDistance;

    private AbstractPlayer shooter;

    //Assigns this bullet based on the passed argument.
    //Assigns the speed and bullet sprite based on bullet type (speed is negative is it is the enemy firing)
    public void setData(AbstractBullet bullet, AbstractPlayer shooter){
        thisBullet = bullet;
        this.shooter = shooter;

        rendr = gameObject.GetComponent<SpriteRenderer>();
        rendr.sprite = thisBullet.bulletSprite;

        pixelPerSecond = !(shooter is Enemy)? feetToPixel((float)thisBullet.SPEED) : -1 * feetToPixel((float)thisBullet.SPEED);
    }

    //Calls this update every 0.02 seconds.
    //Moves the bullet by the speed and destroys the bullet when it hits its target
    void FixedUpdate(){
        gameObject.transform.position += new Vector3(pixelPerSecond/50F, 0,0);

        if(!(shooter is Enemy) && this.transform.position.x >= EncounterControl.Instance.enemySpritePlaceholder.transform.position.x){
            EncounterControl.Instance.currEnemy.takeDamage(thisBullet.DAMAGE);
            Destroy(gameObject);
            if(EncounterControl.Instance.currEnemy.health == 0){
                EncounterControl.Instance.endEncounter(EncounterControl.Instance.currPlayer);
            }
        }
        else if((shooter is Enemy) && this.transform.position.x <= EncounterControl.Instance.playerSpritePlaceholder.transform.position.x){
            EncounterControl.Instance.currPlayer.takeDamage(thisBullet.DAMAGE);
            Destroy(gameObject);
            if(EncounterControl.Instance.currPlayer.health == 0){
                EncounterControl.Instance.endEncounter(EncounterControl.Instance.currEnemy);
            }
        }
    }  

    //Converts feet to actual pixel
    private static float feetToPixel(float feet){
        return feet * conversion;
    } 
}
