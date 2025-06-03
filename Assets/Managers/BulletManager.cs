using UnityEngine;

public class BulletManager : MonoBehaviour
{
    //Create a single, static instance of this manager that will be referenced 
    public static BulletManager Instance {get; private set;}

    [SerializeField]
    private BulletPrefab bulletBlueprint;

    //If the instance is the first one, it becomes the Instance.
    //Otherwise is is destroyed
    public void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
        }
    }

    //Creates a new bullet prefab depending of the type of bullet and who fired
    public void fire(string shooter, AbstractBullet bullet, Enemy enemy){

        //Spawns the bullet on the head of the player
        if(shooter == "PLAYER"){
            BulletPrefab newBullet = Instantiate(bulletBlueprint, 
                EncounterControl.Instance.playerSpritePlaceholder.transform.position + new Vector3(0, 0.5F, 0),Quaternion.identity) as BulletPrefab;
            newBullet.setData(bullet, shooter, enemy);
        }

        //Spawns the bullet on the head of the enemy
        else if (shooter == "ENEMY"){
            BulletPrefab newBullet = Instantiate(bulletBlueprint, 
                EncounterControl.Instance.enemySpritePlaceholder.transform.position + new Vector3(0, 0.5F, 0),Quaternion.identity) as BulletPrefab;
            newBullet.setData(bullet, shooter, enemy);
        }
    }
}
