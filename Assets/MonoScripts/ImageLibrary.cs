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
    public static Sprite adrenaline_art;
    public static Sprite bandage_art;
    public static Sprite ironSteelPlate_art;
    public static Sprite winchester_bullet;
    public static Sprite winchester_bullet_super;
    public static Sprite tomahawk_bullet;
    public static Sprite tomahawk_bullet_super;


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
        adrenaline_art = Resources.Load<Sprite>("CardArt/adrenalineCard");
        ironSteelPlate_art = Resources.Load<Sprite>("CardArt/ironSteelPlateCard");
        winchester_bullet = Resources.Load<Sprite>("CharSprites/WinchesterBullet");
        winchester_bullet_super = Resources.Load<Sprite>("CharSprites/WinchesterBulletSuper");
        tomahawk_bullet = Resources.Load<Sprite>("CharSprites/TomahawkPixel");
        tomahawk_bullet_super = Resources.Load<Sprite>("CharSprites/ChargedTomahawkPixel");
        bandage_art = Resources.Load<Sprite>("CardArt/bandage_art");
        DontDestroyOnLoad(gameObject);
    }
}
