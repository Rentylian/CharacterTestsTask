using UnityEngine;

namespace Code.Base
{
    public class CharacterParameters : CharacterModule
    {
        private int _aidKit;
        private int _aidKitMaxValue;
        private float _health = 100;
        private float _healthMaxValue = 100;
        private readonly Character _character;
        
        public CharacterParameters(Character character)
        {
            _character = character;
        }
        
        public override void Initialize()
        {
            _health = _healthMaxValue;
        }

        public void ChangeHealth(float healthPoint)
        {
            _health = Mathf.Clamp(_health, 0, _healthMaxValue);
            if (_health > Mathf.Abs(healthPoint))
            {
                _health += healthPoint;
            }
            else
            {
                _health = 0;
                _character.Events.EventLevelRestarted();
            }
            _character.Events.EventHealthChanged(GetCurrentPercentHealth());
        }

        private float GetCurrentPercentHealth()
        {
            return _health / _healthMaxValue * 100;
        }
        
        public void IncreaseAidCount(int count)
        {
            _aidKit += count;
            _character.Events.EventAidKitChanged(_aidKit);
        }
    }
}