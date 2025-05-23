using UnityEngine;

public class ImageLibrary : MonoBehaviour
{

    public static Sprite take_aim_concept_art;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        take_aim_concept_art = Resources.Load<Sprite>("CardArt/Take_Aim_Concept");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
