﻿// ******************************************************************************
//  © 2016 Sebastiaan Dammann - damsteen.nl
// 
//  File:           : LogEvents.cs
//  Project         : IFS.Web
// ******************************************************************************

namespace IFS.Web.Core {
    using Microsoft.Extensions.Logging;

    public static class LogEvents {
        public static readonly EventId NewUpload = new EventId(0001, nameof(NewUpload));
        public static readonly EventId UploadExpired = new EventId(0002, nameof(UploadExpired));

        public static readonly EventId UploadFailed = new EventId(1000, nameof(UploadFailed));
        public static readonly EventId UploadCancelled = new EventId(2000, nameof(UploadFailed));
        public static readonly EventId CleanupFailed = new EventId(1001, nameof(CleanupFailed));

        public static readonly EventId UploadNotFound = new EventId(2001, nameof(UploadNotFound));
        public static readonly EventId UploadIncomplete = new EventId(1002, nameof(UploadIncomplete));

        public static readonly EventId UploadCorrupted = new EventId(0xDEAD, nameof(UploadCorrupted));
    }
}
