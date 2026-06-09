namespace H2V.GameplayAbilitySystem.CueSystem
{
    public interface IGameplayCue
    {
        GameplayCueTagSO CueTag { get; }
        void OnExecute(GameplayCueParameters parameters);
        void OnActive(GameplayCueParameters parameters);
        void OnRemove(GameplayCueParameters parameters);
    }
}