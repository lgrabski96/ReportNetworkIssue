namespace Shop.Model
{
    public class Bike : Vehicle
    {
        public override decimal CalculateCost(int kmRange) // => 0; (the same as below)
        {
            return 0;
        }
    }
}
