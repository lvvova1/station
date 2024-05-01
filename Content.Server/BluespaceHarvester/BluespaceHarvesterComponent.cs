using Content.Shared.BluespaceHarvester;
using Robust.Shared.Audio;
using Robust.Shared.Prototypes;

namespace Content.Server.BluespaceHarvester;

[RegisterComponent, Access(typeof(BluespaceHarvesterSystem))]
public sealed partial class BluespaceHarvesterComponent : Component
{
    /// <summary>
    /// Responsible for forcibly turning off the harvester and blocking input level.
    /// </summary>
    [DataField]
    public bool Reseted;

    /// <summary>
    /// The current level at which the harvester is located is what other parameters are calculated from.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public int CurrentLevel;

    /// <summary>
    /// The level to which the harvester always strives if possible. It is installed by the player, but during the reset, this feature is blocked.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public int TargetLevel;

    /// <summary>
    /// The level above which it is impossible not to set TargetLevel.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public int MaxLevel = 20;

    /// <summary>
    /// The level above which the Danger begin to rise.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public int StableLevel = 10;

    /// <summary>
    /// Similar to StableLevel, but replaces it when hacked by a Emag.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public int EmaggedStableLevel = 5;

    /// <summary>
    /// Points generated by harvesters, which can be spent on purchasing things in categories.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public int Points;

    /// <summary>
    /// Displays how many points have been generated, regardless of spending.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public int TotalPoints;

    /// <summary>
    /// Tap to visualize any state of the harvester after hacking.
    /// </summary>
    [DataField]
    public BluespaceHarvesterVisuals RedspaceTap = BluespaceHarvesterVisuals.TapRedspace;

    /// <summary>
    /// The level of danger on which the spawn of DANGEROUS rifts depends.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public int Danger;

    /// <summary>
    /// This will allow you to pay a certain fee for careless work with this device.
    /// Given mainly for reset when there is a loss of electricity from the source,
    /// but the value is not too large to cause a lot of harm.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public int DangerFromReset = 75;

    /// <summary>
    /// After this danger value, the generation of dangerous creatures and anomalies will begin.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public int DangerLimit = 175;

    /// <summary>
    /// A prototype rift created when the number of allowed points is exceeded.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public EntProtoId Rift = "BluespaceHarvesterRift";

    /// <summary>
    /// The maximum number of rifts that can appear, the lower this value,
    /// the greater the chance of strong mobs
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public int RiftCount = 3;

    /// <summary>
    /// Tries once every 1 second, with this chance to create a rift if DangerLimit is exceeded.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public float RiftChance = 0.08f;

    /// <summary>
    /// Replaces RiftChance when hacked by Emag.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public float EmaggedRiftChance = 0.03f;

    [DataField]
    public List<BluespaceHarvesterCategoryInfo> Categories = new()
    {
        new BluespaceHarvesterCategoryInfo()
        {
            PrototypeId = "RandomHarvesterBiologicalLoot",
            Cost = 5_000,
            Type = BluespaceHarvesterCategory.Biological,
        },
        new BluespaceHarvesterCategoryInfo()
        {
            PrototypeId = "RandomHarvesterTechnologicalLoot",
            Cost = 7_000,
            Type = BluespaceHarvesterCategory.Technological,
        },
        new BluespaceHarvesterCategoryInfo()
        {
            PrototypeId = "RandomHarvesterIndustrialLoot",
            Cost = 9_000,
            Type = BluespaceHarvesterCategory.Industrial,
        },
        new BluespaceHarvesterCategoryInfo()
        {
            PrototypeId = "RandomHarvesterDestructionLoot",
            Cost = 12_000,
            Type = BluespaceHarvesterCategory.Destruction,
        },
    };

    /// <summary>
    /// The radius within which crates and rifts can appear.
    /// </summary>
    [DataField]
    public float SpawnRadius = 5f;

    [DataField]
    public EntProtoId SpawnEffect = "EffectEmpPulse";

    [DataField]
    public SoundSpecifier SpawnSound = new SoundPathSpecifier("/Audio/Effects/teleport_arrival.ogg");
}

[Serializable]
public sealed class BluespaceHarvesterTap
{
    /// <summary>
    /// The minimum level from which Visual is enabled.
    /// </summary>
    [DataField]
    public int Level;

    [DataField]
    public BluespaceHarvesterVisuals Visual;
}
