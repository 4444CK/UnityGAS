using UnityEngine;
using H2V.GameplayAbilitySystem.Components;
using H2V.GameplayAbilitySystem.EffectSystem.AdditionApplyEffects;

namespace H2V.GameplayAbilitySystem.CueSystem
{
    [System.Serializable]
    public class GameplayCueAddition : IAdditionApplyEffect
    {
        [SerializeField] private GameplayCueTagSO _cueOnApply;
        [SerializeField] private GameplayCueTagSO _cueOnActive;
        [SerializeField] private GameplayCueTagSO _cueOnRemove;
        
        private ActiveGameplayEffect _activeEffect;
        
        public void OnEffectSpecApplied(AbilitySystemComponent target)
        {
            var cueManager = target.GetComponent<GameplayCueManager>();
            if (cueManager == null) return;
            
            var parameters = new GameplayCueParameters
            {
                Target = target,
                Location = target.transform.position
            };
            
            if (_cueOnApply != null)
                cueManager.ExecuteCue(_cueOnApply.AssociatedTag, parameters);
            
            if (_cueOnActive != null)
                cueManager.AddActiveCue(_cueOnActive.AssociatedTag, this, parameters);
        }
        
        public void OnEffectSpecRemoved(AbilitySystemComponent target)
        {
            var cueManager = target.GetComponent<GameplayCueManager>();
            if (cueManager == null) return;
            
            if (_cueOnActive != null)
                cueManager.RemoveActiveCue(this);
            
            if (_cueOnRemove != null)
            {
                var parameters = new GameplayCueParameters { Location = target.transform.position };
                cueManager.ExecuteCue(_cueOnRemove.AssociatedTag, parameters);
            }
        }
    }
}