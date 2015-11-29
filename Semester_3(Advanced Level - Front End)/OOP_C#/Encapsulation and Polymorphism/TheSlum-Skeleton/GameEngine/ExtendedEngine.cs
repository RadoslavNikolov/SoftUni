namespace TheSlum.GameEngine
{
    using System;
    using Characters;
    using Factory;

    public class ExtendedEngine : Engine
    {
         private CharacterFactory charFactory = new CharacterFactory();
        private ItemFactory itemFactory = new ItemFactory();

        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "create": this.CreateCharacter(inputParams); break;
                case "add": this.AddItem(inputParams); break;
                default : base.ExecuteCommand(inputParams); break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            string charClass = inputParams[1];
            string charName = inputParams[2];
            int x = int.Parse(inputParams[3]);
            int y = int.Parse(inputParams[4]);

            var team = (Team) Enum.Parse(typeof (Team), inputParams[5], true);
            var charType = (CharacterType) Enum.Parse(typeof (CharacterType), charClass, true);
            Character character = this.charFactory.CreateCharacter(charType, charName, x, y, team);
            this.characterList.Add(character);
        }

        protected override void AddItem(string[] inputParams)
        {
            string charId = inputParams[1];
            string itemType = inputParams[2];
            string itemId = inputParams[3];

            ItemType type = (ItemType) Enum.Parse(typeof (ItemType), itemType, true);
            Item item = this.itemFactory.CreateItem(type, itemId);

            Character character = this.GetCharacterById(charId);
            character.AddToInventory(item);
        }
    }
}