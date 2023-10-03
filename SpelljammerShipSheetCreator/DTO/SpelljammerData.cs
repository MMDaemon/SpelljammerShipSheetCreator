namespace SpelljammerShipSheetCreator.DTO
{
    public class SpelljammerData
    {
        public HashSet<WeaponProperties> Weapons { get; set; } = new HashSet<WeaponProperties>();
        public HashSet<Ship> Ships { get; set; } = new HashSet<Ship>();
    }
}
