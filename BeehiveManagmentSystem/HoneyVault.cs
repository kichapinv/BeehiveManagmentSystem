using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagmentSystem
{
    static class HoneyVault
    {
        public const float NECTAR_CONVERSATION_RATIO = .19f;
        public const float LOW_LEVEL_RATING = 10f;

        private static float honey = 25f;
        private static float nectar = 100f;

        public static void ConvertNectarToHoney(float amount)
        {
            if (amount > nectar) nectar = 0f;
                else nectar -= amount;
            
            honey += amount * NECTAR_CONVERSATION_RATIO;
        } 

        public static bool ConsumeHoney(float amount)
        {
            if (amount <= honey)
            {
                honey -= amount;
                return true;
            }
            else return false;
        }

        public static void CollectNectar(float amount)
        {
            if (amount > 0f) nectar += amount;
        }

        public static string StatusReport 
        {
            get 
            {
                string warningAmount = "";
                if (honey < LOW_LEVEL_RATING)
                {
                    warningAmount +=  "LOW HONEY - ADD A HONEY MANUFATURER\n"; 
                }
                else if (nectar < LOW_LEVEL_RATING)
                {
                    warningAmount += "LOW NECTAR - ADD A NECTAR COLLECTOR\n";
                }
                return $"{warningAmount}honey - {honey}, nectar - {nectar}";
            }
        }
    }
}
