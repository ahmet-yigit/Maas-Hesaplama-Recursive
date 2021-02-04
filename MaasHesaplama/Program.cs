using System;
using System.Collections;
using System.Collections.Generic;

public class Program
{
    int parcala = 1;
    double vergiler = 0;
    double kesintiler = 0;
    List<double> brutList = new List<double>();
    int sayac = 0;
    static void Main(string[] args)
    {
        Program p = new Program();
        Console.Write("Maaş Giriniz: ");
        double maas = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Brut Maas: " + p.BrutMaasHesapla(maas));
        Console.ReadLine();
    }

    public double NetMaasHesapla(double brutMaas)
    {
        vergiler = brutMaas * 0.2;
        kesintiler = brutMaas * 0.1;
        return brutMaas - (vergiler + kesintiler);
    }

    public double BrutMaasHesapla(double netMaas)
    {
        sayac++;
        parcala = parcala * 2;
        double parcalananMaas = netMaas / parcala;

        if (sayac == 1)
        {
            double tahminBrut = netMaas + parcalananMaas;
            brutList.Add(tahminBrut);
        }

        double metottaHesaplananNetMaas = NetMaasHesapla(brutList[sayac - 1]);

        if (netMaas < metottaHesaplananNetMaas)
        {
            parcala = parcala * 2;
            parcalananMaas = netMaas / parcala;
            double brutMaas1 = brutList[sayac - 1] - parcalananMaas;
            brutList.Add(brutMaas1);
            parcala = parcala / 2;
            double newMaas = netMaas;
            return BrutMaasHesapla(newMaas);
        }
        else if (netMaas > metottaHesaplananNetMaas)
        {
            parcala = parcala * 2;
            parcalananMaas = netMaas / parcala;
            double brutMaas1 = brutList[sayac - 1] + parcalananMaas;
            brutList.Add(brutMaas1);
            parcala = parcala / 2;
            double newMaas = netMaas;
            return BrutMaasHesapla(newMaas);
        }
        Console.WriteLine("Girilen Net Maaş: " + netMaas + "  TL");
        return brutList[sayac - 2];
    }
}

