using System;

namespace RegistroWeb.Models
{
    public class Evaluacion
    {
        int year;
        int month;
        int day;
        int cert;
        public Evaluacion(string agno, string mes, string dia, string dni)
        {
            try
            {
                year = int.Parse(agno);
            }
            catch (Exception e)
            {
                Console.WriteLine("Caracteres incorrectos");
                year = 0;
            }
            try
            {
                month = int.Parse(mes);
            }
            catch (Exception e)
            {
                Console.WriteLine("Caracteres incorrectos");
                month = 0;
            }
            try
            {
                day = int.Parse(dia);
            }
            catch (Exception e)
            {
                Console.WriteLine("Caracteres incorrectos");
                day = 0;
            }
            try
            {
                cert = int.Parse(dni);
            }
            catch (Exception e)
            {
                Console.WriteLine("Caracteres incorrectos");
                cert = 0;
            }
        }

        public int MandarAgno()
        {
            return year;
        }
        public int MandarMes()
        {
            return month;
        }
        public int MandarDia()
        {
            return day;
        }
        public int MandarDNI()
        {
            return cert;
        }
    }
}
