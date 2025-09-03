using UnityEngine;


public class Grenade : AbstractSkill
{
    private const int Damage = 20;
    
    public Grenade() : base("Grenade", 5, ImageLibrary.takeAim_art, "Deal 20 damage to both yourself and the enemy.") { }

    public override void use(AbstractPlayer user, float duration)
    {
        EncounterControl.Instance.currPlayer.takeDamage(Damage);
        EncounterControl.Instance.currEnemy.takeDamage(Damage);
    }
}