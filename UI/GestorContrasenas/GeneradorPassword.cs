using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGestorCodigo.UI.GestorContrasenas
{
    public class GeneradorPassword
    {
        Random rnd = new Random();

        private string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@";
        private string minusculas = "abcdefghijklmnopqrstuvwxyz";
        private string mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string simbolos= "%$#@";
        private string numeros= "0123456789";
        private char letra;
        private string password;
        
        public string generar(int passLenght)
        {
            password = string.Empty;

            for (int i = 0; i < passLenght; i++)
            {
                letra = caracteres[rnd.Next(caracteres.Length)];
                password += letra.ToString();
            }

            return password;
        }

        public string generar(int passLenght, bool usarSimbolos=true, bool usarNumeros = true, bool usarMayusculas = true, bool usarMinusculas = true)
        {
            password = string.Empty;
            string caracteresAux = string.Empty;
            if (usarSimbolos) { caracteresAux = caracteresAux + simbolos; }
            if (usarNumeros) { caracteresAux = caracteresAux + numeros; }
            if (usarMayusculas) { caracteresAux = caracteresAux + mayusculas; }
            if (usarMinusculas) { caracteresAux = caracteresAux + minusculas; }

            for (int i = 0; i < passLenght; i++)
            {
                letra = caracteresAux[rnd.Next(caracteresAux.Length)];
                password += letra.ToString();
            }
            return password;
        }
        
    }
}
