using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerCaballos.Util
{
    class Apuesta
    {

        public List<String> listaCaballosPosiciones = new List<String>();
        
        public String caballoGanador = "";
        
        public Double valorBase = 10000;
       
        public List<double> totalApuesta = new List<double>();

        public Apuesta()
        {

        }

        public void AgregarCaballoPosicion(String caballo)
        {
           
            listaCaballosPosiciones.Add(caballo);
        }

        
        public void EliminarPosicionesCarrera()
        {
            for (int i = 0; i < listaCaballosPosiciones.Count; i++)
            {
                listaCaballosPosiciones.Clear();
            }
        }

        
        public String DarCaballoGanador()
        {

            for (int i = 0; i < listaCaballosPosiciones.Count; i++)
            {
                if (i == 0)
                {
                    caballoGanador = listaCaballosPosiciones[0];
                }
            }
            return caballoGanador;
        }

        
        public Double DarValorApuestaBase()
        {
            Double valorApuesta = 0;
            for (int i = 0; i < totalApuesta.Count; i++)
            {
                if (i == 0)
                {
                    valorApuesta = totalApuesta[0];
                }
            }
            return valorApuesta;
        }

       
        public int validarComboCaballo(String caballo)
        {
            int respuesta = -1;
            switch (caballo)
            {
                case "CABALLO 1":
                    respuesta = 1;
                    return respuesta;
                case "CABALLO 2":
                    respuesta = 2;
                    return respuesta;
                case "CABALLO 3":
                    respuesta = 3;
                    return respuesta;
                case "CABALLO 4":
                    respuesta = 4;
                    return respuesta;
            }
            return respuesta;
        }

       
        public Boolean realizarApuesta(int numCaballoGanador, int caballoApuesta, Double valorApuesta)
        {
            if (numCaballoGanador == caballoApuesta)
            {
                for (int i = 0; i < totalApuesta.Count; i++)
                {
                    if (i == 0)
                    {
                        totalApuesta[0] = totalApuesta[0] + valorApuesta;
                        return true;
                    }
                }
                return false;
            }
            else
            {
                for (int i = 0; i < totalApuesta.Count; i++)
                {
                    if (i == 0)
                    {
                        totalApuesta[0] = totalApuesta[0] - valorApuesta;
                        return false;
                    }
                }
                return false;
            }

        }

    }
}
