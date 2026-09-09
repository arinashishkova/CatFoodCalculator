namespace CatFoodCalculator.Core
{
    public static class CatFoodCalculator
    {
        public static bool TryCalculate(
            decimal weightKg,
            decimal caloriesPerKg,
            decimal caloriesPer100g,
            int days,
            out decimal dailyFoodGrams,
            out decimal totalFoodKg,
            out string error)
        {
            dailyFoodGrams = 0;
            totalFoodKg = 0;
            error = "";

            // weight check
            if (weightKg <= 0)
            {
                error = "Kassi kaal peab olema suurem kui 0.";
                return false;
            }

            // calories per 1 kg check
            if (caloriesPerKg <= 0)
            {
                error = "Kalorinorm peab olema suurem kui 0.";
                return false;
            }

            // calorie per 100 g check
            if (caloriesPer100g <= 0)
            {
                error = "Toidu kalorsus peab olema suurem kui 0.";
                return false;
            }
            
            // days count check
            if(days <= 0)
            {
                error = "Päevade arv peab olema suurem kui 0.";
                return false;
            }

            // calculations
            decimal dailyCalories = weightKg * caloriesPerKg;
            dailyFoodGrams = dailyCalories / caloriesPer100g * 100;
            totalFoodKg = dailyFoodGrams * days / 1000;


            return true;
        }   
    }
}
