using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RecycleCoin.Entities.Concrete
{
    public class AppUser:IdentityUser
    {
        public long TcNo { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Year { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public int Carbon { get; set; }
        public decimal ConvertedCarbon { get; set; }
    }
}
