using UnityEngine;
using H2V.GameplayAbilitySystem.TagSystem.ScriptableObjects;

namespace H2V.GameplayAbilitySystem.CueSystem
{
    [CreateAssetMenu(menuName = "H2V/Gameplay Ability System/Cues/GameplayCue Tag")]
    public class GameplayCueTagSO : ScriptableObject
    {
        [field: SerializeField, Tooltip("Associated gameplay tag (must start with GameplayCue.)")]
        public TagSO AssociatedTag { get; private set; }
        
        [field: SerializeField, Tooltip("For Instant effects - one shot VFX/SFX")]
        public GameObject OneShotEffect { get; private set; }
        
        [field: SerializeField, Tooltip("For Duration effects - looping VFX/SFX")]
        public GameObject LoopingEffect { get; private set; }
        
        [field: SerializeField] public AudioClip Sound { get; private set; }
        [field: SerializeField] public float SoundVolume { get; private set; } = 1f;
        [field: SerializeField] public float CameraShake { get; private set; } = 0f;
        [field: SerializeField] public float Duration { get; private set; } = 2f;
    }
}