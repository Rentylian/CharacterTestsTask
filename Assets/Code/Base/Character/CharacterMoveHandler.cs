namespace Code.Base
{
    public class CharacterMoveHandler : CharacterModule
    {
        private readonly Character _character;
        
        public CharacterMoveHandler(Character character)
        {
            _character = character;
        }
        
        public override void Initialize()
        {
            _character.Events.MovementHandler += _character.CharacterView.Move;
        }
    }
}