using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Apwd.GestorLine.Domain.Entities.v1.System;

public class BaseEntity
{
    public BaseEntity()
    {
        if (CreatedAt == DateTime.MinValue)
            CreatedAt = DateTime.Now;

        if (ChangedAt == DateTime.MinValue)
            ChangedAt = this.CreatedAt;
    }

    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public required string Id { get; set; }

    [BsonRepresentation(BsonType.String)]
    public required string CompanyCode { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ChangedAt { get; set; }
}
