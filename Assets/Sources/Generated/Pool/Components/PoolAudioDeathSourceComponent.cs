//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class PoolEntity {

    public AudioDeathSourceComponent audioDeathSource { get { return (AudioDeathSourceComponent)GetComponent(PoolComponentsLookup.AudioDeathSource); } }
    public bool hasAudioDeathSource { get { return HasComponent(PoolComponentsLookup.AudioDeathSource); } }

    public void AddAudioDeathSource(Audio[] newClips, bool newRandomizePitch) {
        var index = PoolComponentsLookup.AudioDeathSource;
        var component = CreateComponent<AudioDeathSourceComponent>(index);
        component.clips = newClips;
        component.randomizePitch = newRandomizePitch;
        AddComponent(index, component);
    }

    public void ReplaceAudioDeathSource(Audio[] newClips, bool newRandomizePitch) {
        var index = PoolComponentsLookup.AudioDeathSource;
        var component = CreateComponent<AudioDeathSourceComponent>(index);
        component.clips = newClips;
        component.randomizePitch = newRandomizePitch;
        ReplaceComponent(index, component);
    }

    public void RemoveAudioDeathSource() {
        RemoveComponent(PoolComponentsLookup.AudioDeathSource);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class PoolMatcher {

    static Entitas.IMatcher<PoolEntity> _matcherAudioDeathSource;

    public static Entitas.IMatcher<PoolEntity> AudioDeathSource {
        get {
            if (_matcherAudioDeathSource == null) {
                var matcher = (Entitas.Matcher<PoolEntity>)Entitas.Matcher<PoolEntity>.AllOf(PoolComponentsLookup.AudioDeathSource);
                matcher.componentNames = PoolComponentsLookup.componentNames;
                _matcherAudioDeathSource = matcher;
            }

            return _matcherAudioDeathSource;
        }
    }
}
