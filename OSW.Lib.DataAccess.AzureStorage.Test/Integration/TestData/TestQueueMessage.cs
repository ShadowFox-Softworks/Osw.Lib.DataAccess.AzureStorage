namespace OSW.Lib.DataAccess.AzureStorage.Test.Integration.TestData
{
    using System.Runtime.Serialization;

    [DataContract]
    public sealed class TestQueueMessage
    {
        [DataMember(Name = "author")]
        public string Author { get; set; }
    }
}