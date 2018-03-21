

namespace MonedaApp
{
    public class ConvertionService
    {
        public static decimal ConvertUSD(string currency, decimal amount)
        {
            decimal result = 0;
            bool wasConverted = false;
            var service = new MonedaApp.WebService.ServicioConversion();

            service.Convertir(currency, amount, true, out result, out wasConverted);
            return result;
        }

        public static string[] GetCurrencies()
        {
            var service = new MonedaApp.WebService.ServicioConversion();
            return service.ObtenerMonedas();
        }
    }
}