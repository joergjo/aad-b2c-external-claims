using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaimsProvider.Data
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required]
        public string UserIdentifier { get; set; }

        [Required, MaxLength(36)]
        public string CustomerNumber { get; set; }

        [Required, Column(TypeName = "smallint")]
        public LoyaltyStatus Status { get; set; }
    }

    public enum LoyaltyStatus
    {
        None,
        Bronze,
        Silver,
        Gold
    }
}
