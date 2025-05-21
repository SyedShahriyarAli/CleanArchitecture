using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public required string Contact { get; set; }
        public Gender Gender { get; set; }
    }
}