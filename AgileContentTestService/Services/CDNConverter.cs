using AgileContentTestDomain.Entities;
using AgileContentTestDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FileHelpers;
using System.Net;
using System.Configuration;
using FileHelpers.MasterDetail;
using System.Collections;

namespace AgileContentTestDomain.Services
{
    public class CDNConverter : ICDNConverter
    {
        public List<string> Messages { get; private set; } = new List<string>();

        public async Task<Agora> DownloadConverterAsync(string url, string path)
        {
            Agora result = null;

            try
            {
                Validate(url, path);
                if (Messages.Any())
                    return result;

                string filename = url.Split('/').LastOrDefault();
                string downloadpath = await DownloadFromUrl(url, filename);
                var engine = new FileHelperEngine<MinhaCDN>();
                var records = engine.ReadFile(downloadpath);
                result = new Agora(records.ToList());
                WriteFileOnPath(path, filename, result);
             
            }
            catch (Exception ex)
            {

                Messages.Add("A error occurred please try again late");
                return result;
            }
            return result;
        }

        private void Validate(string url, string path)
        {

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                Messages.Add("Url not Wwll formed.");

            if (!Directory.Exists(path))
                Messages.Add("Diretory don't exist.");

        }

        private async Task<string> DownloadFromUrl(string url , string filename)
        {
            
            string fullpath = string.Concat(ConfigurationManager.AppSettings["FilesPath"], filename);

            using (var client = new WebClient())
            {
                await client.DownloadFileTaskAsync(url, fullpath);
            }

            return fullpath;
        }


        private void WriteFileOnPath(string path, string filename, Agora file)
        {
            var eng = new FileHelperEngine<Campos>();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(file.Header.ToString());
            sb.AppendLine(string.Join(" ", eng.Options.FieldsNames));
            sb.AppendLine(eng.WriteString(file.Campos));
            var bytes = Encoding.ASCII.GetBytes(sb.ToString());

            filename = $"/MinhaCDN_{DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss")}_{filename}";
            File.WriteAllBytes(string.Concat(path,filename), bytes);
          }
        
        private void WriteRecords<T>(List<T> record, string path) where T : class
        {
            var engine = new FileHelperAsyncEngine<T>();
            using (engine.BeginWriteFile(path))            {
                foreach (var item in record)
                {
                    engine.WriteNext(item);
                }
            }
        }

    }
}
