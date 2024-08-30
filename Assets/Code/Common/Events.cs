using System;
using UnityEngine;

namespace Code.Common
{
    public class Events
    {
        public event Action<Vector2> MovementHandler;
        public event Action InteractHandler;
        public event Action<bool> InteractionHintStateChanged;
        public event Action<int> AidKitChanged;
        public event Action<float> HealthChanged;
        public event Action LevelRestarted;
        
        public void EventMove(Vector2 move)
        {
            MovementHandler?.Invoke(move);
        }
        
        public void EventInteract()
        {
            InteractHandler?.Invoke();
        }
        
        public void EventChangeHint(bool state)
        {
            InteractionHintStateChanged?.Invoke(state);
        }
        
        public void EventHealthChanged(float currentHealthPercent)
        {
            HealthChanged?.Invoke(currentHealthPercent);
        }
        
        public void EventAidKitChanged(int currentAidKit)
        {
            AidKitChanged?.Invoke(currentAidKit);
        }
        
        public void EventLevelRestarted()
        {
            LevelRestarted?.Invoke();
        }
    }
}