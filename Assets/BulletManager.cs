using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance {get; private set;}

    [SerializeField]
    private BulletPrefab bulletBlueprint;

    public void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
        }
    }

    public void fire(string shooter, AbstractBullet bullet){
        if(shooter == "PLAYER"){
            BulletPrefab newBullet = Instantiate(bulletBlueprint, 
                EncounterControl.Instance.playerSpritePlaceholder.transform.position + new Vector3(0, 0.5F, 0),Quaternion.identity) as BulletPrefab;
            newBullet.setData(bullet, shooter);
        }
        else if (shooter == "ENEMY"){
            BulletPrefab newBullet = Instantiate(bulletBlueprint, 
                EncounterControl.Instance.enemySpritePlaceholder.transform.position + new Vector3(0, 0.5F, 0),Quaternion.identity) as BulletPrefab;
            newBullet.setData(bullet, shooter);
        }
    }
}
