// Мёртвый Космос, Licensed under custom terms with restrictions on public hosting and commercial use,
// full text: https://raw.githubusercontent.com/dead-space-server/space-station-14-fobos/master/LICENSE.TXT

using Content.Server.Destructible;
using Content.Server.Destructible.Thresholds.Triggers;
using Content.Shared.Damage;

namespace Content.Server.DeadSpace.Medieval.Destructible
{
    [Serializable]
    [DataDefinition]
    public sealed partial class RepeatDamageTrigger : IThresholdTrigger
    {

        [DataField("step", required: true)]
        public int Step { get; set; }

        [ViewVariables]
        private int _lastTriggerLevel = 0;

        public bool Reached(DamageableComponent damageable, DestructibleSystem system)
        {
            var total = (int)damageable.TotalDamage;

            var level = total / Step;

            if (level > _lastTriggerLevel)
            {
                _lastTriggerLevel = level;
                return true;
            }

            return false;
        }
    }
}
