using UnityEngine;

public class ImageLibrary : MonoBehaviour
{

    public static Sprite take_aim_concept_art;
    public static Sprite dark_take_aim_concept_art;
    public static Sprite default_bullet_concept_art;

    //Created static Sprites for all images located in the CardArt folder 
    void Awake()
    {
        take_aim_concept_art = Resources.Load<Sprite>("CardArt/Take_Aim_Concept");
        dark_take_aim_concept_art = Resources.Load<Sprite>("CardArt/Take_Aim_Concept_2");
        default_bullet_concept_art = Resources.Load<Sprite>("CardArt/bullet_concept");
    }
}
