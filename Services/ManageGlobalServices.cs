using System.Net.Mail;
using System.Net;
using ManageLIbrary.Context;
using System.Text.RegularExpressions;
using ManageLIbrary.Models;
using ManageLIbrary.Dbcontexti;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ManageLIbrary.Services
{
    public  class ManageGlobalServices
    {
        private readonly GloabalContext context;
        private readonly GlobalDbContext db;
        public static string sendto = "aapkhazava22@gmail.com";
        string senderEmail = "globaltvmanagment@gmail.com";
        string senderPassword = "reoiuyqgeipepngo";
        public static int alertsaswrafo { get; set; } = 0;

        public static int errorcount { get; set; } = 0;
        public string body { get; set; } = "null";

        public ManageGlobalServices(GloabalContext con)
        {
            var options = new DbContextOptionsBuilder<GlobalDbContext>()
                .UseSqlServer(@"Server=DESKTOP-J7JC3FM\SQLEXPRESS;Database=Global;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;
            context = con;
            this.db = new GlobalDbContext(options);
        }

        public void start()
        {
            GetAlarms();

            var orasi = doparse(context.orasi,200);
            var Asi = doparse(context.asi, 100);
            var asati = doparse(context.asati, 110);
            var asoci = doparse(context.asoci, 120);
            var Asocdaati = doparse(context.Asocdati, 130);

            sendmessage(orasi, Asi, asati, asoci, Asocdaati,context.ati,context.oci,context.ocdaati,context.ormoci,context.ormocdaati,context.Samocdaati,context.IpSilk,context.muxianistvis,context.geocellreserv,context.desc80,context.desc90,context.mult230);

        }

        private void sendmessage(List<Chanell> orasi, List<Chanell> asi, List<Chanell> asati, List<Chanell> asoci, List<Chanell> asocdaati,List<string> ati , List<string> oci, List<string> ocdaati, List<string> ormoci, List<string> ormocdaati, List<string> samocdaati,List<string> ipsilk, List<string> muxianis, List<string> geocel,List<string>desc80,List<string> dsc90,List<string> mult230)
        {
            if(ipsilk.Count<=14&&muxianis.Count<=13&&geocel.Count<=10)
            {
                alertsaswrafo = 0;//arxebi chairto
            }
            int axali = (orasi.Count + asati.Count + asoci.Count + asi.Count + asocdaati.Count + ati.Count+oci.Count+ocdaati.Count+ormoci.Count+ormocdaati.Count+samocdaati.Count+geocel.Count+ipsilk.Count+muxianis.Count+desc80.Count+dsc90.Count) ;
            int shed = errorcount - axali;
            Console.WriteLine( muxianis.Count);
            if (ipsilk.Count>=13)
            {
                if(alertsaswrafo<=4)//tvini roar moxnas :) gavgzavnot mxolod otxjer
                {
                    var body = "<span style=\"color: red; font-size: 50px; font-weight: bold;\">მუხიანიდან წამოსული სტრიმები გაითიშა , ან რაღაც ხარვეზი გვაქვს , გადაამოწმე</span>";
                    SendMesaage(sendto, body, $"მუხიანიდან წამოსული არხები-{DateTime.Now.ToString()}");
                }
                //silksi cudi ambaviaa
                alertsaswrafo++;
            }
            else if(muxianis.Count>3)
            {
                if (alertsaswrafo <= 4)
                {
                    //silksi cudi ambaviaa
                    var body = "<span style=\"color: red; font-size: 50px; font-weight: bold;\">მუხიანში გაგზავნილი სტრიმები გაითიშა , ან რაღაც ხარვეზი გვაქვს , გადაამოწმე</span>";
                    SendMesaage(sendto, body, $"მუხიანში გაგზავნილი არხები-{DateTime.Now.ToString()}");
                }

                alertsaswrafo++;
            }
            else if(geocel.Count>=13)
            {
                if (alertsaswrafo <= 4)
                {
                    //geocellis sarezervo gaitishaa :(
                    //silksi cudi ambaviaa
                    var body = "<span style=\"color: red; font-size: 50px; font-weight: bold;\">ჯეოსელის სარეზერვო გაითიშა , გადაამოწმე</span>";
                SendMesaage(sendto, body, $"ჯეოსელის სარეზერვო-{DateTime.Now.ToString()}");

                }
                alertsaswrafo++;
            }
            else if (shed>=3||shed<=-3)
            {
                string buildetext = "";
                buildetext += "<div style=\"text-align: center;\"><b style=\"color:grey;\"><span style=\"font-size: 50px;\">ტრანსკოდერი(Transcoders)</span></b></div> <br/> <br/>";
                buildetext += "<b style=\"color:Green; font-size: 40px;\">EMR 200</b> <br/>";
                foreach (var item in orasi)
                {
                    buildetext += "<br/>";
                    buildetext += item;

                }
                buildetext += "<br/> <br/>";
                buildetext += "<b style=\"color:Green; font-size: 40px;\">EMR 100</b> <br/>";
                foreach (var item in asi)
                {
                    buildetext += "<br/>";
                    buildetext += item;

                }
                buildetext += "<br/> <br/>";
                buildetext += "<b style=\"color:Green; font-size: 40px;\">EMR 120</b> <br/>";
                foreach (var item in asoci)
                {
                    buildetext += item;
                    buildetext += "<br/>";
                }
                buildetext += "<br/> <br/>";
                buildetext += "<b style=\"color:Green; font-size: 40px;\">EMR 130</b> <br/>";
                foreach (var item in asocdaati)
                {
                    buildetext += "<br/>";
                    buildetext += item;
                }
                buildetext += "<br/> <br/>";
                buildetext += "<b style=\"color:Green; font-size: 40px;\">EMR 110</b> <br/>";
                foreach (var item in asati)
                {
                    buildetext += "<br/>";
                    buildetext += item;

                }
                buildetext += "<br/> <br/>";
                buildetext += "<b style=\"color:Green; font-size: 40px;\">EMR 230</b> <br/>";
                foreach (var item in mult230)
                {
                    buildetext += "<br/>";
                    buildetext += $"<span style=\"color: red; font-size: 20px;\">{item}</span><br/>";

                    buildetext += "<br/>";

                }
                //ipp
                buildetext += "<br/> <br/>";
                buildetext += "<div style=\"text-align: center;\"><b style=\"color:grey;\"><span style=\"font-size: 50px;\">სილქ Tv-ის არხები</span></b></div> <br/> <br/>";
                buildetext += "<b style=\"color:Green; font-size: 40px;\">EMR 210 - მუხიანიდან წამოსული არხები</b> <br/>";
                foreach (var item in ipsilk)
                {
                    buildetext += "<br/>";
                    buildetext += $"<span style=\"color: red; font-size: 20px;\">{item}</span><br/>";

                    buildetext += "<br/>";

                }
                buildetext += "<br/> <br/>";
                buildetext += "<b style=\"color:Green; font-size: 40px;\">EMR 220 - მუხიანში გაგზავნილი არხები</b> <br/>";
                foreach (var item in muxianis)
                {
                    buildetext += "<br/>";
                    buildetext += $"<span style=\"color: red; font-size: 20px;\">{item}</span><br/>";

                    buildetext += "<br/>";
                }
                buildetext += "<br/> <br/>";
                buildetext += "<b style=\"color:Green; font-size: 40px;\">EMR 240 - ჯეოსელით  დარეზერვებული არხები</b> <br/>";
                foreach (var item in geocel)
                {
                    buildetext += "<br/>";
                    buildetext += $"<span style=\"color: red;\">{item}</span><br/>";
                    buildetext += "<br/>";
                }
                buildetext += "<br/> <br/>";

                //reciever parts
                buildetext += "<br/> <br/>";
                buildetext += "<div style=\"text-align: center;\"><b style=\"color:grey;\"><span style=\"font-size: 50px;\">მიმღებები (Recievers)</span></b></div> <br/> <br/>";
                buildetext += "<b style=\"color:Green; font-size: 40px;\">EMR 10</b> <br/>";
                foreach (var item in ati )
                {
                    buildetext += "<br/>";
                    buildetext += $"<span style=\"color: red; font-size: 20px;\">{item}</span><br/>";

                    buildetext += "<br/>";
                }
                buildetext += "<br/> <br/>";
                buildetext += "<b style=\"color:Green; font-size: 40px;\">EMR 20</b> <br/>";
                foreach (var item in oci)
                {
                    buildetext += "<br/>";
                    buildetext += $"<span style=\"color: red; font-size: 20px;\">{item}</span><br/>";

                    buildetext += "<br/>";
                }
                buildetext += "<br/> <br/>";
                buildetext += "<b style=\"color:Green; font-size: 40px;\">EMR 30</b> <br/>";
                foreach (var item in ocdaati)
                {
                    buildetext += "<br/>";
                    buildetext += $"<span style=\"color: red; font-size: 20px;\">{item}</span><br/>";

                    buildetext += "<br/>";
                }
                buildetext += "<br/> <br/>";
                buildetext += "<b style=\"color:Green; font-size: 40px;\">EMR 40</b> <br/>";
                foreach (var item in ormoci)
                {
                    buildetext += "<br/>";
                    buildetext += $"<span style=\"color: red; font-size: 20px;\">{item}</span><br/>";

                    buildetext += "<br/>";
                }
                buildetext += "<br/> <br/>";
                buildetext += "<b style=\"color:Green; font-size: 40px;\">EMR 50</b> <br/>";
                foreach (var item in ormocdaati)
                {
                    buildetext += "<br/>";
                    buildetext += $"<span style=\"color: red; font-size: 20px;\">{item}</span><br/>";

                    buildetext += "<br/>";
                }
                buildetext += "<br/> <br/>";
                buildetext += "<b style=\"color:Green; font-size: 40px;\">EMR 70</b> <br/>";
                foreach (var item in samocdaati)
                {
                    buildetext += "<br/>";
                    buildetext += $"<span style=\"color: red; font-size: 20px;\">{item}</span><br/>";
                    buildetext += "<br/>";
                }
                buildetext += "<br/> <br/>";
                buildetext += "<div style=\"text-align: center;\"><b style=\"color:grey;\"><span style=\"font-size: 50px;\">დეკოდერი (Desclambers)</span></b></div> <br/> <br/>";
                buildetext += "<b style=\"color:Green; font-size: 40px;\">EMR 80</b> <br/>";
                foreach (var item in desc80)
                {
                    buildetext += "<br/>";
                    buildetext += $"<span style=\"color: red; font-size: 20px;\">{item}</span><br/>";

                    buildetext += "<br/>";
                }
                buildetext += "<br/> <br/>";
                buildetext += "<b style=\"color:Green; font-size: 40px;\">EMR 90</b> <br/>";
                foreach (var item in dsc90)
                {
                    buildetext += "<br/>";
                    buildetext += $"<span style=\"color: red; font-size: 20px;\">{item}</span><br/>";
                    buildetext += "<br/>";
                }
                buildetext += "<br/> <br/>";

                SendMesaage(sendto, buildetext,$"რეპორტი:{DateTime.Now.ToString()}");
                errorcount = axali;
                Console.WriteLine(  errorcount);
                shed = 0;
            }
            else
            {
                Console.WriteLine( "no detect any changes!");
                errorcount = axali;
                shed = 0;
            }
        }
        private List<Chanell> doparse(List<string> arxs, int ricx)
        {
            List<Chanell> errors = new List<Chanell>();
            Chanell chanell;
           
            foreach (var item in arxs)
            {
                string pattern = @"Card (\d+)";
                string port = @"Port (\d+)";
                string Videos = @"Video (\d+)";

                Match match = Regex.Match(item, pattern);
                Match portMatch = Regex.Match(item, port);
                Match video = Regex.Match(item, Videos);

                if (match.Success && (portMatch.Success||video.Success))
                {
                    chanell = new Chanell();
                    string cardNumber = match.Groups[1].Value;
                    string portNumber = portMatch.Groups[1].Value;
                    string vid = video.Groups[1].Value;

                    int cardnum;
                    int portpars;
                    int videopars;
                    Chanell chan;
                    if(int.TryParse(cardNumber,out cardnum))
                    {
                        chanell.Card = cardnum;
                        if (int.TryParse(portNumber,out portpars))
                        {
                            chanell.Port = portpars;
                        }
                        else if(int.TryParse(vid,out videopars))
                        {
                            chanell.Port = videopars;
                        }
                        chanell.EmrCode = ricx;

                       var name=db.chanells.Where(io=>io.Card==chanell.Card&&io.Port==chanell.Port&&io.EmrCode==chanell.EmrCode).FirstOrDefault();
                       
                        if(name!=null)
                        chanell.ChanellName = name.ChanellName;


                    }
                    chanell.ErrorMesage = item;


                    errors.Add(chanell);
                }
            }
            return errors;
        }

        public void print()
        {
            body = "";
            body += "EMR -- Transcoder 200---";
            foreach (var item in context.orasi)
            {
            
                body += item;
                body += "\n";
            }
            body += "\n";
            body += "120-----";
            foreach (var item in context.asoci)
            {
                body += "\n";
                body += item;
            }

            Console.WriteLine( body);
        }

        private void GetAlarms()
        {
            loadorasi();
            LoadAsi();
            LoasAsati();
            LoasAsoci();
            Loadasocdaati();
            context.ati = LoadReciever("10");
            context.oci = LoadReciever("20");
            context.ocdaati = LoadReciever("30");
            context.ormoci = LoadReciever("40");
            context.ormocdaati = LoadReciever("50");
            context.Samocdaati = LoadReciever("70");
            context.muxianistvis = LoadReciever("220");
            context.IpSilk = LoadReciever("210");
            context.geocellreserv = LoadReciever("240");
            context.desc80 = LoadReciever("80");
            context.desc90 = LoadReciever("90");
            context.mult230 = LoadReciever("230");
        }

        private void SendMesaage(string to,string body, string subject)
        {

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true,
            };
            var message = new MailMessage(new MailAddress(senderEmail), new MailAddress(to))
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
                Priority = MailPriority.High
            };
            smtpClient.Send(message);
        }

        private void loadorasi()
        {
            string  link = "http://192.168.20.200/goform/formEMR30?type=8&cmd=1&language=0&slotNo=255&alarmSlotNo=NaN&ran=0.36219193628209";
            using (HttpClient client = new HttpClient())
            {

                var res = client.GetAsync(link);

                if (res.Result.IsSuccessStatusCode)
                {
                    var re = res.Result.Content.ReadAsStringAsync();

                    string[] errors = re.Result.Split(new string[] { "High Density TRC Card (C132):", "<html>", "<html/>", "</html>" }, StringSplitOptions.RemoveEmptyEntries);
                    context.orasi.AddRange(errors);
                }
            }
        }

        private void LoadAsi()
        {
            string link = "http://192.168.20.100/goform/formEMR30?type=8&cmd=1&language=0&slotNo=255&alarmSlotNo=NaN&ran=0.36219193628209";
            using (HttpClient client = new HttpClient())
            {

                var res = client.GetAsync(link);

                if (res.Result.IsSuccessStatusCode)
                {
                    var re = res.Result.Content.ReadAsStringAsync();

                    string[] errors = re.Result.Split(new string[] { "High Density TRC Card (C132):", "<html>", "<html/>", "</html>" }, StringSplitOptions.RemoveEmptyEntries);
                    context.asi.AddRange(errors);
                }
            }
        }

        private void LoasAsati()
        {
            string link = "http://192.168.20.110/goform/formEMR30?type=8&cmd=1&language=0&slotNo=255&alarmSlotNo=NaN&ran=0.36219193628209";
            using (HttpClient client = new HttpClient())
            {

                var res = client.GetAsync(link);

                if (res.Result.IsSuccessStatusCode)
                {
                    var re = res.Result.Content.ReadAsStringAsync();

                    string[] errors = re.Result.Split(new string[] { "High Density TRC Card (C132):", "<html>", "<html/>", "</html>" }, StringSplitOptions.RemoveEmptyEntries);
                    context.asati.AddRange(errors);
                }
            }

        }
        private void LoasAsoci()
        {
            string link = "http://192.168.20.120/goform/formEMR30?type=8&cmd=1&language=0&slotNo=255&alarmSlotNo=NaN&ran=0.36219193628209";
            using (HttpClient client = new HttpClient())
            {

                var res = client.GetAsync(link);

                if (res.Result.IsSuccessStatusCode)
                {
                    var re = res.Result.Content.ReadAsStringAsync();

                    string[] errors = re.Result.Split(new string[] { "High Density TRC Card (C132):", "<html>", "<html/>", "</html>" }, StringSplitOptions.RemoveEmptyEntries);
                    context.asoci.AddRange(errors);
                }
            }
        }

        private void Loadasocdaati()
        {
            string link = "http://192.168.20.130/goform/formEMR30?type=8&cmd=1&language=0&slotNo=255&alarmSlotNo=NaN&ran=0.36219193628209";
            using (HttpClient client = new HttpClient())
            {

                var res = client.GetAsync(link);

                if (res.Result.IsSuccessStatusCode)
                {
                    var re = res.Result.Content.ReadAsStringAsync();

                    string[] errors = re.Result.Split(new string[] { "High Density TRC Card (C132):", "<html>", "<html/>", "</html>" }, StringSplitOptions.RemoveEmptyEntries);
                    context.asati.AddRange(errors);
                }
            }

        }

        public List<string> LoadReciever(string reciever)
        {
            List<string> str = new List<string>();
            string link = $"http://192.168.20.{reciever}/goform/formEMR30?type=8&cmd=1&language=0&slotNo=255&alarmSlotNo=NaN&ran=0.36219193628209";
            using (HttpClient client = new HttpClient())
            {
                var res = client.GetAsync(link);
                if (res.Result.IsSuccessStatusCode)
                {

                    var re = res.Result.Content.ReadAsStringAsync().Result;
                    //if (reciever == "40" || reciever == "50")
                    //{
                    //    var list = re.Split(new string[] { "<*1*>", "<html>", "</html>" }, StringSplitOptions.RemoveEmptyEntries);
                    //    str.AddRange(list);
                    //}
                    //else
                    //{
                    var list = re.Split(new string[] { "<*1*>", "<html>", "<html/>", "</html>" }, StringSplitOptions.RemoveEmptyEntries);
                    str.AddRange(list);
                    //}
                }
            }
            return str;
        }

        public void LoadDescramblers()
        {
            string link = $"http://192.168.20.{230}/goform/formEMR30?type=8&cmd=1&language=0&slotNo=255&alarmSlotNo=NaN&ran=0.36219193628209";
            using (HttpClient client = new HttpClient())
            {
                var res = client.GetAsync(link);
                if (res.Result.IsSuccessStatusCode)
                {
                    var re = res.Result.Content.ReadAsStringAsync().Result;

                    Console.WriteLine(re);
                }
            }
        }
    }
}
