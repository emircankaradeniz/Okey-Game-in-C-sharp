using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
//bismillahirrahmanirrahim
namespace Okey_Game
{
    internal class Program
    {
        static List<string> listTaslar = new List<string>(60);
        static Stack<string> stackTaslar = new Stack<string>();
        static Gamer gamer1 = new Gamer("emircan");
        static Gamer gamer2 = new Gamer("batuhan");
        static Gamer gamer3 = new Gamer("Hakan");
        static Gamer gamer4 = new Gamer("Muhammet");
        static string yalancıOkey;
        static string Okey;
        static string Gosterge;
        static void Main(string[] args)//sıkıntı algoritmada 
        {
            TaslarıOlustur();
            Console.WriteLine("Taşlar oluşturuldu");
            TaslarıKarıstırVeDiz();
            Console.WriteLine( "taşlar karıştırıldı ve okey taşı belirlendi");
            TaslarıDagıt(gamer1, 5); TaslarıDagıt(gamer2, 5); TaslarıDagıt(gamer3, 5); TaslarıDagıt(gamer4, 5);
            TaslarıDagıt(gamer1, 4); TaslarıDagıt(gamer2, 4); TaslarıDagıt(gamer3, 4); TaslarıDagıt(gamer4, 4);
            for (int i = 0; i < 17; i++)
            {
                TaslarıDagıt(gamer1, 1); TaslarıDagıt(gamer2, 1); TaslarıDagıt(gamer3, 1); TaslarıDagıt(gamer4, 1);
            }
            TaslarıDagıt(gamer1, 1); TaslarıDagıt(gamer2, 1);
            Console.WriteLine("bütün taşlar oyuncuların istakalarına dağıtıldı");
            Hesapla2(gamer1); Hesapla2(gamer2); Hesapla2(gamer3); Hesapla2(gamer4);
            Console.WriteLine("oyuncuların istekalarındaki taşlar per oluşturulup puanlandı");
            Console.WriteLine("---------------------------------------------------------");
            if (gamer1.point >= gamer2.point && gamer1.point >= gamer3.point && gamer1.point >= gamer4.point)
            {
                Console.WriteLine(gamer1.Name + " İsimli oyuncu en yüksek puan : " + gamer1.point);
            }
            else if (gamer2.point >= gamer1.point && gamer2.point >= gamer3.point && gamer2.point >= gamer4.point)
            {
                Console.WriteLine(gamer2.Name + " İsimli oyuncu en yüksek puan : " + gamer2.point);
            }
            else if (gamer3.point >= gamer2.point && gamer3.point >= gamer1.point && gamer3.point >= gamer4.point)
            {
                Console.WriteLine(gamer3.Name + " İsimli oyuncu en yüksek puan : " + gamer3.point);
            }
            else if (gamer4.point > gamer2.point && gamer4.point > gamer3.point && gamer4.point > gamer1.point)
            {
                Console.WriteLine(gamer4.Name + " İsimli oyuncu en yüksek puan : " + gamer4.point);
            }
            Console.ReadLine();
        }
        static string m = "m";
        static string k = "k";
        static string sa = "sa";
        static string s = "s";
        static void ForFonk(string k)
        {
            for (int i = 1; i <= 13; i++)
            {
                string l = k;
                l = i + "," + l;
                listTaslar.Add(l);
                listTaslar.Add(l);
            }
        }
        static void TaslarıOlustur()
        {
            ForFonk(m);ForFonk(k);ForFonk(sa);ForFonk(s);
            listTaslar.Add("1,yo");
            listTaslar.Add("1,yo");
        }
        static void TaslarıKarıstırVeDiz()
        {
            listTaslar = listTaslar.OrderBy(a => System.Guid.NewGuid()).ToList();
            foreach (string s in listTaslar)
            {
                stackTaslar.Push(s);
            }
            string l=stackTaslar.Peek();
            string[] vs=l.Split(',');
            int d=Convert.ToInt32(vs[0]);//burda okeyi belirliyoruz
            Gosterge = l;
            if(d==13)
            { Okey = 1 + "," + vs[1]; }
            else
            { Okey = (d + 1) + "," + vs[1];} 
            yalancıOkey = Okey;
            
        }
        static void TaslarıDagıt(Gamer s,int a)
        {
            for (int i = 0; i < a; i++)
            {
                s.Taslar.Add(stackTaslar.Pop());
            }
        }
        static void PerleriOlsustur(Gamer b, List<string> Perler)
        {
            void TaslarıSil3(List<string> list, string ak, string bk, string ck)
            {
                list.Remove(ak); list.Remove(bk); list.Remove(ck);
            }
            void TaslarıSil2(List<string> list, string ak, string bk)
            {
                list.Remove(ak); list.Remove(bk);
            }
            void TaslariSil1(List<string> list, string a)
            {
                list.Remove(a);
            }
            void ListeyeEkle(List<string> list, string a, string bo)
            {
                list.Add(a); list.Add(bo);
            }
            foreach (string s in b.Taslar.ToList())
            {
                string[] v1 = s.Split(','); int v11 = Convert.ToInt32(v1[0]);//bunları tekrar tekrar hesaplamasın diye direkt altlarına yazdım.
                b.Taslar.Remove(s);
                bool kullanildiMi = false;
                foreach (string l in b.Taslar.ToList())
                {
                    string[] v2 = l.Split(','); int v12 = Convert.ToInt32(v2[0]);
                    b.Taslar.Remove(l);
                    bool kullanildimi2 = false;
                    foreach (string d in b.Taslar.ToList())
                    {
                        string[] v3 = d.Split(',');
                        int v13 = Convert.ToInt32(v3[0]);
                        if (v1[1] == v2[1] && v1[1] == v3[1] && v2[1] == v3[1])// 123 567 şeklinde dizmek için
                        {
                            if ((v11 > v12 && v12 > v13) && (v11 - v12 == 1) && (v12 - v13 == 1))
                            {
                                Perler.Add("Düzen1" + "/" + d + "/" + l + "/" + s);
                                TaslarıSil3(b.Taslar, s, l, d); kullanildiMi = true; kullanildimi2 = true; break;
                            }
                            else if ((v11 > v13 && v13 > v12) && (v11 - v13 == 1) && (v13 - v12 == 1))
                            {
                                Perler.Add("Düzen1" + "/" + l + "/" + d + "/" + s);
                                TaslarıSil3(b.Taslar, s, l, d); kullanildiMi = true; kullanildimi2 = true; break;
                            }
                            else if ((v13 > v12 && v12 > v11) && (v13 - v12 == 1) && (v12 - v11 == 1))
                            {
                                Perler.Add("Düzen1" + "/" + s + "/" + l + "/" + d);
                                TaslarıSil3(b.Taslar, s, l, d); kullanildiMi = true; kullanildimi2 = true; break;
                            }
                            else if ((v13 > v11 && v11 > v12) && (v13 - v11 == 1) && (v11 - v12 == 1))
                            {
                                Perler.Add("Düzen1" + "/" + l + "/" + s + "/" + d);
                                TaslarıSil3(b.Taslar, s, l, d); kullanildiMi = true; kullanildimi2 = true; break;
                            }
                            else if ((v12 > v13 && v13 > v11) && (v12 - v13 == 1) && (v13 - v11 == 1))
                            {
                                Perler.Add("Düzen1" + "/" + s + "/" + d + "/" + l);
                                TaslarıSil3(b.Taslar, s, l, d); kullanildiMi = (true); kullanildimi2 = true; break;
                            }
                            else if ((v12 > v11 && v11 > v13) && (v12 - v11 == 1) && (v11 - v13 == 1))
                            {
                                Perler.Add("Düzen1" + "/" + d + "/" + s + "/" + l);
                                TaslarıSil3(b.Taslar, s, l, d); kullanildiMi = true; kullanildimi2 = true; break;
                            }
                        }
                    }
                    if (!kullanildimi2)
                    {
                        b.Taslar.Add(l);
                    }
                    else
                    {
                        break;
                    }

                }
                if (!kullanildiMi)
                {
                    b.Taslar.Add(s);
                }
                else
                {
                    break;
                }
            }
            foreach (string s in b.Taslar.ToList())//perleri renklerre göre dizdik
            {
                string[] v1 = s.Split(','); int v11 = Convert.ToInt32(v1[0]);
                b.Taslar.Remove(s);
                bool kullanildiMİ = false;
                foreach (string l in b.Taslar.ToList())
                {
                    string[] v2 = l.Split(','); int v12 = Convert.ToInt32(v2[0]);
                    b.Taslar.Remove(l);
                    bool kullanildimi2 = false;
                    foreach (string d in b.Taslar.ToList())
                    {
                        string[] v3 = d.Split(',');
                        int v13 = Convert.ToInt32(v3[0]);
                        if (v11 == v12 && v11 == v13 && v12 == v13)
                        {
                            if (v1[1] != v2[1] && v1[1] != v3[1] && v2[1] != v3[1])
                            {
                                Perler.Add("Düzen2" + "/" + d + "/" + s + "/" + l);
                                TaslarıSil3(b.Taslar, s, l, d); kullanildiMİ = true; kullanildimi2 = true; break;
                            }
                        }
                    }
                    if (!kullanildimi2)
                    {
                        b.Taslar.Add(l);
                    }
                    else
                    {
                        break;
                    }
                }
                if (!kullanildiMİ)
                {
                    b.Taslar.Add(s);
                }
                else
                {
                    break;
                }
            }
            foreach (string s in b.Taslar.ToList())//okeyi yerleştirme ->1*3
            {
                string[] k1 = s.Split(',');
                string bırıncıTasınRengi = k1[1];
                int bırıncıtas = Convert.ToInt32(k1[0]);
                b.Taslar.Remove(s);
                bool kulalnildiMi = false;
                foreach (string l in b.Taslar.ToList())
                {
                    string[] k2 = l.Split(',');
                    string ıkıncıTasınRengi = k2[1];
                    int ıkıncıtas = Convert.ToInt32(k2[0]);
                    b.Taslar.Remove(l);
                    bool kullanildimi2 = false;
                    foreach (string d in b.Taslar.ToList())
                    {
                        string[] k3 = d.Split(',');
                        string ucuncuTasınRengi = k3[1];
                        int ucuncutas = Convert.ToInt32(k3[0]);
                        if (bırıncıTasınRengi == "okey")
                        {
                            if ((ıkıncıtas + 2 == ucuncutas || ucuncutas + 2 == ıkıncıtas) && ıkıncıTasınRengi == ucuncuTasınRengi)
                            {
                                if (ıkıncıtas > ucuncutas)
                                {
                                    Perler.Add("Düzen1" + "/" + d + "/" + s + "/" + l);
                                    TaslarıSil3(b.Taslar, s, l, d); kulalnildiMi = true; kullanildimi2 = true; break;
                                }
                                else
                                {
                                    Perler.Add("Düzen1" + "/" + l + "/" + s + "/" + d);
                                    TaslarıSil3(b.Taslar, s, l, d); kulalnildiMi = true; kullanildimi2 = true; break;
                                }
                            }
                        }
                        else if (ıkıncıTasınRengi == "okey")
                        {
                            if ((bırıncıtas + 2 == ucuncutas || ucuncutas + 2 == bırıncıtas) && bırıncıTasınRengi == ucuncuTasınRengi)
                            {
                                if (bırıncıtas > ucuncutas)
                                {
                                    Perler.Add("Düzen1" + "/" + d + "/" + l + "/" + s);
                                    TaslarıSil3(b.Taslar, s, l, d); kulalnildiMi = true; kullanildimi2 = true; break;
                                }
                                else
                                {
                                    Perler.Add("Düzen1" + "/" + s + "/" + l + "/" + d);
                                    TaslarıSil3(b.Taslar, s, l, d); kulalnildiMi = true; kullanildimi2 = true; break;
                                }
                            }
                        }
                        else if (ucuncuTasınRengi == "okey")
                        {
                            if ((ıkıncıtas + 2 == bırıncıtas || bırıncıtas + 2 == ıkıncıtas) && ıkıncıTasınRengi == bırıncıTasınRengi)
                            {
                                if (bırıncıtas > ıkıncıtas)
                                {
                                    Perler.Add("Düzen1" + "/" + l + "/" + d + "/" + s);
                                    TaslarıSil3(b.Taslar, s, l, d); kulalnildiMi = true; kullanildimi2 = true; break;
                                }
                                else
                                {
                                    Perler.Add("Düzen1" + "/" + s + "/" + d + "/" + l);
                                    TaslarıSil3(b.Taslar, s, l, d); kulalnildiMi = true; kullanildimi2 = true; break;
                                }
                            }
                        }
                    }
                    if (!kullanildimi2)
                    {
                        b.Taslar.Add(l);
                    }
                    else { break; }
                }
                if (!kulalnildiMi)
                {
                    b.Taslar.Add(s);
                }
                else { break; }
            }
            foreach (string s in b.Taslar.ToList())//okeyi yerleştirme ->3*3
            {
                string[] k1 = s.Split(',');
                string bırıncıTasınRengi = k1[1];
                int bırıncıtas = Convert.ToInt32(k1[0]);
                b.Taslar.Remove(s);
                bool kullanidiMi = false;
                foreach (string l in b.Taslar.ToList())
                {
                    string[] k2 = l.Split(',');
                    string ıkıncıTasınRengi = k2[1];
                    int ıkıncıtas = Convert.ToInt32(k2[0]);
                    b.Taslar.Remove(l);
                    bool kullanildimi2 = false;
                    foreach (string d in b.Taslar.ToList())
                    {
                        string[] k3 = d.Split(',');
                        string ucuncuTasınRengi = k3[1];
                        int ucuncutas = Convert.ToInt32(k3[0]);
                        if (bırıncıTasınRengi == "okey" || ıkıncıTasınRengi == "okey" || ucuncuTasınRengi == "okey")
                        {
                            if (bırıncıtas == ıkıncıtas || bırıncıtas == ucuncutas || ıkıncıtas == ucuncutas)
                            {
                                if (bırıncıTasınRengi != ıkıncıTasınRengi && bırıncıTasınRengi != ucuncuTasınRengi && ıkıncıTasınRengi != ucuncuTasınRengi)
                                {
                                    Perler.Add("Düzen2" + "/" + l + "/" + s + "/" + d);
                                    TaslarıSil3(b.Taslar, s, l, d); kullanidiMi = true; kullanildimi2 = true; break;
                                }
                            }
                        }
                        else if ((bırıncıTasınRengi == "okey" && ıkıncıTasınRengi == "okey") || (bırıncıTasınRengi == "okey" && ucuncuTasınRengi == "okey") || (ucuncuTasınRengi == "okey" && ıkıncıTasınRengi == "okey"))
                        {//iki okey olması durumu
                            Perler.Add("Düzen2" + "/" + l + "/" + s + "/" + d);
                            TaslarıSil3(b.Taslar, s, l, d); kullanidiMi = true; kullanildimi2 = true; break;
                        }
                    }
                    if (!kullanildimi2)
                    {
                        b.Taslar.Add(l);
                    }
                    else
                    {
                        break;
                    }
                }
                if (!kullanidiMi)
                {
                    b.Taslar.Add(s);
                }
                else
                {
                    break;
                }
            }
            b.Taslar.Sort();
            foreach (string s in Perler.ToList())
            {
                string[] k1 = s.Split('/');
                string Düzen = k1[0];
                string[] k3 = k1[1].Split(',');
                int per1ıncıTas = Convert.ToInt32(k3[0]);
                string per1ıncıTasRenk = k3[1];
                string[] k4 = k1[2].Split(',');
                string per2ıncıTasRenk = k4[1];
                string[] k5 = k1[3].Split(',');
                int per3ıncıTas = Convert.ToInt32(k5[0]);
                string per3ıncıTasRenk = k5[1];
                Perler.Remove(s);
                bool kullanildiMi = false;
                foreach (string l in b.Taslar.ToList())
                {
                    string[] k = l.Split(','); string i = k[1]; int i2 = Convert.ToInt32(k[0]);//tekrar tekrar hesaplamasın diye yaptım
                    b.Taslar.Remove(l);
                    bool kullanildimi2 = false;
                    foreach (string d in b.Taslar.ToList())
                    {
                        string[] a = d.Split(',');
                        string r = a[1];
                        int r2 = Convert.ToInt32(a[0]);
                        if (Düzen == "Düzen1")//amaç 678 88->67 888 yapmak çünki daha fazla puan
                        {
                            if (i == "okey" || r == "okey")//okey varsa 678 *8
                            {
                                if (i == "okey")
                                {
                                    if (r2 == per3ıncıTas && r != per3ıncıTasRenk)
                                    {
                                        Perler.Add("Düzen2" + "/" + k1[3] + "/" + l + "/" + d);
                                        ListeyeEkle(b.Taslar, k1[1], k1[2]);
                                        TaslarıSil2(b.Taslar, l, d);
                                        TaslariSil1(Perler, s); kullanildiMi = true; kullanildimi2 = true; break;
                                    }

                                }
                                else if (r == "okey")
                                {
                                    if (i2 == per3ıncıTas && i != per3ıncıTasRenk)
                                    {
                                        Perler.Add("Düzen2" + "/" + k1[3] + "/" + l + "/" + d);
                                        ListeyeEkle(b.Taslar, k1[1], k1[2]);
                                        TaslarıSil2(b.Taslar, l, d);
                                        TaslariSil1(Perler, s); kullanildiMi = true; kullanildimi2 = true; break;
                                    }
                                }
                            }
                            else
                            {
                                if (i2 == r2 && per3ıncıTas == i2)
                                {
                                    if (per3ıncıTasRenk != r && per3ıncıTasRenk != i && i != r)
                                    {
                                        Perler.Add("Düzen2" + "/" + k1[3] + "/" + l + "/" + d);
                                        ListeyeEkle(b.Taslar, k1[1], k1[2]);
                                        TaslarıSil2(b.Taslar, l, d);
                                        TaslariSil1(Perler, s); kullanildiMi = true; kullanildimi2 = true; break;
                                    }
                                }
                            }

                        }
                        else if (Düzen == "Düzen2")//amaç 7s7m7si 8m9m -> 7m8m9m 7s7si 
                        {
                            if (i == r && (i2 == r2 + 1 || r2 == i2 + 1))
                            {
                                if (i2 == r2 + 1)
                                {
                                    if (per1ıncıTasRenk == i && (per1ıncıTas + 1 == r2))
                                    {
                                        Perler.Add("Düzen1" + "/" + k1[1] + "/" + d + "/" + l);
                                        TaslarıSil2(b.Taslar, l, d);
                                        ListeyeEkle(b.Taslar, k1[3], k1[2]);
                                        TaslariSil1(Perler, s); kullanildiMi = true; kullanildimi2 = true; break;
                                    }
                                    else if (per2ıncıTasRenk == i && (per1ıncıTas + 1 == r2))
                                    {
                                        Perler.Add("Düzen1" + "/" + k1[2] + "/" + d + "/" + l);
                                        TaslarıSil2(b.Taslar, l, d);
                                        ListeyeEkle(b.Taslar, k1[1], k1[3]);
                                        TaslariSil1(Perler, s); kullanildiMi = true; kullanildimi2 = true; break;
                                    }
                                    else if (per3ıncıTasRenk == i && (per1ıncıTas + 1 == r2))
                                    {
                                        Perler.Add("Düzen1" + "/" + k1[3] + "/" + d + "/" + l);
                                        TaslarıSil2(b.Taslar, l, d);
                                        ListeyeEkle(b.Taslar, k1[1], k1[2]);
                                        TaslariSil1(Perler, s); kullanildiMi = true; kullanildimi2 = true; break;
                                    }
                                }
                                else if (r2 == i2 + 1)
                                {
                                    if (per1ıncıTasRenk == i && (per1ıncıTas + 1 == i2))
                                    {
                                        Perler.Add("Düzen1" + "/" + k1[1] + "/" + l + "/" + d);
                                        TaslarıSil2(b.Taslar, l, d);
                                        ListeyeEkle(b.Taslar, k1[3], k1[2]);
                                        TaslariSil1(Perler, s); kullanildiMi = true; kullanildimi2 = true; break;
                                    }
                                    else if (per2ıncıTasRenk == i && (per1ıncıTas + 1 == i2))
                                    {
                                        Perler.Add("Düzen1" + "/" + k1[2] + "/" + l + "/" + d);
                                        TaslarıSil2(b.Taslar, l, d);
                                        ListeyeEkle(b.Taslar, k1[1], k1[3]);
                                        TaslariSil1(Perler, s); kullanildiMi = true; kullanildimi2 = true; break;
                                    }
                                    else if (per3ıncıTasRenk == i && (per1ıncıTas + 1 == i2))
                                    {
                                        Perler.Add("Düzen1" + "/" + k1[3] + "/" + l + "/" + d);
                                        TaslarıSil2(b.Taslar, l, d);
                                        ListeyeEkle(b.Taslar, k1[1], k1[2]);
                                        TaslariSil1(Perler, s); kullanildiMi = true; kullanildimi2 = true; break;
                                    }
                                }
                            }
                        }
                    }
                    if (!kullanildimi2)
                    {
                        b.Taslar.Add(l);
                    }
                    else
                    {
                        break;
                    }

                }
                if (!kullanildiMi)
                {
                    Perler.Add(s);
                }
                else
                {
                    break;
                }

            }
            foreach (string s in Perler.ToList())
            {
                string[] k1 = s.Split('/');
                int k1Kac = k1.Length;
                string Düzen = k1[0];
                string[] k2 = k1[1].Split(',');
                int per1ıncıTas = Convert.ToInt32( k2[0]);
                string per1ıncıTasRenk = k2[1];
                string[] k3 = k1[2].Split(',');
                string per2ıncıTasRenk = k3[1];
                string[] k4 = k1[3].Split(',');
                int per3ıncıTas = Convert.ToInt32(k4[0]);
                string per3ıncıTasRenk = k4[1];
                Perler.Remove(s);
                bool kullanildiMi = false;
                foreach (string l in b.Taslar.ToList())//Hata ayıklamada burda kaldın
                {
                    string[] h = l.Split(',');
                    int tasınDegeriInt = Convert.ToInt32(h[0]);
                    string tasınRengi = h[1];
                    if (Düzen == "Düzen1")//amaç 678 9 -> 6789 or 5 678 ->5678
                    {
                        if (per3ıncıTasRenk == tasınRengi)
                        {
                            if (k1Kac == 4)//amaç 4 taşlı per olabilir bu 3 taşlılar üzerinde işlem yapmaya yarıyor
                            {
                                if (tasınDegeriInt + 1 == per1ıncıTas)
                                {
                                    Perler.Add("Düzen1" + "/" + l + "/" + k1[1] + "/" + k1[2] + "/" + k1[3]);
                                    TaslariSil1(Perler, s);
                                    TaslariSil1(b.Taslar, l); kullanildiMi = true; break;

                                }
                                else if (tasınDegeriInt - 1 == per3ıncıTas)
                                {
                                    Perler.Add("Düzen1" + "/" + k1[1] + "/" + k1[2] + "/" + k1[3] + "/" + l);
                                    TaslariSil1(Perler, s);
                                    TaslariSil1(b.Taslar, l); kullanildiMi = true; break;
                                }
                            }
                            else if (k1Kac == 5)//buda 4 taşlılar üzerindde işlem yapmaya yarar
                            {
                                string[] k5 = k1[4].Split(',');
                                int per4ıncıTas = Convert.ToInt32(k5[0]);
                                if (tasınDegeriInt + 1 == per1ıncıTas)
                                {
                                    Perler.Add("Düzen1" + "/" + l + "/" + k1[1] + "/" + k1[2] + "/" + k1[3] + "/" + k1[4]);
                                    TaslariSil1(Perler, s);
                                    TaslariSil1(b.Taslar, l); kullanildiMi = true; break;
                                }
                                else if (tasınDegeriInt - 1 == per4ıncıTas)
                                {
                                    Perler.Add("Düzen1" + "/" + k1[1] + "/" + k1[2] + "/" + k1[3] + "/" + k1[4] + "/" + l);
                                    TaslariSil1(Perler, s);
                                    TaslariSil1(b.Taslar, l); kullanildiMi = true; break;
                                }
                            }
                        }
                    }
                    else if (Düzen == "Düzen2")//888 8 --> 8888
                    {
                        if ((per1ıncıTasRenk != tasınRengi && per2ıncıTasRenk != tasınRengi && per3ıncıTasRenk != tasınRengi) && tasınDegeriInt == per1ıncıTas)
                        {
                            Perler.Add("Düzen2" + "/" + l + "/" + k1[1] + "/" + k1[2] + "/" + k1[3]);
                            TaslariSil1(Perler, s);TaslariSil1(b.Taslar, l);
                            kullanildiMi = true; break;
                        }
                    }
                }
                if (!kullanildiMi)
                {
                    Perler.Add(s);
                }
                else
                {
                    break;
                }

            }
        }
        static void Hesapla2(Gamer b)
        {
            List<string> Perler = new List<string>();
            
            foreach(string s in b.Taslar.ToList())
            {
                if (s==Okey)
                {
                    string[] cd =s.Split(',');
                    b.Taslar.Add(cd[0] +",okey");b.Taslar.Remove(s);
                }
                else if(s=="1,yo")
                {
                    string[] lk=  Okey.Split(',');
                    int sayi = Convert.ToInt32(lk[0]);
                    string slm;
                    if(sayi==13)
                    {
                        slm = 1 + "," + lk[1];
                    }
                    else
                    {
                        slm = (sayi + 1) + "," + lk[1];
                    }
                    b.Taslar.Add(slm);
                    b.Taslar.Remove(s);
                }
            }
            for (int i = 0; i < 9; i++)
            {
                PerleriOlsustur(b, Perler);
            }

            foreach (string s in  Perler.ToList())
            {
                string[] k1 = s.Split('/');
                string[] k2 = k1[1].Split(',');
                int BırıncıTas = Convert.ToInt32(k2[0]);
                string[] k3 = k1[2].Split(',');
                int IkıncıTas = Convert.ToInt32(k3[0]);
                string[] k4 = k1[3].Split(',');
                int UcuncuTas = Convert.ToInt32(k4[0]);
                int top = 0;
                if (k1.Length==5)
                {
                    string[] k5 = k1[4].Split(',');
                    int DorduncuTas = Convert.ToInt32(k5[0]);
                    top=top+DorduncuTas;
                }
                top = top + BırıncıTas + IkıncıTas + UcuncuTas;
                b.point=b.point+top;
            }
            foreach (string s in Perler.ToList())
            {
                Console.WriteLine(s);
            }
            foreach (string s in b.Taslar.ToList())
            {
                Console.WriteLine(s );
            }
            Console.WriteLine(b.Name+" adlı oyuncunun ıstakasında "+b.Taslar.Count+" tane tas kalmıştır ve puanı : "+b.point);
        }        
    }
    class Gamer
    {
        public string Name { get; set; }
        public List<string> Taslar=new List<string>();
        public int point;
        public Gamer(string name)
        {
            this.Name = name;
        }
    }
}
