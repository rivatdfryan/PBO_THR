using System;

namespace manajemen_karyawan
{
    class Karyawan
    {
        private string nama;
        private string id;
        private double gajiPokok;

        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public double GajiPokok
        {
            get { return gajiPokok; }
            set { gajiPokok = value; }
        }

        public virtual double HitungGaji()
        {
            return gajiPokok;
        }
    }

    class KaryawanTetap : Karyawan
    {
        private const double BonusTetap = 500000;

        public override double HitungGaji()
        {
            return GajiPokok + BonusTetap;
        }
    }

    class KaryawanKontrak : Karyawan
    {
        private const double PotonganKontrak = 200000;

        public override double HitungGaji()
        {
            return GajiPokok - PotonganKontrak;
        }
    }

    class KaryawanMagang : Karyawan
    {
        public override double HitungGaji()
        {
            return GajiPokok;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Karyawan karyawan = null;
            string jenis;

            while (true)
            {
                Console.Write("Masukkan jenis karyawan (Tetap/Kontrak/Magang): ");
                jenis = Console.ReadLine().ToLower();

                if (jenis == "tetap")
                {
                    karyawan = new KaryawanTetap();
                    break;
                }
                else if (jenis == "kontrak")
                {
                    karyawan = new KaryawanKontrak();
                    break;
                }
                else if (jenis == "magang")
                {
                    karyawan = new KaryawanMagang();
                    break;
                }
                else
                {
                    Console.WriteLine("Jenis karyawan tidak valid. Coba lagi!\n");
                }
            }

            while (true)
            {
                Console.Write("Masukkan nama karyawan: ");
                string nama = Console.ReadLine();
                bool valid = true;

                foreach (char i in nama)
                {
                    if (!char.IsLetter(i) && i != ' ')
                    {
                        valid = false;
                        break;
                    }
                }
                if (nama.Trim().Length <= 0)
                {
                    Console.WriteLine("Nama tidak boleh kosong\n");
                }
                else if (valid)
                {
                    karyawan.Nama = nama;
                    break;
                }
                else
                {
                    Console.WriteLine("Nama hanya boleh mengandung huruf dan spasi\n");
                }
            }


            Console.Write("Masukkan ID karyawan: ");
            karyawan.ID = Console.ReadLine();

            while (true)
            {
                Console.Write("Masukkan gaji pokok: ");
                string inputGaji = Console.ReadLine();

                try
                {
                    double gaji = Convert.ToDouble(inputGaji);
                    if (gaji < 0)
                    {
                        Console.WriteLine("Gaji tidak boleh negatif. Coba lagi.");
                        continue;
                    }

                    karyawan.GajiPokok = gaji;
                    break;
                }
                catch
                {
                    Console.WriteLine("Input gaji tidak valid. Harus berupa angka.\n");
                }
            }

            Console.WriteLine("\n=== Sistem Manajemen Karyawan ===");
            Console.WriteLine($"Nama\t\t: {karyawan.Nama}");
            Console.WriteLine($"ID\t\t: {karyawan.ID}");
            Console.WriteLine($"Gaji Akhir\t: {karyawan.HitungGaji()}");
            Console.WriteLine($"=================================");
        }
    }
}

