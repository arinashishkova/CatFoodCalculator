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
            if (weightKg <= 0 || weightKg > 30)
            {
                error = "Kassi kaal peab olema suurem kui 0 ja vähem kui 30.";
                return false;
            }

            // calories per 1 kg check
            if (caloriesPerKg < 1 || caloriesPerKg > 500)
            {
                error = "Kalorinorm peab olema suurem kui 0.";
                return false;
            }

            // calorie per 100g of catfood check
            if (caloriesPer100g < 1 || caloriesPer100g > 1000) 
            {
                error = "Toidu kalorsus peab olema vahemikus 1-1000 kcal/100g.";
                return false;
            }
            
            // days count check
            if(days < 1 || days > 365)
            {
                error = "Päevade arv peab olema vahemikus 1-365.";
                return false;
            }

            // calculations
            decimal dailyCalories = weightKg * caloriesPerKg;
            dailyFoodGrams = dailyCalories / caloriesPer100g * 100;
            totalFoodKg = dailyFoodGrams * days / 1000;


            // rounding
            dailyFoodGrams = Math.Round(dailyFoodGrams, 1, MidpointRounding.AwayFromZero);
            totalFoodKg = Math.Round(totalFoodKg, 2, MidpointRounding.AwayFromZero);


            return true;

            
        }   
    }
}
