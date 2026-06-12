using UnityEngine;
using H2V.GameplayAbilitySystem.Components;
using H2V.GameplayAbilitySystem.EffectSystem;

namespace H2V.GameplayAbilitySystem.CueSystem
{
    public struct GameplayCueParameters
    {
        public AbilitySystemComponent Source;
        public AbilitySystemComponent Target;
        public Vector3 Location;
        public float Magnitude;
        public object UserData;
        
        public static GameplayCueParameters FromEffect(GameplayEffectSpec spec, AbilitySystemComponent target)
        {
            return new GameplayCueParameters
            {
                Source = spec.Source,
                Target = target,
                Location = target.transform.position,
                Magnitude = spec.Modifiers.Length > 0 ? spec.GetModifierMagnitude(0) : 0f
            };
        }
    }
}