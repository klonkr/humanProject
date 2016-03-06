using System;

namespace ProjectHuman.DB.Domain
{
    public class PetType
    {
        public Guid Id { get; set; }
        public string Type { get; set; }

        public PetType()
        {
            Id = Guid.NewGuid();
        }
    }
}