

using db.Models;

namespace ManageLIbrary.Context
{
    public class GloabalContext
    {

        public List<string> orasi;
        public List<string> asi;
        public List<string> asati;// transcoders
        public List<string> asoci;
        public List<string> Asocdati;

        public List<string> ati;
        public List<string> oci;
        public List<string> ocdaati;
        public List<string> ormoci;
        public List<string> ormocdaati;
        public List<string> Samocdaati;
        public List<string> geocellreserv;
        public List<string> IpSilk;
        public List<string> muxianistvis;

        public List<string> desc80 { get; set; }
        public List<string> desc90 { get; set; }


        public List<string> mult230 { get; set; }
        public GloabalContext()
        {
            orasi=new List<string>();
            asi=new List<string>();
            asoci=new List<string>();
            Asocdati = new List<string>();
            asati = new List<string>();
            ati=new List<string>();
            oci=new List<string>();
            ocdaati=new List<string>();
            ormoci=new List<string>();
            ormocdaati=new List<string>();
            Samocdaati = new List<string>();
            geocellreserv=new List<string>();
            IpSilk= new List<string>();
            muxianistvis=new List<string>();
            desc80 = new List<string>();
            desc90 = new List<string>();
            mult230 = new List<string>();
        }
    }
}
