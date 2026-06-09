using UnityEngine;

namespace H2V.GameplayAbilitySystem.CueSystem
{
    [CreateAssetMenu(menuName = "H2V/Gameplay Ability System/Cues/Static Cue")]
    public class StaticGameplayCue : ScriptableObject, IGameplayCue
    {
        [field: SerializeReference, SubclassSelector]
        public GameplayCueTagSO CueTag { get; private set; }
        
        public void OnExecute(GameplayCueParameters parameters)
        {
            if (CueTag == null) return;
            
            if (CueTag.OneShotEffect != null)
            {
                var instance = Instantiate(CueTag.OneShotEffect, parameters.Location, Quaternion.identity);
                Destroy(instance, CueTag.Duration);
            }
            
            if (CueTag.Sound != null)
                AudioSource.PlayClipAtPoint(CueTag.Sound, parameters.Location, CueTag.SoundVolume);
        }
        
        public void OnActive(GameplayCueParameters parameters) { }
        public void OnRemove(GameplayCueParameters parameters) { }
    }
}