using System.Diagnostics.Contracts;

namespace SpelljammerShipSheetCreator.DTO
{
        public enum Movement
    {
        Land,
        Walk,
        Float,
        Sail,
        Dive
    }

    public enum ShipModification
    {
        Treant,
        PlanarShift,
        Directionless
    }

    public class Ship
    {
        public string Type { get; set; }
        public int MaxHp { get; set; }
        public int ArmorClass { get; set; }
        public int DamageThreshold { get; set; }
        public int Speed { get; set; }
        public int Agility { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Cost { get; set; }
        public int MaxCrew { get; set; }
        public int MaxCargo { get; set; }
        public HashSet<Movement> Movements { get; set; } = new HashSet<Movement>();
        public HashSet<ShipModification>? Modifications { get; set; }
        public List<Weapon> Weapons { get; set; } = new List<Weapon> { };
    }
}
