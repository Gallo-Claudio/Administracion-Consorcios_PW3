using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public static class Hardcodeo    
    {
        // Harcodeo todas las entidades

        public static List<Consorcio> consorcio = new List<Consorcio>();
        public static List<Unidad> unidad = new List<Unidad>();
        public static List<Gasto> gasto = new List<Gasto>();
        public static List<Provincia> provincia = new List<Provincia>();
        public static List<Usuario> usuario = new List<Usuario>();
        public static List<TipoGasto> tipoGasto = new List<TipoGasto>();


        public static Usuario usu1 = new Usuario();
        public static Usuario usu2 = new Usuario();
        public static Usuario usu3 = new Usuario();

        public static Provincia prov1 = new Provincia();
        public static Provincia prov2 = new Provincia();
        public static Provincia prov3 = new Provincia();
        public static Provincia prov4 = new Provincia();
        public static Provincia prov5 = new Provincia();
        public static Provincia prov6 = new Provincia();
        public static Provincia prov7 = new Provincia();
        public static Provincia prov8 = new Provincia();
        public static Provincia prov9 = new Provincia();
        public static Provincia prov10 = new Provincia();
        public static Provincia prov11 = new Provincia();
        public static Provincia prov12 = new Provincia();
        public static Provincia prov13 = new Provincia();
        public static Provincia prov14 = new Provincia();
        public static Provincia prov15 = new Provincia();
        public static Provincia prov16 = new Provincia();
        public static Provincia prov17 = new Provincia();
        public static Provincia prov18 = new Provincia();
        public static Provincia prov19 = new Provincia();
        public static Provincia prov20 = new Provincia();
        public static Provincia prov21 = new Provincia();
        public static Provincia prov22 = new Provincia();
        public static Provincia prov23 = new Provincia();
        public static Provincia prov24 = new Provincia();

        public static TipoGasto tipogasto1 = new TipoGasto();
        public static TipoGasto tipogasto2 = new TipoGasto();
        public static TipoGasto tipogasto3 = new TipoGasto();
        public static TipoGasto tipogasto4 = new TipoGasto();
        public static TipoGasto tipogasto5 = new TipoGasto();
        public static TipoGasto tipogasto6 = new TipoGasto();
        public static TipoGasto tipogasto7 = new TipoGasto();
        public static TipoGasto tipogasto8 = new TipoGasto();

        static Consorcio con1 = new Consorcio();
        static Consorcio con2 = new Consorcio();
        static Consorcio con3 = new Consorcio();
        static Consorcio con4 = new Consorcio();
        static Consorcio con5 = new Consorcio();
        static Consorcio con6 = new Consorcio();

        public static void HardcodeoDatos()
        {
            HardcodeoConsorcio();
            HardcodeoUnidad();
            HardcodeoGasto();
            HardcodeoProvincia();
            HardcodeoUsuario();
            HardcodeoTipoGasto();
        }

        private static void HardcodeoUsuario()
        {
            usu1.IdUsuario = 1;
            usu1.Email = "pnsanchez@unlam.edu.ar";
            usu1.Password = "VABlAHMAdAAxADIAMwA0ACEA";  // ---------------------------------->    desencriptado	"Test1234!"
            usu1.Nombre = "Pablo";
            usu1.FechaRegistracion = new DateTime(2020, 09, 29, 22, 45, 36);
            usu1.FechaUltLogin = new DateTime(2020, 09, 29, 22, 05, 36);

            usu2.IdUsuario = 2;
            usu2.Email = "mpaz@unlam.edu.ar";
            usu2.Password = "VABlAHMAdAAxADIAMwA0ACEA";
            usu2.Nombre = "Mariano";
            usu2.FechaRegistracion = new DateTime(2020, 09, 29, 22, 45, 36);
            usu2.FechaUltLogin = new DateTime(2020, 09, 29, 22, 55, 36);

            usu3.IdUsuario = 3;
            usu3.Email = "mjuiz@unlam.edu.ar";
            usu3.Password = "VABlAHMAdAAxADIAMwA0ACEA";
            usu3.Nombre = "Miguel";
            usu3.FechaRegistracion = new DateTime(2020, 09, 29, 22, 45, 36);
            usu3.FechaUltLogin = new DateTime();  //null

            usuario.Add(usu1);
            usuario.Add(usu2);
            usuario.Add(usu3);
        }
        private static void HardcodeoProvincia()
        {
            prov1.IdProvincia = 1;
            prov1.Nombre = "Buenos Aires";

            prov2.IdProvincia = 2;
            prov2.Nombre = "CABA";

            prov3.IdProvincia = 3;
            prov3.Nombre = "Catamarca";

            prov4.IdProvincia = 4;
            prov4.Nombre = "Chaco";

            prov5.IdProvincia = 5;
            prov5.Nombre = "Chubut";

            prov6.IdProvincia = 6;
            prov6.Nombre = "Córdoba";

            prov7.IdProvincia = 7;
            prov7.Nombre = "Corrientes";

            prov8.IdProvincia = 8;
            prov8.Nombre = "Entre Ríos";

            prov9.IdProvincia = 9;
            prov9.Nombre = "Formosa";

            prov10.IdProvincia = 10;
            prov10.Nombre = "Jujuy";

            prov11.IdProvincia = 11;
            prov11.Nombre = "La Pampa";

            prov12.IdProvincia = 12;
            prov12.Nombre = "La Rioja";

            prov13.IdProvincia = 13;
            prov13.Nombre = "Mendoza";

            prov14.IdProvincia = 14;
            prov14.Nombre = "Misiones";

            prov15.IdProvincia = 15;
            prov15.Nombre = "Neuquén";

            prov16.IdProvincia = 16;
            prov16.Nombre = "Río Negro";

            prov17.IdProvincia = 17;
            prov17.Nombre = "Salta";

            prov18.IdProvincia = 18;
            prov18.Nombre = "San Juan";

            prov19.IdProvincia = 19;
            prov19.Nombre = "San Luis";

            prov20.IdProvincia = 20;
            prov20.Nombre = "Santa Cruz";

            prov21.IdProvincia = 21;
            prov21.Nombre = "Santa Fe";

            prov22.IdProvincia = 22;
            prov22.Nombre = "Santiago del Estero";

            prov23.IdProvincia = 23;
            prov23.Nombre = "Tierra del Fuego";

            prov24.IdProvincia = 24;
            prov24.Nombre = "Tucumán";


            provincia.Add(prov1);
            provincia.Add(prov2);
            provincia.Add(prov3);
            provincia.Add(prov4);
            provincia.Add(prov5);
            provincia.Add(prov6);
            provincia.Add(prov7);
            provincia.Add(prov8);
            provincia.Add(prov9);
            provincia.Add(prov10);
            provincia.Add(prov11);
            provincia.Add(prov12);
            provincia.Add(prov13);
            provincia.Add(prov14);
            provincia.Add(prov15);
            provincia.Add(prov16);
            provincia.Add(prov17);
            provincia.Add(prov18);
            provincia.Add(prov19);
            provincia.Add(prov20);
            provincia.Add(prov21);
            provincia.Add(prov22);
            provincia.Add(prov23);
            provincia.Add(prov24);
        }
        private static void HardcodeoConsorcio()
        {
            con1.IdConsorcio = 1;
            con1.Nombre = "Edificio Godoy Cruz";
            con1.IdProvincia = prov2;
            con1.Ciudad = "CABA";
            con1.Calle = "Godoy Cruz";
            con1.Altura = 2369;
            con1.DiaVencimientoExpensas = 6;
            con1.FechaCreacion = new DateTime(2020, 09, 29, 22, 50, 00);
            con1.IdUsuarioCreador = usu1;

            con2.IdConsorcio = 2;
            con2.Nombre = "Edificio Arieta";
            con2.IdProvincia = prov1;
            con2.Ciudad = "San Justo";
            con2.Calle = "Arieta";
            con2.Altura = 2748;
            con2.DiaVencimientoExpensas = 12;
            con2.FechaCreacion = new DateTime(2020, 09, 29, 22, 50, 48);
            con2.IdUsuarioCreador = usu1;

            con3.IdConsorcio = 3;
            con3.Nombre = "Edificio Alberdi";
            con3.IdProvincia = prov2;
            con3.Ciudad = "CABA";
            con3.Calle = "Alberdi";
            con3.Altura = 2387;
            con3.DiaVencimientoExpensas = 1;
            con3.FechaCreacion = new DateTime(2020, 09, 29, 22, 51, 37);
            con3.IdUsuarioCreador = usu1;

            con4.IdConsorcio = 4;
            con4.Nombre = "Torres Florenci";
            con4.IdProvincia = prov1;
            con4.Ciudad = "Ramos Mejia";
            con4.Calle = "Dr.Gabriel Ardoino";
            con4.Altura = 364;
            con4.DiaVencimientoExpensas = 5;
            con4.FechaCreacion = new DateTime(2020, 09, 29, 22, 51, 56);
            con4.IdUsuarioCreador = usu2;

            con5.IdConsorcio = 5;
            con5.Nombre = "Vilanova";
            con5.IdProvincia = prov1;
            con5.Ciudad = "Ramos Mejia";
            con5.Calle = "Tacuari";
            con5.Altura = 620;
            con5.DiaVencimientoExpensas = 21;
            con5.FechaCreacion = new DateTime(2020, 09, 29, 22, 53, 31);
            con5.IdUsuarioCreador = usu2;

            con6.IdConsorcio = 6;
            con6.Nombre = "Altos de Gandara";
            con6.IdProvincia = prov1;
            con6.Ciudad = "Haedo";
            con6.Calle = "Juez de la Gandara";
            con6.Altura = 851;
            con6.DiaVencimientoExpensas = 2;
            con6.FechaCreacion = new DateTime(2020, 09, 29, 22, 58, 32);
            con6.IdUsuarioCreador = usu3;

            consorcio.Add(con1);
            consorcio.Add(con2);
            consorcio.Add(con3);
            consorcio.Add(con4);
            consorcio.Add(con5);
            consorcio.Add(con6);
        }
        private static void HardcodeoUnidad()
        {
            Unidad unid1 = new Unidad();
            unid1.IdUnidad = 1;
            unid1.IdConsorcio = con1;
            unid1.Nombre = "1A";
            unid1.NombrePropietario = "Pepe";
            unid1.ApellidoPropietario = "Argento";
            unid1.EmailPropietario = "pepeargento@test.com";
            //unid1.Superficie = null;
            unid1.FechaCreacion = new DateTime(2020, 09, 29, 23, 36, 43);
            unid1.IdUsuarioCreador = usu1;

            Unidad unid2 = new Unidad();
            unid2.IdUnidad = 2;
            unid2.IdConsorcio = con1;
            unid2.Nombre = "1B";
            unid2.NombrePropietario = "Dardo";
            unid2.ApellidoPropietario = "Fuseneco";
            unid2.EmailPropietario = "dardo@test.com";
            //unid2.Superficie = null;
            unid2.FechaCreacion = new DateTime(2020, 09, 29, 23, 37, 11);
            unid2.IdUsuarioCreador = usu1;

            Unidad unid4 = new Unidad();
            unid4.IdUnidad = 4;
            unid4.IdConsorcio = con1;
            unid4.Nombre = "1C";
            unid4.NombrePropietario = "Fatiga";
            unid4.ApellidoPropietario = "Argento";
            unid4.EmailPropietario = "fatiga@test.com";
            //unid4.Superficie = null;
            unid4.FechaCreacion = new DateTime(2020, 09, 29, 23, 37, 40);
            unid4.IdUsuarioCreador = usu1;

            Unidad unid5 = new Unidad();
            unid5.IdUnidad = 5;
            unid5.IdConsorcio = con1;
            unid5.Nombre = "2A";
            unid5.NombrePropietario = "Edna";
            unid5.ApellidoPropietario = "Krabappel";
            unid5.EmailPropietario = "edna@test.com";
            //unid5.Superficie = null;
            unid5.FechaCreacion = new DateTime(2020, 09, 29, 23, 38, 10);
            unid5.IdUsuarioCreador = usu1;

            Unidad unid7 = new Unidad();
            unid7.IdUnidad = 7;
            unid7.IdConsorcio = con1;
            unid7.Nombre = "2B";
            unid7.NombrePropietario = "Ned";
            unid7.ApellidoPropietario = "Flanders";
            unid7.EmailPropietario = "neddy@test.com";
            //unid7.Superficie = null;
            unid7.FechaCreacion = new DateTime(2020, 09, 29, 23, 40, 15);
            unid7.IdUsuarioCreador = usu1;

            Unidad unid8 = new Unidad();
            unid8.IdUnidad = 8;
            unid8.IdConsorcio = con1;
            unid8.Nombre = "2C";
            unid8.NombrePropietario = "Moe";
            unid8.ApellidoPropietario = "Szyslak";
            unid8.EmailPropietario = "moe@test.com";
            //unid8.Superficie = null;
            unid8.FechaCreacion = new DateTime(2020, 09, 29, 00, 00, 00);
            unid8.IdUsuarioCreador = usu1;

            Unidad unid9 = new Unidad();
            unid9.IdUnidad = 9;
            unid9.IdConsorcio = con1;
            unid9.Nombre = "3A";
            unid9.NombrePropietario = "Franco";
            unid9.ApellidoPropietario = "Milazzo";
            unid9.EmailPropietario = "franco@test.com";
            //unid9.Superficie = null;
            unid9.FechaCreacion = new DateTime(2020, 09, 29, 00, 00, 00);
            unid9.IdUsuarioCreador = usu1;

            Unidad unid10 = new Unidad();
            unid10.IdUnidad = 10;
            unid10.IdConsorcio = con1;
            unid10.Nombre = "3B";
            unid10.NombrePropietario = "Emilio";
            unid10.ApellidoPropietario = "Ravenna";
            unid10.EmailPropietario = "ravenna@test.com";
            //unid10.Superficie = null;
            unid10.FechaCreacion = new DateTime(2020, 09, 29, 23, 42, 25);
            unid10.IdUsuarioCreador = usu1;

            Unidad unid11 = new Unidad();
            unid11.IdUnidad = 11;
            unid11.IdConsorcio = con1;
            unid11.Nombre = "3C";
            unid11.NombrePropietario = "Gabriel";
            unid11.ApellidoPropietario = "Medina";
            unid11.EmailPropietario = "gmedina@test.com";
            //unid11.Superficie = null;
            unid11.FechaCreacion = new DateTime(2020, 09, 29, 23, 42, 50);
            unid11.IdUsuarioCreador = usu1;

            Unidad unid12 = new Unidad();
            unid12.IdUnidad = 12;
            unid12.IdConsorcio = con1;
            unid12.Nombre = "4A";
            unid12.NombrePropietario = "Jack";
            unid12.ApellidoPropietario = "Shepard";
            unid12.EmailPropietario = "jackperdido@test.com";
            //unid12.Superficie = null;
            unid12.FechaCreacion = new DateTime(2020, 09, 29, 23, 43, 41);
            unid12.IdUsuarioCreador = usu1;

            Unidad unid13 = new Unidad();
            unid13.IdUnidad = 13;
            unid13.IdConsorcio = con1;
            unid13.Nombre = "4B";
            unid13.NombrePropietario = "Desmond";
            unid13.ApellidoPropietario = "Hume";
            unid13.EmailPropietario = "desmond@test.com";
            //unid13.Superficie = null;
            unid13.FechaCreacion = new DateTime(2020, 09, 29, 23, 44, 27);
            unid13.IdUsuarioCreador = usu1;

            Unidad unid14 = new Unidad();
            unid14.IdUnidad = 14;
            unid14.IdConsorcio = con1;
            unid14.Nombre = "4C";
            unid14.NombrePropietario = "Kate";
            unid14.ApellidoPropietario = "Austen";
            unid14.EmailPropietario = "kate@test.com";
            //unid14.Superficie = null;
            unid14.FechaCreacion = new DateTime(2020, 09, 29, 23, 45, 21);
            unid14.IdUsuarioCreador = usu1;

            Unidad unid15 = new Unidad();
            unid15.IdUnidad = 15;
            unid15.IdConsorcio = con2;
            unid15.Nombre = "1A";
            unid15.NombrePropietario = "Michael";
            unid15.ApellidoPropietario = "Scofield";
            unid15.EmailPropietario = "michael@test.com";
            //unid15.Superficie = null;
            unid15.FechaCreacion = new DateTime(2020, 09, 29, 23, 46, 12);
            unid15.IdUsuarioCreador = usu1;

            Unidad unid16 = new Unidad();
            unid16.IdUnidad = 16;
            unid16.IdConsorcio = con2;
            unid16.Nombre = "1B";
            unid16.NombrePropietario = "T";
            unid16.ApellidoPropietario = "Bag";
            unid16.EmailPropietario = "tbag@test.com";
            //unid16.Superficie = null;
            unid16.FechaCreacion = new DateTime(2020, 09, 29, 23, 46, 25);
            unid16.IdUsuarioCreador = usu1;

            Unidad unid17 = new Unidad();
            unid17.IdUnidad = 17;
            unid17.IdConsorcio = con2;
            unid17.Nombre = "1C";
            unid17.NombrePropietario = "Sara";
            unid17.ApellidoPropietario = "Tancredi";
            unid17.EmailPropietario = "sara@test.com";
            //unid17.Superficie = null;
            unid17.FechaCreacion = new DateTime(2020, 09, 29, 23, 47, 03);
            unid17.IdUsuarioCreador = usu1;

            Unidad unid19 = new Unidad();
            unid19.IdUnidad = 19;
            unid19.IdConsorcio = con3;
            unid19.Nombre = "Unidad 1";
            unid19.NombrePropietario = "Tokio";
            unid19.ApellidoPropietario = null;
            unid19.EmailPropietario = "tokio@test.com";
            //unid19.Superficie = null;
            unid19.FechaCreacion = new DateTime(2020, 09, 29, 23, 47, 53);
            unid19.IdUsuarioCreador = usu1;

            Unidad unid20 = new Unidad();
            unid20.IdUnidad = 20;
            unid20.IdConsorcio = con3;
            unid20.Nombre = "Unidad 2";
            unid20.NombrePropietario = "Berlin";
            unid20.ApellidoPropietario = null;
            unid20.EmailPropietario = "berlin@test.com";
            //unid20.Superficie = null;
            unid20.FechaCreacion = new DateTime(2020, 09, 29, 23, 48, 07);
            unid20.IdUsuarioCreador = usu1;

            Unidad unid21 = new Unidad();
            unid21.IdUnidad = 21;
            unid21.IdConsorcio = con3;
            unid21.Nombre = "Unidad 3";
            unid21.NombrePropietario = "Denver";
            unid21.ApellidoPropietario = null;
            unid21.EmailPropietario = "denver@test.com";
            //unid21.Superficie = null;
            unid21.FechaCreacion = new DateTime(2020, 09, 29, 23, 48, 26);
            unid21.IdUsuarioCreador = usu1;

            unidad.Add(unid1);
            unidad.Add(unid2);
            unidad.Add(unid4);
            unidad.Add(unid5);
            unidad.Add(unid7);
            unidad.Add(unid8);
            unidad.Add(unid9);
            unidad.Add(unid10);
            unidad.Add(unid11);
            unidad.Add(unid12);
            unidad.Add(unid13);
            unidad.Add(unid14);
            unidad.Add(unid15);
            unidad.Add(unid16);
            unidad.Add(unid17);
            unidad.Add(unid19);
            unidad.Add(unid20);
            unidad.Add(unid21);

        }
        private static void HardcodeoGasto()
        {
            Gasto gasto1 = new Gasto();
            gasto1.IdGasto = 1;
            gasto1.Nombre = "Fumigacion de Unidades";
            gasto1.Descripcion = "Se fumigaron todas las unidades excepto la unidad 10 y 12";
            gasto1.IdConsorcio = con1;
            gasto1.IdTipoGasto = tipogasto5;
            gasto1.FechaGasto = new DateTime(2020, 08, 12, 00, 00, 00);
            gasto1.AnioExpensa = 2020;
            gasto1.MesExpensa = 8;
            gasto1.ArchivoComprobante = "/Gastos/fumigacion-20200812.pdf";
            gasto1.Monto = 25000.00;
            gasto1.FechaCreacion = new DateTime(2020, 08, 13, 00, 00, 00);
            gasto1.IdUsuarioCreador = usu1;

            Gasto gasto2 = new Gasto();
            gasto2.IdGasto = 2;
            gasto2.Nombre = "Restauracion SUM";
            gasto2.Descripcion = null;
            gasto2.IdConsorcio = con1;
            gasto2.IdTipoGasto = tipogasto5;
            gasto2.FechaGasto = new DateTime(2020, 08, 22, 00, 00, 00);
            gasto2.AnioExpensa = 2020;
            gasto2.MesExpensa = 8;
            gasto2.ArchivoComprobante = "/Gastos/Sum08.pdf";
            gasto2.Monto = 125000.00;
            gasto2.FechaCreacion = new DateTime(2020, 08, 23, 00, 00, 00);
            gasto2.IdUsuarioCreador = usu1;

            Gasto gasto3 = new Gasto();
            gasto3.IdGasto = 3;
            gasto3.Nombre = "Compra productos de limpieza";
            gasto3.Descripcion = "Detalle: 1. Balde de 12 litros 2. Pala Cepillo VP2 3. Escoba topacio con cabo 4";
            gasto3.IdConsorcio = con1;
            gasto3.IdTipoGasto = tipogasto7;
            gasto3.FechaGasto = new DateTime(2020, 09, 02, 00, 00, 00);
            gasto3.AnioExpensa = 2020;
            gasto3.MesExpensa = 9;
            gasto3.ArchivoComprobante = "/Gastos/Limpieza-2020-09-02.pdf";
            gasto3.Monto = 40000.00;
            gasto3.FechaCreacion = new DateTime(2020, 09, 02, 00, 00, 00);
            gasto3.IdUsuarioCreador = usu1;

            Gasto gasto4 = new Gasto();
            gasto4.IdGasto = 4;
            gasto4.Nombre = "Reparacion humeadad unidad 1A";
            gasto4.Descripcion = "Habia manchas en el techo, se impermiabilizo y se volvio a pintar";
            gasto4.IdConsorcio = con1;
            gasto4.IdTipoGasto = tipogasto6;
            gasto4.FechaGasto = new DateTime(2020, 09, 12, 00, 00, 00);
            gasto4.AnioExpensa = 2020;
            gasto4.MesExpensa = 9;
            gasto4.ArchivoComprobante = "/Gastos/Reparacion-2020-09-12.pdf";
            gasto4.Monto = 30000.00;
            gasto4.FechaCreacion = new DateTime(2020, 09, 12, 00, 00, 00);
            gasto4.IdUsuarioCreador = usu1;

            Gasto gasto5 = new Gasto();
            gasto5.IdGasto = 5;
            gasto5.Nombre = "Fumigacion de Unidades";
            gasto5.Descripcion = "Se fumigaron todas las unidades";
            gasto5.IdConsorcio = con1;
            gasto5.IdTipoGasto = tipogasto5;
            gasto5.FechaGasto = new DateTime(2020, 09, 20, 00, 00, 00);
            gasto5.AnioExpensa = 2020;
            gasto5.MesExpensa = 9;
            gasto5.ArchivoComprobante = "/Gastos/fumigacion-2020-09-20.pdf";
            gasto5.Monto = 25000.00;
            gasto5.FechaCreacion = new DateTime(2020, 09, 28, 00, 00, 00);
            gasto5.IdUsuarioCreador = usu1;

            Gasto gasto6 = new Gasto();
            gasto6.IdGasto = 6;
            gasto6.Nombre = "Sueldos Agosto";
            gasto6.Descripcion = "Se abonaron los sueldos de los 3 encargados";
            gasto6.IdConsorcio = con1;
            gasto6.IdTipoGasto = tipogasto1;
            gasto6.FechaGasto = new DateTime(2020, 08, 30, 00, 00, 00);
            gasto6.AnioExpensa = 2020;
            gasto6.MesExpensa = 8;
            gasto6.ArchivoComprobante = "/Gastos/liquidacion-sueldos-2020-08.pdf";
            gasto6.Monto = 150000.00;
            gasto6.FechaCreacion = new DateTime(2020, 09, 01, 00, 00, 00);
            gasto6.IdUsuarioCreador = usu1;

            gasto.Add(gasto1);
            gasto.Add(gasto2);
            gasto.Add(gasto3);
            gasto.Add(gasto4);
            gasto.Add(gasto5);
            gasto.Add(gasto6);
        }
        private static void HardcodeoTipoGasto()
        {
            tipogasto1.IdTipoGasto = 1;
            tipogasto1.Nombre = "Sueldos";

            tipogasto2.IdTipoGasto = 2;
            tipogasto2.Nombre = "Servicios";

            tipogasto3.IdTipoGasto = 3;
            tipogasto3.Nombre = "Cargas Sociales";

            tipogasto4.IdTipoGasto = 4;
            tipogasto4.Nombre = "Seguros";

            tipogasto5.IdTipoGasto = 5;
            tipogasto5.Nombre = "Mantenimiento Gral";

            tipogasto6.IdTipoGasto = 6;
            tipogasto6.Nombre = "Reparacion Unidad";

            tipogasto7.IdTipoGasto = 7;
            tipogasto7.Nombre = "Compras Limpieza";

            tipogasto8.IdTipoGasto = 8;
            tipogasto8.Nombre = "Extraordinario";
        }
    }
}
