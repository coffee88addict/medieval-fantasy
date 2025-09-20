// Мёртвый Космос, Licensed under custom terms with restrictions on public hosting and commercial use, full text: https://raw.githubusercontent.com/dead-space-server/space-station-14-fobos/master/LICENSE.TXT

using Content.Server.DeadSpace.Medieval.Wear.Components;
using Content.Shared.DeadSpace.Medieval.Skills.Events;
using Content.Shared.Interaction;
using Content.Shared.Tools.Components;
using Content.Shared.Weapons.Melee.Events;

namespace Content.Server.DeadSpace.Medieval.Wear;

public sealed class AddWearAfterUseSystem : EntitySystem
{
    [Dependency] private readonly WearSystem _wear = default!;
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<AddWearAfterUseComponent, MeleeHitEvent>(OnMeleeHit);
        SubscribeLocalEvent<AddWearAfterUseComponent, AfterInteractUsingEvent>(OnAfterInteractUsing);
        SubscribeLocalEvent<AddWearAfterUseComponent, TileToolDoAfterEvent>(OnToolTileComplete);
        SubscribeLocalEvent<AddWearAfterUseComponent, LearnDoAfterEvent>(OnLearnDoAfter);

    }

    private void OnMeleeHit(EntityUid uid, AddWearAfterUseComponent component, MeleeHitEvent args)
    {
        if ((component.Triggers & WearTrigger.MeleeHit) == 0)
            return;

        if (TryComp<WearComponent>(uid, out var wearComp))
            _wear.AddWear(uid, component.Damage, wearComp);
    }

    private void OnAfterInteractUsing(EntityUid uid, AddWearAfterUseComponent component, AfterInteractUsingEvent args)
    {
        if ((component.Triggers & WearTrigger.Interact) == 0)
            return;

        if (TryComp<WearComponent>(uid, out var wearComp))
            _wear.AddWear(uid, component.Damage, wearComp);
    }

    private void OnToolTileComplete(EntityUid uid, AddWearAfterUseComponent component, TileToolDoAfterEvent args)
    {
        if ((component.Triggers & WearTrigger.TileTool) == 0)
            return;

        if (TryComp<WearComponent>(uid, out var wearComp))
            _wear.AddWear(uid, component.Damage, wearComp);
    }

    private void OnLearnDoAfter(EntityUid uid, AddWearAfterUseComponent component, LearnDoAfterEvent args)
    {
        if ((component.Triggers & WearTrigger.Learn) == 0)
            return;

        if (TryComp<WearComponent>(uid, out var wearComp))
            _wear.AddWear(uid, component.Damage, wearComp);
    }
}
