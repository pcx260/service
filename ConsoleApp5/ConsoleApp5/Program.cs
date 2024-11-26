using System;
using System.Collections.Generic;

class SinifIciUygulama
{
    private Dictionary<string, string> ogrenciler = new Dictionary<string, string>();
    private List<Tuple<string, string>> sorular = new List<Tuple<string, string>>();
    private Dictionary<string, int> sonuclar = new Dictionary<string, int>();

    // Öğrenci Kaydı
    public void OgrenciKayit()
    {
        Console.Write("Öğrenci Adı: ");
        string ad = Console.ReadLine();
        Console.Write("Şifre Belirleyin: ");
        string sifre = Console.ReadLine();
        ogrenciler[ad] = sifre;
        Console.WriteLine($"{ad} başarıyla kaydedildi.");
    }

    // Öğrenci Girişi
    public string OgrenciGirisi()
    {
        Console.Write("Adınızı girin: ");
        string ad = Console.ReadLine();
        Console.Write("Şifrenizi girin: ");
        string sifre = Console.ReadLine();

        if (ogrenciler.ContainsKey(ad) && ogrenciler[ad] == sifre)
        {
            Console.WriteLine($"{ad} giriş başarılı.");
            return ad;
        }
        else
        {
            Console.WriteLine("Hatalı giriş.");
            return null;
        }
    }

    // Soru Ekleme
    public void SoruEkle()
    {
        Console.Write("Soru ekleyin: ");
        string soru = Console.ReadLine();
        Console.Write("Cevap ekleyin: ");
        string cevap = Console.ReadLine();
        sorular.Add(new Tuple<string, string>(soru, cevap));
        Console.WriteLine("Soru başarıyla eklendi.");
    }

    // Sınav Yapma
    public void SinavYap(string ogrenciAd)
    {
        if (ogrenciAd == null)
        {
            Console.WriteLine("Lütfen önce giriş yapın.");
            return;
        }

        Console.WriteLine($"{ogrenciAd} için sınav başlıyor.");
        int dogruSayisi = 0;
        foreach (var soru in sorular)
        {
            Console.WriteLine(soru.Item1);
            string ogrenciCevap = Console.ReadLine();
            if (ogrenciCevap.ToLower() == soru.Item2.ToLower())
            {
                dogruSayisi++;
            }
        }

        sonuclar[ogrenciAd] = dogruSayisi;
        Console.WriteLine($"Sınav tamamlandı! {dogruSayisi} doğru cevap verdiniz.");
    }

    // Geribildirim Verme
    public void GeribildirimVer(string ogrenciAd)
    {
        if (!sonuclar.ContainsKey(ogrenciAd))
        {
            Console.WriteLine("Henüz sınav yapılmadı.");
            return;
        }

        int dogruSayisi = sonuclar[ogrenciAd];
        Console.WriteLine($"{ogrenciAd} için geribildirim:");
        if (dogruSayisi == sorular.Count)
        {
            Console.WriteLine("Mükemmel, tüm soruları doğru cevapladınız!");
        }
        else if (dogruSayisi >= sorular.Count / 2)
        {
            Console.WriteLine("İyi iş çıkardınız, biraz daha çalışmanızı öneririm.");
        }
        else
        {
            Console.WriteLine("Daha fazla çalışmaya ihtiyacınız var.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        SinifIciUygulama uygulama = new SinifIciUygulama();
        string ogrenciAd = null;

        while (true)
        {
            Console.WriteLine("\n--- Sınıf İçi Uygulama ---");
            Console.WriteLine("1. Öğrenci Kaydı");
            Console.WriteLine("2. Öğrenci Girişi");
            Console.WriteLine("3. Soru Ekle");
            Console.WriteLine("4. Sınav Yap");
            Console.WriteLine("5. Geribildirim Ver");
            Console.WriteLine("6. Çıkış");

            Console.Write("Bir seçenek girin: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    uygulama.OgrenciKayit();
                    break;

                case "2":
                    ogrenciAd = uygulama.OgrenciGirisi();
                    break;

                case "3":
                    uygulama.SoruEkle();
                    break;

                case "4":
                    uygulama.SinavYap(ogrenciAd);
                    break;

                case "5":
                    uygulama.GeribildirimVer(ogrenciAd);
                    break;

                case "6":
                    Console.WriteLine("Çıkılıyor...");
                    return;

                default:
                    Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
                    break;
            }
        }
    }
}
