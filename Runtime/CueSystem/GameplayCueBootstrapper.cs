using H2V.GameplayAbilitySystem.Components;
using UnityEngine;

namespace H2V.GameplayAbilitySystem.CueSystem
{
    public class GameplayCueBootstrapper : MonoBehaviour, IOwnerComponent
    {
        [SerializeField] private IGameplayCue[] _cuesToRegister;

        public void Init(AbilitySystemComponent asc)
        {
            var cueManager = asc.GetComponent<GameplayCueManager>();
            if (cueManager == null) return;

            if (_cuesToRegister == null) return;

            foreach (var cue in _cuesToRegister)
            {
                if (cue != null)
                    cueManager.RegisterCue(cue);
            }
        }
    }
}