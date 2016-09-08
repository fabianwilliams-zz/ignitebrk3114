using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace brk4113.Model
{
    public class User
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }

    public class CreatedBy
    {

        [JsonProperty("user")]
        public User User { get; set; }
    }

    public class Folder
    {

        [JsonProperty("childCount")]
        public int ChildCount { get; set; }
    }

    public class User2
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }

    public class LastModifiedBy
    {

        [JsonProperty("user")]
        public User2 User { get; set; }
    }

    public class ParentReference
    {

        [JsonProperty("driveId")]
        public string DriveId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }

    public class File
    {
    }

    public class UserFile
    {

        [JsonProperty("createdBy")]
        public CreatedBy CreatedBy { get; set; }

        [JsonProperty("createdDateTime")]
        public string CreatedDateTime { get; set; }

        [JsonProperty("cTag")]
        public string CTag { get; set; }

        [JsonProperty("eTag")]
        public string ETag { get; set; }

        [JsonProperty("folder")]
        public Folder Folder { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lastModifiedBy")]
        public LastModifiedBy LastModifiedBy { get; set; }

        [JsonProperty("lastModifiedDateTime")]
        public string LastModifiedDateTime { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parentReference")]
        public ParentReference ParentReference { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("webUrl")]
        public string WebUrl { get; set; }

        [JsonProperty("@microsoft.graph.downloadUrl")]
        public string MicrosoftGraphDownloadUrl { get; set; }

        [JsonProperty("file")]
        public File File { get; set; }
    }

    public class FileResponse
    {

        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        [JsonProperty("value")]
        public UserFile[] Value { get; set; }
    }
}
