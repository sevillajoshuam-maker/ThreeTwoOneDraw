using UnityEngine;

public class AdrenalineShot : AbstractSkill
{
    public AdrenalineShot() : base("Adrenaline Shot", 2, ImageLibrary.default_card, "The next card played to this time slot goes twice as fast.") { }

    public override void use(AbstractPlayer user, float duration){
        //Change future cards for the number of future card you want it to affect.
        int futureCards = 1;
        for (int i = 0; i < futureCards; ++i) {
            //Compounds pre-existing multipliers
            if (!TimeSlot.Instance.durationMultipliers.TryAdd(TimeSlot.Instance.counter + i + 1, 0.5f)) {
            TimeSlot.Instance.durationMultipliers[TimeSlot.Instance.counter + i + 1] = TimeSlot.Instance.durationMultipliers[TimeSlot.Instance.counter + 1] * 0.5f;
            }
        }
    }
}