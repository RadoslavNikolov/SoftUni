namespace TheSlum.Factory
{
    using System;
    using Characters;
    using Items;

    public class CharacterFactory
    {
        public Character CreateCharacter(CharacterType characterType, string id, int x, int y, Team team)
        {
            switch (characterType)
            {
                case CharacterType.Healer: return new Healer(id, x, y, team);
                case CharacterType.Mage: return new Mage(id, x, y, team);
                case CharacterType.Warrior: return new Warrior(id, x, y, team);
                default:
                    throw new NotSupportedException("Character of this type does not esist");
            }
        } 
    }
}