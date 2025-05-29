using UnityEngine;

public class ImageLibrary : MonoBehaviour
{

    public static Sprite take_aim_concept_art;
    public static Sprite dark_take_aim_concept_art;
    public static Sprite default_bullet_concept_art;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        take_aim_concept_art = Resources.Load<Sprite>("CardArt/Take_Aim_Concept");
        dark_take_aim_concept_art = Resources.Load<Sprite>("CardArt/Take_Aim_Concept_2");
        default_bullet_concept_art = Resources.Load<Sprite>("CardArt/bullet_concept");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
