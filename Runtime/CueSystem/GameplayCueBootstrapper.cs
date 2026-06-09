using UnityEngine;
using H2V.GameplayAbilitySystem.Components;

namespace H2V.GameplayAbilitySystem.CueSystem
{
    public class GameplayCueBootstrapper : MonoBehaviour, IOwnerComponent
    {
        [SerializeField] private IGameplayCue[] _cuesToRegister;
        
        public void Init(AbilitySystemComponent asc)
        {
            var cueManager = asc.GetComponent<GameplayCueManager>();
            if (cueManager == null) return;
            
            if (_cuesToRegister != null)
            {
                foreach (var cue in _cuesToRegister)
                    cueManager.RegisterCue(cue);
            }
        }
        
        private void OnValidate()
        {
            if (_cuesToRegister != null && _cuesToRegister.Length > 0) return;
            _cuesToRegister = Resources.LoadAll<IGameplayCue>("GameplayCues");
        }
    }
}