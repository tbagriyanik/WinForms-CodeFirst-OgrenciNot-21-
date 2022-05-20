using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace kitaptanVT
{
    public class vtModel : DbContext
    {
        public vtModel() : base("name=vtModel") { }

        public virtual DbSet<OgrenciBilgi> OgrenciBilgileri { get; set; }
        public virtual DbSet<Ders> Dersler { get; set; }
        public virtual DbSet<OgrenciNot> OgrenciNotlar { get; set; }
    }

    public class OgrenciBilgi
    {
        [Key]
        public int OgrencID { get; set; }
        public string Ad { get; set; }
        public string Bolum { get; set; }
        public string Sinif { get; set; }
        public DateTime DogumTarihi { get; set; }
    }
    public class Ders
    {
        [Key]
        public int DersID { get; set; }
        public string Ad { get; set; }
    }
    public class OgrenciNot
    {
        [Key]
        public int Id { get; set; }
        public int OgrencID { get; set; }
        public OgrenciBilgi ogrenciBilgi { get; set; }
        public int DersID { get; set; }
        public Ders ders { get; set; }
        public float Yazili1 { get; set; }
        public float Yazili2 { get; set; }
        public float Yazili3 { get; set; }
        public float Uygulama1 { get; set; }
        public float Uygulama2 { get; set; }
        public float Performans1 { get; set; }
        public float Performans2 { get; set; }
        public float Ortalama { get; set; }
    }
}