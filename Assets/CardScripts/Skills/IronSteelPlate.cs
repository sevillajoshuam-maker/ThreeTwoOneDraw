using UnityEngine;


public class IronSteelPlate : AbstractSkill
{  
    public IronSteelPlate() : base("Iron Steel Plate", 4, ImageLibrary.ironSteelPlate_art, "Take 20% less damage from the next three bullets") { }

    public override void use(AbstractPlayer user, float duration, TimeSlot slot)
    {
        for(int i = 0; i < 3; i++){
            user.incomingDamageMods.Enqueue(0.8);
        }
    }
}