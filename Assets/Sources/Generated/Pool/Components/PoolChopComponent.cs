//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class PoolEntity {

    static readonly ChopComponent chopComponent = new ChopComponent();

    public bool isChop {
        get { return HasComponent(PoolComponentsLookup.Chop); }
        set {
            if (value != isChop) {
                if (value) {
                    AddComponent(PoolComponentsLookup.Chop, chopComponent);
                } else {
                    RemoveComponent(PoolComponentsLookup.Chop);
                }
            }
        }
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

    static Entitas.IMatcher<PoolEntity> _matcherChop;

    public static Entitas.IMatcher<PoolEntity> Chop {
        get {
            if (_matcherChop == null) {
                var matcher = (Entitas.Matcher<PoolEntity>)Entitas.Matcher<PoolEntity>.AllOf(PoolComponentsLookup.Chop);
                matcher.componentNames = PoolComponentsLookup.componentNames;
                _matcherChop = matcher;
            }

            return _matcherChop;
        }
    }
}
