namespace Muscle
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EntityData
    {
        public string Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        public bool Deleted { get; set; }
    }
}