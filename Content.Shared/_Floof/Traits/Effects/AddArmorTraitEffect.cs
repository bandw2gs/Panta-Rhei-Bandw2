using System.Linq;
using Content.Shared._DV.Traits.Effects;
using Content.Shared.Damage.Prototypes;
using Content.Shared.Damage.Components;
using Content.Shared.FixedPoint;
using Content.Shared.Mobs;
using Content.Shared.StatusIcon;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype.List;
using Content.Shared.Damage.Systems;

namespace Content.Shared._Floof.Traits.Effects;


/// <summary>
///     Used for traits that add a DamageModiferSet.
/// </summary>
public sealed partial class AddArmorTraitEffect : BaseTraitEffect
{

    [Dependency] private readonly DamageableSystem _damageable = default!;
    /// <summary>
    ///     The prototype ID of DamageModifierSets to replace the enumerable damage modifiers of an entity.
    /// </summary>
    [DataField]
    public ProtoId<DamageModifierSetPrototype> DamageModifierSet = "HeavyDermalArmor";

    public override void Apply(TraitEffectContext ctx)
    {
        Log.Warning($"Entity {ctx.EntMan.ToPrettyString(ctx.Player)} is trying to replace damageModifierSet.");
        if (!ctx.EntMan.TryGetComponent<DamageableComponent>(ctx.Player, out var damageable))
        {
            Log.Warning($"Entity {ctx.EntMan.ToPrettyString(ctx.Player)} does not have a DamagableComponent.");
            return;
        }
        _damageable.SetDamageModifierSetId((ctx.Player, damageable), DamageModifierSet);
    }
}
