using System.Collections.Generic;
using Code.Common;

namespace Code.Base
{
    public class Character
    {
        public CharacterView CharacterView => _characterView;
        public Events Events => _events;
        public readonly List<CharacterModule> CharacterModules = new(); 
    
        private CharacterView _characterView;
        private Events _events;

        public Character(CharacterView characterView, Events events)
        {
            _characterView = characterView;
            _events = events;
            CharacterModules.Add(new InteractiveModule(this));
            CharacterModules.Add(new InteractiveAidKit(this));
            CharacterModules.Add(new InteractiveEnemy(this));
            CharacterModules.Add(new CharacterParameters(this));
            CharacterModules.Add(new CharacterMoveHandler(this));
            foreach (var modules in CharacterModules)
            {
                modules.Initialize();
            }
        }
    }
}
