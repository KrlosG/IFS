﻿namespace IFS.Web.Core.Upload {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    public class StoredMetadata {
        public DateTime Expiration { get; set; }
        public DateTime UploadedOn { get; set; }

        public bool IsReservation { get; set; }
        public AccessLog Access {
            get => this._access ?? (this._access = new AccessLog());
            set => this._access = value;
        }

        public string OriginalFileName { get; set; }

        public ContactInformation Sender { get; set; }

        public string Serialize() {
            return JsonConvert.SerializeObject(this, Formatting.Indented, SerializerSettings);
        }

        public static StoredMetadata Deserialize(string str) {
            return JsonConvert.DeserializeObject<StoredMetadata>(str, SerializerSettings);
        }

        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings();
        private AccessLog _access;
    }

    public class ContactInformation {
        [Display(Name = "Name")]
        [StringLength(256)]
        public string Name { get; set; }
        [Display(Name = "E-mail address")]
        [DataType(DataType.EmailAddress)]
        [StringLength(256)]
        public string EmailAddress { get; set; }
    }

    public class AccessLog {
        private List<FileAccessLogEntry> _logEntries;

        public List<FileAccessLogEntry> LogEntries {
            get => this._logEntries ?? (this._logEntries = new List<FileAccessLogEntry>());
            set => this._logEntries = value;
        }
    }

    public class FileAccessLogEntry {
        public DateTime Timestamp { get; set; }
        public string IpAddress { get; set; }
    }
}