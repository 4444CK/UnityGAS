using UnityEngine;

namespace H2V.GameplayAbilitySystem.CueSystem
{
    [CreateAssetMenu(menuName = "H2V/Gameplay Ability System/Cues/Actor Cue")]
    public class ActorGameplayCue : ScriptableObject, IGameplayCue
    {
        [field: SerializeReference, SubclassSelector]
        public GameplayCueTagSO CueTag { get; private set; }
        
        private GameObject _spawnedInstance;
        
        public void OnExecute(GameplayCueParameters parameters) { }
        
        public void OnActive(GameplayCueParameters parameters)
        {
            if (CueTag?.LoopingEffect != null && parameters.Target != null)
            {
                _spawnedInstance = Instantiate(CueTag.LoopingEffect, parameters.Target.transform);
            }
        }
        
        public void OnRemove(GameplayCueParameters parameters)
        {
            if (_spawnedInstance != null)
                Destroy(_spawnedInstance);
        }
    }
}