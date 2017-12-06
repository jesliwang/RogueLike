//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

namespace Entitas {

    public partial class Entity {

        static readonly AIComponent aIComponent = new AIComponent();

        public bool isAI {
            get { return HasComponent(CoreComponentIds.AI); }
            set {
                if(value != isAI) {
                    if(value) {
                        AddComponent(CoreComponentIds.AI, aIComponent);
                    } else {
                        RemoveComponent(CoreComponentIds.AI);
                    }
                }
            }
        }

        public Entity IsAI(bool value) {
            isAI = value;
            return this;
        }
    }
}

    public partial class CoreMatcher {

        static IMatcher _matcherAI;

        public static IMatcher AI {
            get {
                if(_matcherAI == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.AI);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherAI = matcher;
                }

                return _matcherAI;
            }
        }
    }
