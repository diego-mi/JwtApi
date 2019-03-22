using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JwtAuthenticationTest.Helpers
{
    public static class GeradorDeStringsHelper
    {
        private static Random random = new Random();

        public static string GerarStringAlfanumericaPorLength(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GerarStringAlfabeticaPorLength(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GerarStringNumericaPorLength(int length)
        {
            const string chars = "0123456789";

            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GerarEmailPorLength(int length)
        {
            string email = GeradorDeStringsHelper.GerarStringAlfanumericaPorLength(15);
            email += "@email.com";

            return email;
        }

        public static string GerarDePlacaVeicular()
        {
            return GeradorDeStringsHelper.GerarStringAlfabeticaPorLength(3) + "-" + GeradorDeStringsHelper.GerarStringNumericaPorLength(4);
        }

        public static string GerarDePlacaVeicularMercosul()
        {
            return GeradorDeStringsHelper.GerarStringAlfanumericaPorLength(7);
        }

        public static string GerarNomeCompleto()
        {
            return GeradorDeStringsHelper.GerarStringAlfabeticaPorLength(8) + " " + GeradorDeStringsHelper.GerarStringAlfabeticaPorLength(8);
        }

        public static string GerarRG()
        {
            //return $"{GeradorDeStringsHelper.GerarStringNumericaPorLength(2)}.{GeradorDeStringsHelper.GerarStringNumericaPorLength(3)}.{GeradorDeStringsHelper.GerarStringNumericaPorLength(3)}-{GeradorDeStringsHelper.GerarStringNumericaPorLength(1)}";
            return $"{GeradorDeStringsHelper.GerarStringNumericaPorLength(2)}{GeradorDeStringsHelper.GerarStringNumericaPorLength(3)}{GeradorDeStringsHelper.GerarStringNumericaPorLength(3)}{GeradorDeStringsHelper.GerarStringNumericaPorLength(1)}";
        }

        public static string GerarDataNascimento()
        {
            return "10/10/1990";
        }

        public static string GerarCelular()
        {
            return $"(16) 9{GeradorDeStringsHelper.GerarStringNumericaPorLength(4)}-{GeradorDeStringsHelper.GerarStringNumericaPorLength(4)}";
        }
    }
}
