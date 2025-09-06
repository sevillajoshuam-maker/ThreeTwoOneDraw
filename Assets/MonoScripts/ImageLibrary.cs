using UnityEngine;

public class ImageLibrary : MonoBehaviour
{

    public static Sprite takeAim_art;
    public static Sprite sixShooter_art;
    public static Sprite defend_art;
    public static Sprite default_bullet_concept_art;
    public static Sprite default_superBullet_concept_art;
    public static Sprite default_card;
    public static Sprite dynamite_art;
    public static Sprite tomahawk_art;
    public static Sprite winchester_art;


    //Created static Sprites for all images located in the CardArt folder 
    void Awake()
    {
        takeAim_art = Resources.Load<Sprite>("CardArt/TakeAim_2");
        sixShooter_art = Resources.Load<Sprite>("CardArt/SixShooter_2");
        defend_art = Resources.Load<Sprite>("CardArt/Defend_2");
        default_bullet_concept_art = Resources.Load<Sprite>("CharSprites/SixShooter");
        default_superBullet_concept_art = Resources.Load<Sprite>("CharSprites/TakeAimSixShooter");
        default_card = Resources.Load<Sprite>("CardArt/default_card");
        dynamite_art = Resources.Load<Sprite>("CardArt/dynamiteCard");
        tomahawk_art = Resources.Load<Sprite>("CardArt/tomahawkCard");
        winchester_art = Resources.Load<Sprite>("CardArt/WinchRifleCard");
    }
}
