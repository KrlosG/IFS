﻿// ******************************************************************************
//  © 2016 Sebastiaan Dammann - damsteen.nl
// 
//  File:           : DownloadController.cs
//  Project         : IFS.Web
// ******************************************************************************

namespace IFS.Web.Controllers {
    using System.Threading.Tasks;

    using Core;
    using Core.Upload;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using Models;

    public sealed class DownloadController : Controller {
        private readonly IUploadedFileRepository _uploadedFileRepository;
        private readonly ILogger<DownloadController> _logger;

        public DownloadController(IUploadedFileRepository uploadedFileRepository, ILogger<DownloadController> logger) {
            this._logger = logger;
            this._uploadedFileRepository = uploadedFileRepository;
        }

        public IActionResult Index() {
            return this.NotFound();
        }

        [Route("download/file/{id}", Name = "DownloadFile")]
        public async Task<IActionResult> DownloadFile(FileIdentifier id) {
            if (!this.ModelState.IsValid) {
                return this.BadRequest();
            }

            UploadedFile uploadedFile = await this._uploadedFileRepository.GetFile(id);
            if (uploadedFile == null) {
                this._logger.LogWarning(LogEvents.UploadNotFound, "Unable to find uploaded file for download '{0}'", id);
                return this.NotFound("We lost it!");
            }

            return this.File(uploadedFile.GetStream(), "application/octet-stream", uploadedFile.Metadata.OriginalFileName);
        }
    }
}