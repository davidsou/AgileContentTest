using AgileContentTestDomain.Entities;
using AgileContentTestDomain.Interfaces;
using AgileContentTestService.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AgileContentService.Controller
{
    [RoutePrefix("api/agilecontenttest")]
    public class FileConverterController: BaseController
    {
        private readonly ICDNConverter cdnConverterService;
        public FileConverterController(ICDNConverter cDNConverterService)
        {
            this.cdnConverterService = cDNConverterService;
        }

        [HttpPost, Route("cdndownloadconverter")]
        public async Task<IHttpActionResult> CDNDownloadConverter(DowloadRequest dowloadRequest)
        {
             await cdnConverterService.DownloadConverterAsync(dowloadRequest.Url, dowloadRequest.Path);

            if (cdnConverterService.Messages.Any())
                return await Fail(cdnConverterService.Messages);

            return await Success(new List<string> { "File generated successfuly" });
        }

    }
}
