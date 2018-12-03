using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompuTech
{
    class FacturaRedes
    {

        public static string nfc="";
        public static string tipo="";
        public static  string nombre="";
        public static string enc_documento ="";
        public static string enc_nombre="";
         public static string enc_apellido="";
          public static string enc_formadepago="";
        //contado
        public static string cont_documento ="";
         public static string cont_deuda ="";
          public static string cont_pagocon="";
        public static string cont_devuelta ="";
        //credito
         public static string cre_documentopersonal="";
          public static string cre_documentogarante="";
        public static string cre_deuda="";
         public static string cre_pagaraen="";
        //iguala
          public static string igua_miempleado="";
        public static string igua_nombreempleado="";
         public static string igua_deuda="";
         public static string igua_tiempodepago = "";
         public static string igua_pagomensual = "";

        //dispositivos de red
         public static string disp_red = "";
         public static string disp_switch = "";
         public static string disp_servidor = "";
         public static string disp_rocetas = "";
         public static string disp_preciored = "";
         public static string disp_precioswitch = "";
         public static string disp_precioservidor = "";
         public static string disp_preciorocetas = "";
       
        //maquinas y cables
         public static string maqui_instalara = "";
         public static string maqui_precioinstalara = "";

         public static string maqui_cableusar = "";
         public static string maqui_distancia = "";
         public static string maqui_preciodistancia = "";
        
        //obra
         public static string manodeobra = "";
    }
}
