using MongoDB.Bson;
using Reference.API.Common.Interface;
using System;

namespace Reference.API.Common
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
