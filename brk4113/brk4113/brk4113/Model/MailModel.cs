using System;
using Newtonsoft.Json;

namespace brk4113.Model
{
    public class Body
    {

        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class EmailAddress
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }

    public class Sender
    {

        [JsonProperty("emailAddress")]
        public EmailAddress EmailAddress { get; set; }
    }

    public class EmailAddress2
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }

    public class From
    {

        [JsonProperty("emailAddress")]
        public EmailAddress2 EmailAddress { get; set; }
    }

    public class EmailAddress3
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }

    public class ToRecipient
    {

        [JsonProperty("emailAddress")]
        public EmailAddress3 EmailAddress { get; set; }
    }

    public class EmailAddress4
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }

    public class CcRecipient
    {

        [JsonProperty("emailAddress")]
        public EmailAddress4 EmailAddress { get; set; }
    }

    public class EmailAddress5
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }

    public class ReplyTo
    {

        [JsonProperty("emailAddress")]
        public EmailAddress5 EmailAddress { get; set; }
    }

    public class Flag
    {

        [JsonProperty("flagStatus")]
        public string FlagStatus { get; set; }
    }

    public class MailItem
    {

        [JsonProperty("@odata.etag")]
        public string OdataEtag { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdDateTime")]
        public string CreatedDateTime { get; set; }

        [JsonProperty("lastModifiedDateTime")]
        public string LastModifiedDateTime { get; set; }

        [JsonProperty("changeKey")]
        public string ChangeKey { get; set; }

        [JsonProperty("categories")]
        public object[] Categories { get; set; }

        [JsonProperty("receivedDateTime")]
        public string ReceivedDateTime { get; set; }

        [JsonProperty("sentDateTime")]
        public string SentDateTime { get; set; }

        [JsonProperty("hasAttachments")]
        public bool HasAttachments { get; set; }

        [JsonProperty("internetMessageId")]
        public string InternetMessageId { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }

        [JsonProperty("bodyPreview")]
        public string BodyPreview { get; set; }

        [JsonProperty("importance")]
        public string Importance { get; set; }

        [JsonProperty("parentFolderId")]
        public string ParentFolderId { get; set; }

        [JsonProperty("sender")]
        public Sender Sender { get; set; }

        [JsonProperty("from")]
        public From From { get; set; }

        [JsonProperty("toRecipients")]
        public ToRecipient[] ToRecipients { get; set; }

        [JsonProperty("ccRecipients")]
        public CcRecipient[] CcRecipients { get; set; }

        [JsonProperty("bccRecipients")]
        public object[] BccRecipients { get; set; }

        [JsonProperty("replyTo")]
        public ReplyTo[] ReplyTo { get; set; }

        [JsonProperty("conversationId")]
        public string ConversationId { get; set; }

        [JsonProperty("conversationIndex")]
        public string ConversationIndex { get; set; }

        [JsonProperty("isDeliveryReceiptRequested")]
        public object IsDeliveryReceiptRequested { get; set; }

        [JsonProperty("isReadReceiptRequested")]
        public bool IsReadReceiptRequested { get; set; }

        [JsonProperty("isRead")]
        public bool IsRead { get; set; }

        [JsonProperty("isDraft")]
        public bool IsDraft { get; set; }

        [JsonProperty("webLink")]
        public string WebLink { get; set; }

        [JsonProperty("inferenceClassification")]
        public string InferenceClassification { get; set; }

        [JsonProperty("unsubscribeData")]
        public object[] UnsubscribeData { get; set; }

        [JsonProperty("unsubscribeEnabled")]
        public bool UnsubscribeEnabled { get; set; }

        [JsonProperty("flag")]
        public Flag Flag { get; set; }
    }

    public class MailResponse
    {

        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        [JsonProperty("@odata.nextLink")]
        public string OdataNextLink { get; set; }

        [JsonProperty("value")]
        public MailItem[] Value { get; set; }
    }
}
