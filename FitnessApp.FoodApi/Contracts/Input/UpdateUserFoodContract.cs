namespace FitnessApp.FoodApi.Contracts.Input
{
    public class UpdateUserFoodContract
    {
        public string UserId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public double Calories { get; set; }
    }
}