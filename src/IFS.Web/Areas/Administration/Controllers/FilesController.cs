﻿// ******************************************************************************
//  © 2016 Sebastiaan Dammann - damsteen.nl
// 
//  File:           : FilesController.cs
//  Project         : IFS.Web
// ******************************************************************************

namespace IFS.Web.Areas.Administration.Controllers {
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Core;
    using Core.Upload;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Models;

    [Authorize(KnownPolicies.Administration)]
    [Area(nameof(Administration))]
    public sealed class FilesController : Controller {
        private readonly IUploadedFileRepository _uploadedFileRepository;

        public FilesController(IUploadedFileRepository uploadedFileRepository) {
            this._uploadedFileRepository = uploadedFileRepository;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index() {
            IList<UploadedFile> allFiles = await this._uploadedFileRepository.GetFiles();

            FilesOverviewModel model = new FilesOverviewModel {
                Files = allFiles
            };

            return this.View(model);
        }
    }
}