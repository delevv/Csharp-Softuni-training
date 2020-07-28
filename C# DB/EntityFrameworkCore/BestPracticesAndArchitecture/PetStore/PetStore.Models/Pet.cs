using PetStore.Common;
using PetStore.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Models
{
    public class Pet
    {
        public Pet()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.PetNameMinLength)]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        [Range(GlobalConstants.PetMinAge, GlobalConstants.PetMaxAge)]
        public byte Age { get; set; }

        public bool IsSold { get; set; }

        [Range(GlobalConstants.PetMinPrice, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey(nameof(Breed))]
        public int BreedId { get; set; }

        public virtual Breed Breed { get; set; }

        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
