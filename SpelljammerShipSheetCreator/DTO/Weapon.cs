using System.Reflection.Metadata.Ecma335;

namespace SpelljammerShipSheetCreator.DTO
{
    public enum WeaponAction
    {
        Load,
        Aim,
        Fire
    }

    public enum AttackAngle
    {
        Front,
        RightFront,
        RightBack,
        Back,
        LeftBack,
        LeftFront
    }

    public enum WeaponModifications
    {
        TurretRotator,
        Teleport
    }

    public class WeaponProperties
    {
        public string Type { get; set; } = "";
        public int? MaxHp { get; set; }
        public int? ArmorClass { get; set; }
        public bool Ranged { get; set; }
        public int? Range { get; set; }
        public int? DisadvantageRange { get; set; }
        public int ToHit { get; set; }
        public string Damage { get; set; } = "";
        public string DamageType { get; set; } = "";
        public int? GrappleDc { get; set; }
        public string? GrappleDamage { get; set; }
        public int? CrewNeeded { get; set; }
        public List<WeaponAction>? Actions { get; set; }
        public string? Ammunition { get; set; }
    }
    public class Weapon
    {
        public string Type { get; set; } = "";
        public HashSet<AttackAngle> AttackAngles { get; set; } = new HashSet<AttackAngle>();
        public HashSet<WeaponModifications>? Modifications { get; set; }
    }
}
