using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public static class DatabaseExtension
{
    public static async Task<EnergiaContext> PopulateDatabase(this EnergiaContext context)
    {
        if (await context.Aerogeradores.CountAsync() == 0)
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            await context.AddRangeAsync(
                new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MIC1500TL-X",
                    Potencia = 1.5m,
                    TensaoEntradaMax = 500,
                    TensaoSaidaMin = 50,
                    TensaoSaidaMax = 500,
                    TipoFase = Data.Enumerators.TipoFase.MONOFASICO,
                    Valor = 1709
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MIC2000TL-X",
                    Potencia = 2,
                    TensaoEntradaMax = 500,
                    TensaoSaidaMin = 50,
                    TensaoSaidaMax = 500,
                    TipoFase = Data.Enumerators.TipoFase.MONOFASICO,
                    Valor = 1879
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MIC2500TL-X",
                    Potencia = 2.5m,
                    TensaoEntradaMax = 550,
                    TensaoSaidaMin = 65,
                    TensaoSaidaMax = 550,
                    TipoFase = Data.Enumerators.TipoFase.MONOFASICO,
                    Valor = 1919
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MIC3000TL-X",
                    Potencia = 3,
                    TensaoEntradaMax = 550,
                    TensaoSaidaMin = 65,
                    TensaoSaidaMax = 550,
                    TipoFase = Data.Enumerators.TipoFase.MONOFASICO,
                    Valor = 2219
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MIN3000TL-X",
                    Potencia = 3,
                    TensaoEntradaMax = 500,
                    TensaoSaidaMin = 60,
                    TensaoSaidaMax = 500,
                    TipoFase = Data.Enumerators.TipoFase.MONOFASICO,
                    Valor = 2590
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MIN5000TL-X",
                    Potencia = 5,
                    TensaoEntradaMax = 550,
                    TensaoSaidaMin = 60,
                    TensaoSaidaMax = 550,
                    TipoFase = Data.Enumerators.TipoFase.MONOFASICO,
                    Valor = 3549
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MIN6000TL-X",
                    Potencia = 6,
                    TensaoEntradaMax = 550,
                    TensaoSaidaMin = 60,
                    TensaoSaidaMax = 550,
                    TipoFase = Data.Enumerators.TipoFase.MONOFASICO,
                    Valor = 4209
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MIN8000TL-X",
                    Potencia = 8,
                    TensaoEntradaMax = 550,
                    TensaoSaidaMin = 60,
                    TensaoSaidaMax = 550,
                    TipoFase = Data.Enumerators.TipoFase.MONOFASICO,
                    Valor = 5409
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MIN10000TL-X",
                    Potencia = 10,
                    TensaoEntradaMax = 550,
                    TensaoSaidaMin = 60,
                    TensaoSaidaMax = 550,
                    TipoFase = Data.Enumerators.TipoFase.MONOFASICO,
                    Valor = 6799
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MID15KTL3-X",
                    Potencia = 15,
                    TensaoEntradaMax = 1000,
                    TensaoSaidaMin = 180,
                    TensaoSaidaMax = 1100,
                    TipoFase = Data.Enumerators.TipoFase.TRIFASICO,
                    Valor = 8299
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MID15KTL3-XL",
                    Potencia = 15,
                    TensaoEntradaMax = 850,
                    TensaoSaidaMin = 200,
                    TensaoSaidaMax = 1100,
                    TipoFase = Data.Enumerators.TipoFase.TRIFASICO,
                    Valor = 10029
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MID20KTL3-X",
                    Potencia = 20,
                    TensaoEntradaMax = 1000,
                    TensaoSaidaMin = 180,
                    TensaoSaidaMax = 1100,
                    TipoFase = Data.Enumerators.TipoFase.TRIFASICO,
                    Valor = 9209
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MID20KTL3-XL",
                    Potencia = 20,
                    TensaoEntradaMax = 850,
                    TensaoSaidaMin = 200,
                    TensaoSaidaMax = 1100,
                    TipoFase = Data.Enumerators.TipoFase.TRIFASICO,
                    Valor = 11199
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MID25KTL3-X",
                    Potencia = 25,
                    TensaoEntradaMax = 1000,
                    TensaoSaidaMin = 180,
                    TensaoSaidaMax = 1100,
                    TipoFase = Data.Enumerators.TipoFase.TRIFASICO,
                    Valor = 10949
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MAC25KTL3-XL",
                    Potencia = 25,
                    TensaoEntradaMax = 1000,
                    TensaoSaidaMin = 200,
                    TensaoSaidaMax = 1100,
                    TipoFase = Data.Enumerators.TipoFase.TRIFASICO,
                    Valor = 13609
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MID30KTL3-X",
                    Potencia = 30,
                    TensaoEntradaMax = 1000,
                    TensaoSaidaMin = 180,
                    TensaoSaidaMax = 1100,
                    TipoFase = Data.Enumerators.TipoFase.TRIFASICO,
                    Valor = 10809
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MAC30KTL3-XL",
                    Potencia = 30,
                    TensaoEntradaMax = 1000,
                    TensaoSaidaMin = 200,
                    TensaoSaidaMax = 1100,
                    TipoFase = Data.Enumerators.TipoFase.TRIFASICO,
                    Valor = 15919
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MID36KTL3-X",
                    Potencia = 36,
                    TensaoEntradaMax = 1000,
                    TensaoSaidaMin = 180,
                    TensaoSaidaMax = 1100,
                    TipoFase = Data.Enumerators.TipoFase.TRIFASICO,
                    Valor = 11779
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MAC36KTL3-XL",
                    Potencia = 36,
                    TensaoEntradaMax = 1000,
                    TensaoSaidaMin = 200,
                    TensaoSaidaMax = 1100,
                    TipoFase = Data.Enumerators.TipoFase.TRIFASICO,
                    Valor = 16279
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MAC50KTL3-X",
                    Potencia = 50,
                    TensaoEntradaMax = 1100,
                    TensaoSaidaMin = 200,
                    TensaoSaidaMax = 1000,
                    TipoFase = Data.Enumerators.TipoFase.TRIFASICO,
                    Valor = 13709
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MAX50KTL3-XL2",
                    Potencia = 50,
                    TensaoEntradaMax = 1100,
                    TensaoSaidaMin = 180,
                    TensaoSaidaMax = 850,
                    TipoFase = Data.Enumerators.TipoFase.TRIFASICO,
                    Valor = 16279
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MAC60KTL3-X",
                    Potencia = 60,
                    TensaoEntradaMax = 1100,
                    TensaoSaidaMin = 180,
                    TensaoSaidaMax = 1000,
                    TipoFase = Data.Enumerators.TipoFase.TRIFASICO,
                    Valor = 15419
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MAX60KTL3-XL2",
                    Potencia = 60,
                    TensaoEntradaMax = 1100,
                    TensaoSaidaMin = 180,
                    TensaoSaidaMax = 850,
                    TipoFase = Data.Enumerators.TipoFase.TRIFASICO,
                    Valor = 23339
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MAX75KTL3-LV",
                    Potencia = 75,
                    TensaoEntradaMax = 1100,
                    TensaoSaidaMin = 195,
                    TensaoSaidaMax = 1000,
                    TipoFase = Data.Enumerators.TipoFase.TRIFASICO,
                    Valor = 23599
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MAX75KTL3-XL2",
                    Potencia = 75,
                    TensaoEntradaMax = 1100,
                    TensaoSaidaMin = 180,
                    TensaoSaidaMax = 850,
                    TipoFase = Data.Enumerators.TipoFase.TRIFASICO,
                    Valor = 27519
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MAX100KTL3-XLV",
                    Potencia = 100,
                    TensaoEntradaMax = 1100,
                    TensaoSaidaMin = 180,
                    TensaoSaidaMax = 1000,
                    TipoFase = Data.Enumerators.TipoFase.TRIFASICO,
                    Valor = 35209
                }, new InversorSolar
                {
                    Marca = "GROWATT",
                    Modelo = "MAX125KTL3-X",
                    Potencia = 125,
                    TensaoEntradaMax = 1100,
                    TensaoSaidaMin = 180,
                    TensaoSaidaMax = 850,
                    TipoFase = Data.Enumerators.TipoFase.TRIFASICO,
                    Valor = 39159
                },
                new PainelSolar
                {
                    Marca = "RESUN",
                    Modelo = "RS6E-155M",
                    Potencia = 155m,
                    Valor = 299m
                }, new PainelSolar
                {
                    Marca = "ZTROON",
                    Modelo = "ZTP-160M",
                    Potencia = 160,
                    Valor = 309
                }, new PainelSolar
                {
                    Marca = "RESUN",
                    Modelo = "RS7E-210M",
                    Potencia = 210,
                    Valor = 379
                }, new PainelSolar
                {
                    Marca = "OSDA",
                    Modelo = "ODA280-30-P",
                    Potencia = 280,
                    Valor = 459
                }, new PainelSolar
                {
                    Marca = "OSDA",
                    Modelo = "ODA330-36-P",
                    Potencia = 330,
                    Valor = 569
                }, new PainelSolar
                {
                    Marca = "ZTROON",
                    Modelo = "ZTP-340P",
                    Potencia = 340,
                    Valor = 579
                }, new PainelSolar
                {
                    Marca = "SUNOVA",
                    Modelo = "SS-405-54MDH",
                    Potencia = 405,
                    Valor = 548.10m
                }, new PainelSolar
                {
                    Marca = "RESUN",
                    Modelo = "RS8V-M",
                    Potencia = 410,
                    Valor = 629
                }, new PainelSolar
                {
                    Marca = "CANADIAN",
                    Modelo = "CS6R 435T",
                    Potencia = 435,
                    Valor = 593.10m
                }, new PainelSolar
                {
                    Marca = "SUNOVA",
                    Modelo = "SS-460-60-MDH",
                    Potencia = 460,
                    Valor = 659
                }, new PainelSolar
                {
                    Marca = "JINKO",
                    Modelo = "JKM470N-60HL4-V",
                    Potencia = 470,
                    Valor = 658
                }, new PainelSolar
                {
                    Marca = "CANADIAN",
                    Modelo = "CS6W 550MS",
                    Potencia = 550,
                    Valor = 746.64m
                }, new PainelSolar
                {
                    Marca = "JA SOLAR",
                    Modelo = "JAM72D40-565/MB",
                    Potencia = 565,
                    Valor = 960
                }, new PainelSolar
                {
                    Marca = "JINKO",
                    Modelo = "JKM575N-72HL4-V",
                    Potencia = 575,
                    Valor = 895
                }, new PainelSolar
                {
                    Marca = "LUXEN SOLAR",
                    Modelo = "LNVH-595M",
                    Potencia = 595,
                    Valor = 799
                },
                //new Aerogeradores
                //{
                //    Marca = "",
                //    Modelo = "ELV-H2.7",
                //    Potencia = 0.5m,
                //    Potenciais = [
                //        new PotenciaPorValor(){ Valor = 0, Potencia = 0 },
                //        new PotenciaPorValor(){ Valor = 1, Potencia = 0 },
                //        new PotenciaPorValor(){ Valor = 2, Potencia = 0 },
                //        new PotenciaPorValor(){ Valor = 3, Potencia = 39.93m },
                //        new PotenciaPorValor(){ Valor = 4, Potencia = 98.14m },
                //        new PotenciaPorValor(){ Valor = 5, Potencia = 207.87m },
                //        new PotenciaPorValor(){ Valor = 6, Potencia = 348.96m },
                //        new PotenciaPorValor(){ Valor = 7, Potencia = 501.02m },
                //        new PotenciaPorValor(){ Valor = 8, Potencia = 651.70m },
                //        new PotenciaPorValor(){ Valor = 9, Potencia = 795.56m },
                //        new PotenciaPorValor(){ Valor = 10, Potencia = 928.41m },
                //        new PotenciaPorValor(){ Valor = 11, Potencia = 1006.92m },
                //        new PotenciaPorValor(){ Valor = 12, Potencia = 980.13m },
                //        new PotenciaPorValor(){ Valor = 13, Potencia = 931.15m },
                //        new PotenciaPorValor(){ Valor = 14, Potencia = 863.27m },
                //        new PotenciaPorValor(){ Valor = 15, Potencia = 795.28m },
                //        new PotenciaPorValor(){ Valor = 16, Potencia = 734.55m },
                //        new PotenciaPorValor(){ Valor = 17, Potencia = 663.61m },
                //        new PotenciaPorValor(){ Valor = 18, Potencia = 599.75m },
                //        new PotenciaPorValor(){ Valor = 19, Potencia = 549.45m },
                //        new PotenciaPorValor(){ Valor = 20, Potencia = 500m },
                //    ],
                //},
                new Aerogeradores
                {
                    Marca = "",
                    Modelo = "ELV-H3.1",
                    Potencia = 1m,
                    Potenciais = [
                        new PotenciaPorValor(){ Valor = 0, Potencia = 0 },
                        new PotenciaPorValor(){ Valor = 1, Potencia = 0 },
                        new PotenciaPorValor(){ Valor = 2, Potencia = 0 },
                        new PotenciaPorValor(){ Valor = 3, Potencia = 39.45m },
                        new PotenciaPorValor(){ Valor = 4, Potencia = 100.92m },
                        new PotenciaPorValor(){ Valor = 5, Potencia = 229.68m },
                        new PotenciaPorValor(){ Valor = 6, Potencia = 424.13m },
                        new PotenciaPorValor(){ Valor = 7, Potencia = 654.40m },
                        new PotenciaPorValor(){ Valor = 8, Potencia = 850.60m },
                        new PotenciaPorValor(){ Valor = 9, Potencia = 1044.67m },
                        new PotenciaPorValor(){ Valor = 10, Potencia = 1251.33m },
                        new PotenciaPorValor(){ Valor = 11, Potencia = 1474.12m },
                        new PotenciaPorValor(){ Valor = 12, Potencia = 1658.17m },
                        new PotenciaPorValor(){ Valor = 13, Potencia = 1863.13m },
                        new PotenciaPorValor(){ Valor = 14, Potencia = 2003.94m },
                        new PotenciaPorValor(){ Valor = 15, Potencia = 2001.65m },
                        new PotenciaPorValor(){ Valor = 16, Potencia = 1852.33m },
                        new PotenciaPorValor(){ Valor = 17, Potencia = 1664.37m },
                        new PotenciaPorValor(){ Valor = 18, Potencia = 1432.14m },
                        new PotenciaPorValor(){ Valor = 19, Potencia = 1194.17m },
                        new PotenciaPorValor(){ Valor = 20, Potencia = 1000m },
                    ],
                    CustoModeloInterno = 11884.07m
                }, new Aerogeradores
                {
                    Marca = "",
                    Modelo = "ELV-H3.8",
                    Potencia = 2m,
                    Potenciais = [
                        new PotenciaPorValor(){ Valor = 0, Potencia = 0 },
                        new PotenciaPorValor(){ Valor = 1, Potencia = 0 },
                        new PotenciaPorValor(){ Valor = 2, Potencia = 0 },
                        new PotenciaPorValor(){ Valor = 3, Potencia = 59.29m },
                        new PotenciaPorValor(){ Valor = 4, Potencia = 215.74m },
                        new PotenciaPorValor(){ Valor = 5, Potencia = 461.54m },
                        new PotenciaPorValor(){ Valor = 6, Potencia = 859.55m },
                        new PotenciaPorValor(){ Valor = 7, Potencia = 1260.12m },
                        new PotenciaPorValor(){ Valor = 8, Potencia = 1657.94m },
                        new PotenciaPorValor(){ Valor = 9, Potencia = 2012.87m },
                        new PotenciaPorValor(){ Valor = 10, Potencia = 2300.23m },
                        new PotenciaPorValor(){ Valor = 11, Potencia = 2638.74m },
                        new PotenciaPorValor(){ Valor = 12, Potencia = 2869.11m },
                        new PotenciaPorValor(){ Valor = 13, Potencia = 3094.47m },
                        new PotenciaPorValor(){ Valor = 14, Potencia = 3229.48m },
                        new PotenciaPorValor(){ Valor = 15, Potencia = 3197.05m },
                        new PotenciaPorValor(){ Valor = 16, Potencia = 3026.85m },
                        new PotenciaPorValor(){ Valor = 17, Potencia = 2782.58m },
                        new PotenciaPorValor(){ Valor = 18, Potencia = 2518.48m },
                        new PotenciaPorValor(){ Valor = 19, Potencia = 2234.50m },
                        new PotenciaPorValor(){ Valor = 20, Potencia = 2000m },
                    ],
                    CustoModeloInterno = 16175.59m
                }, new Aerogeradores
                {
                    Marca = "",
                    Modelo = "ELV-H4.6",
                    Potencia = 3m,
                    Potenciais = [
                        new PotenciaPorValor(){ Valor = 0, Potencia = 0 },
                        new PotenciaPorValor(){ Valor = 1, Potencia = 0 },
                        new PotenciaPorValor(){ Valor = 2, Potencia = 0 },
                        new PotenciaPorValor(){ Valor = 3, Potencia = 92.23m },
                        new PotenciaPorValor(){ Valor = 4, Potencia = 264.64m },
                        new PotenciaPorValor(){ Valor = 5, Potencia = 557.92m },
                        new PotenciaPorValor(){ Valor = 6, Potencia = 1007.84m },
                        new PotenciaPorValor(){ Valor = 7, Potencia = 1509.59m },
                        new PotenciaPorValor(){ Valor = 8, Potencia = 1999.73m },
                        new PotenciaPorValor(){ Valor = 9, Potencia = 2507.59m },
                        new PotenciaPorValor(){ Valor = 10, Potencia = 3000.72m },
                        new PotenciaPorValor(){ Valor = 11, Potencia = 3440.54m },
                        new PotenciaPorValor(){ Valor = 12, Potencia = 3775.10m },
                        new PotenciaPorValor(){ Valor = 13, Potencia = 4152.09m },
                        new PotenciaPorValor(){ Valor = 14, Potencia = 4429.04m },
                        new PotenciaPorValor(){ Valor = 15, Potencia = 4479.56m },
                        new PotenciaPorValor(){ Valor = 16, Potencia = 4270m },
                        new PotenciaPorValor(){ Valor = 17, Potencia = 3940.40m },
                        new PotenciaPorValor(){ Valor = 18, Potencia = 3665.06m },
                        new PotenciaPorValor(){ Valor = 19, Potencia = 3312.51m },
                        new PotenciaPorValor(){ Valor = 20, Potencia = 3000m },
                    ],
                    CustoModeloInterno = 25538.82m
                }, new Aerogeradores
                {
                    Marca = "",
                    Modelo = "ELV-H6.4",
                    Potencia = 5m,
                    Potenciais = [
                        new PotenciaPorValor(){ Valor = 0, Potencia = 0 },
                        new PotenciaPorValor(){ Valor = 1, Potencia = 0 },
                        new PotenciaPorValor(){ Valor = 2, Potencia = 0 },
                        new PotenciaPorValor(){ Valor = 3, Potencia = 196.57m },
                        new PotenciaPorValor(){ Valor = 4, Potencia = 417.51m },
                        new PotenciaPorValor(){ Valor = 5, Potencia = 798.70m },
                        new PotenciaPorValor(){ Valor = 6, Potencia = 1383.18m },
                        new PotenciaPorValor(){ Valor = 7, Potencia = 2130.27m },
                        new PotenciaPorValor(){ Valor = 8, Potencia = 3125.63m },
                        new PotenciaPorValor(){ Valor = 9, Potencia = 4129.09m },
                        new PotenciaPorValor(){ Valor = 10, Potencia = 5034.41m },
                        new PotenciaPorValor(){ Valor = 11, Potencia = 5884.71m },
                        new PotenciaPorValor(){ Valor = 12, Potencia = 6523m },
                        new PotenciaPorValor(){ Valor = 13, Potencia = 7111.9m },
                        new PotenciaPorValor(){ Valor = 14, Potencia = 7469.27m },
                        new PotenciaPorValor(){ Valor = 15, Potencia = 7480.26m },
                        new PotenciaPorValor(){ Valor = 16, Potencia = 7130.71m },
                        new PotenciaPorValor(){ Valor = 17, Potencia = 6614.72m },
                        new PotenciaPorValor(){ Valor = 18, Potencia = 6097.04m },
                        new PotenciaPorValor(){ Valor = 19, Potencia = 5492.78m },
                        new PotenciaPorValor(){ Valor = 20, Potencia = 5000m },
                    ],
                    CustoModeloInterno = 83426.83m
                }
                //, new Aerogeradores
                //{
                //    Marca = "",
                //    Modelo = "ELV-H8.0",
                //    Potencia = 10m,
                //    Potenciais = [
                //        new PotenciaPorValor(){ Valor = 0, Potencia = 0 },
                //        new PotenciaPorValor(){ Valor = 1, Potencia = 0 },
                //        new PotenciaPorValor(){ Valor = 2, Potencia = 0 },
                //        new PotenciaPorValor(){ Valor = 3, Potencia = 324.76m },
                //        new PotenciaPorValor(){ Valor = 4, Potencia = 800.31m },
                //        new PotenciaPorValor(){ Valor = 5, Potencia = 1677.12m },
                //        new PotenciaPorValor(){ Valor = 6, Potencia = 3192.95m },
                //        new PotenciaPorValor(){ Valor = 7, Potencia = 4471.37m },
                //        new PotenciaPorValor(){ Valor = 8, Potencia = 6210.12m },
                //        new PotenciaPorValor(){ Valor = 9, Potencia = 8295.35m },
                //        new PotenciaPorValor(){ Valor = 10, Potencia = 10125.07m },
                //        new PotenciaPorValor(){ Valor = 11, Potencia = 11670.04m },
                //        new PotenciaPorValor(){ Valor = 12, Potencia = 12988.31m },
                //        new PotenciaPorValor(){ Valor = 13, Potencia = 14255m },
                //        new PotenciaPorValor(){ Valor = 14, Potencia = 14952.90m },
                //        new PotenciaPorValor(){ Valor = 15, Potencia = 15025.64m },
                //        new PotenciaPorValor(){ Valor = 16, Potencia = 14358.58m },
                //        new PotenciaPorValor(){ Valor = 17, Potencia = 13310.51m },
                //        new PotenciaPorValor(){ Valor = 18, Potencia = 12104.62m },
                //        new PotenciaPorValor(){ Valor = 19, Potencia = 11016.05m },
                //        new PotenciaPorValor(){ Valor = 20, Potencia = 10000m },
                //    ]
                //}, new Aerogeradores
                //{
                //    Marca = "",
                //    Modelo = "ELV-H13.2",
                //    Potencia = 20m,
                //    Potenciais = [
                //        new PotenciaPorValor(){ Valor = 0, Potencia = 0 },
                //        new PotenciaPorValor(){ Valor = 1, Potencia = 0 },
                //        new PotenciaPorValor(){ Valor = 2, Potencia = 0 },
                //        new PotenciaPorValor(){ Valor = 3, Potencia = 1268.87m },
                //        new PotenciaPorValor(){ Valor = 4, Potencia = 3041.15m },
                //        new PotenciaPorValor(){ Valor = 5, Potencia = 6080.14m },
                //        new PotenciaPorValor(){ Valor = 6, Potencia = 9246.77m },
                //        new PotenciaPorValor(){ Valor = 7, Potencia = 13110.95m },
                //        new PotenciaPorValor(){ Valor = 8, Potencia = 16717.82m },
                //        new PotenciaPorValor(){ Valor = 9, Potencia = 19196.93m },
                //        new PotenciaPorValor(){ Valor = 10, Potencia = 20151.63m },
                //        new PotenciaPorValor(){ Valor = 11, Potencia = 20062.84m },
                //        new PotenciaPorValor(){ Valor = 12, Potencia = 20000m },
                //        new PotenciaPorValor(){ Valor = 13, Potencia = 20000m },
                //        new PotenciaPorValor(){ Valor = 14, Potencia = 20000m },
                //        new PotenciaPorValor(){ Valor = 15, Potencia = 20000m },
                //        new PotenciaPorValor(){ Valor = 16, Potencia = 20000m },
                //        new PotenciaPorValor(){ Valor = 17, Potencia = 20000m },
                //        new PotenciaPorValor(){ Valor = 18, Potencia = 20000m },
                //        new PotenciaPorValor(){ Valor = 19, Potencia = 20000m },
                //        new PotenciaPorValor(){ Valor = 20, Potencia = 20000m },
                //    ]
                //}, new Aerogeradores
                //{
                //    Marca = "",
                //    Modelo = "ELV-H13.2",
                //    Potencia = 30m,
                //    Potenciais = [
                //        new PotenciaPorValor(){ Valor = 0, Potencia = 0 },
                //        new PotenciaPorValor(){ Valor = 1, Potencia = 0 },
                //        new PotenciaPorValor(){ Valor = 2, Potencia = 0 },
                //        new PotenciaPorValor(){ Valor = 3, Potencia = 1801.18m },
                //        new PotenciaPorValor(){ Valor = 4, Potencia = 4383.22m },
                //        new PotenciaPorValor(){ Valor = 5, Potencia = 7661.34m },
                //        new PotenciaPorValor(){ Valor = 6, Potencia = 10707.23m },
                //        new PotenciaPorValor(){ Valor = 7, Potencia = 14137.04m },
                //        new PotenciaPorValor(){ Valor = 8, Potencia = 18082.18m },
                //        new PotenciaPorValor(){ Valor = 9, Potencia = 22632.10m },
                //        new PotenciaPorValor(){ Valor = 10, Potencia = 27893.08m },
                //        new PotenciaPorValor(){ Valor = 11, Potencia = 30000 },
                //        new PotenciaPorValor(){ Valor = 12, Potencia = 30000 },
                //        new PotenciaPorValor(){ Valor = 13, Potencia = 30000 },
                //        new PotenciaPorValor(){ Valor = 14, Potencia = 30000 },
                //        new PotenciaPorValor(){ Valor = 15, Potencia = 30000 },
                //        new PotenciaPorValor(){ Valor = 16, Potencia = 30000 },
                //        new PotenciaPorValor(){ Valor = 17, Potencia = 30000 },
                //        new PotenciaPorValor(){ Valor = 18, Potencia = 30000 },
                //        new PotenciaPorValor(){ Valor = 19, Potencia = 30000 },
                //        new PotenciaPorValor(){ Valor = 20, Potencia = 30000 },
                //    ]
                //}, new Aerogeradores
                //{
                //    Marca = "",
                //    Modelo = "ELV-H16.5",
                //    Potencia = 50m,
                //    Potenciais = [
                //        new PotenciaPorValor(){ Valor = 0, Potencia = 0 },
                //        new PotenciaPorValor(){ Valor = 1, Potencia = 0 },
                //        new PotenciaPorValor(){ Valor = 2, Potencia = 0 },
                //        new PotenciaPorValor(){ Valor = 3, Potencia = 1874.80m },
                //        new PotenciaPorValor(){ Valor = 4, Potencia = 5467.68m },
                //        new PotenciaPorValor(){ Valor = 5, Potencia = 10367.05m },
                //        new PotenciaPorValor(){ Valor = 6, Potencia = 16691 },
                //        new PotenciaPorValor(){ Valor = 7, Potencia = 24779.97m },
                //        new PotenciaPorValor(){ Valor = 8, Potencia = 31384.48m },
                //        new PotenciaPorValor(){ Valor = 9, Potencia = 37655.66m },
                //        new PotenciaPorValor(){ Valor = 10, Potencia = 41000.29m },
                //        new PotenciaPorValor(){ Valor = 11, Potencia = 50000 },
                //        new PotenciaPorValor(){ Valor = 12, Potencia = 50000 },
                //        new PotenciaPorValor(){ Valor = 13, Potencia = 50000 },
                //        new PotenciaPorValor(){ Valor = 14, Potencia = 50000 },
                //        new PotenciaPorValor(){ Valor = 15, Potencia = 50000 },
                //        new PotenciaPorValor(){ Valor = 16, Potencia = 50000 },
                //        new PotenciaPorValor(){ Valor = 17, Potencia = 50000 },
                //        new PotenciaPorValor(){ Valor = 18, Potencia = 50000 },
                //        new PotenciaPorValor(){ Valor = 19, Potencia = 50000 },
                //        new PotenciaPorValor(){ Valor = 20, Potencia = 50000 },
                //    ]
                //}, new Aerogeradores
                //{
                //    Marca = "",
                //    Modelo = "ELV-H20.8",
                //    Potencia = 100m,
                //    Potenciais = [
                //        new PotenciaPorValor(){ Valor = 0, Potencia = 0 },
                //        new PotenciaPorValor(){ Valor = 1, Potencia = 0 },
                //        new PotenciaPorValor(){ Valor = 2, Potencia = 0 },
                //        new PotenciaPorValor(){ Valor = 3, Potencia = 7445.97m },
                //        new PotenciaPorValor(){ Valor = 4, Potencia = 17576.89m },
                //        new PotenciaPorValor(){ Valor = 5, Potencia = 29112.59m },
                //        new PotenciaPorValor(){ Valor = 6, Potencia = 46192.92m },
                //        new PotenciaPorValor(){ Valor = 7, Potencia = 66114.43m },
                //        new PotenciaPorValor(){ Valor = 8, Potencia = 81741.61m },
                //        new PotenciaPorValor(){ Valor = 9, Potencia = 93040.27m },
                //        new PotenciaPorValor(){ Valor = 10, Potencia = 98227.56m },
                //        new PotenciaPorValor(){ Valor = 11, Potencia = 100000 },
                //        new PotenciaPorValor(){ Valor = 12, Potencia = 100000 },
                //        new PotenciaPorValor(){ Valor = 13, Potencia = 100000 },
                //        new PotenciaPorValor(){ Valor = 14, Potencia = 100000 },
                //        new PotenciaPorValor(){ Valor = 15, Potencia = 100000 },
                //        new PotenciaPorValor(){ Valor = 16, Potencia = 100000 },
                //        new PotenciaPorValor(){ Valor = 17, Potencia = 100000 },
                //        new PotenciaPorValor(){ Valor = 18, Potencia = 100000 },
                //        new PotenciaPorValor(){ Valor = 19, Potencia = 100000 },
                //        new PotenciaPorValor(){ Valor = 20, Potencia = 100000 },
                //    ]
                //}
            );
            await context.SaveChangesAsync();
        }
        return context;
    }
}