using System.Collections.Generic;
using UnityEngine;
using H2V.GameplayAbilitySystem.Components;
using H2V.GameplayAbilitySystem.EffectSystem;

namespace H2V.GameplayAbilitySystem.CueSystem
{
    public class GameplayCueManager : MonoBehaviour, IOwnerComponent
    {
        private AbilitySystemComponent _asc;
        private Dictionary<TagSystem.ScriptableObjects.TagSO, IGameplayCue> _cueRegistry = new();
        private Dictionary<ActiveGameplayEffect, IGameplayCue> _activeActorCues = new();
        
        public void Init(AbilitySystemComponent abilitySystemComponent)
        {
            _asc = abilitySystemComponent;
        }
        
        public void RegisterCue(IGameplayCue cue)
        {
            if (cue?.CueTag?.AssociatedTag != null && !_cueRegistry.ContainsKey(cue.CueTag.AssociatedTag))
                _cueRegistry[cue.CueTag.AssociatedTag] = cue;
        }
        
        public void ExecuteCue(TagSystem.ScriptableObjects.TagSO cueTag, GameplayCueParameters parameters)
        {
            if (_cueRegistry.TryGetValue(cueTag, out var cue))
                cue.OnExecute(parameters);
        }
        
        public void AddActiveCue(TagSystem.ScriptableObjects.TagSO cueTag, ActiveGameplayEffect effect, GameplayCueParameters parameters)
        {
            if (_cueRegistry.TryGetValue(cueTag, out var cue))
            {
                cue.OnActive(parameters);
                _activeActorCues[effect] = cue;
            }
        }
        
        public void RemoveActiveCue(ActiveGameplayEffect effect)
        {
            if (_activeActorCues.TryGetValue(effect, out var cue))
            {
                cue.OnRemove(default);
                _activeActorCues.Remove(effect);
            }
        }
    }
}