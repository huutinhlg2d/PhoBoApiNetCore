using Microsoft.AspNetCore.Http;
using BussinessObject.PhoBo.Models;
using BussinessObject.PhoBo.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net.Mail;

namespace BussinessObject.PhoBo.DTO
{
    public class Register
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [ExistedEmailValidate]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match")]
        public string Repassword { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender? Gender { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public UserRole? Role { get; set; }

        [DataType(DataType.Upload)]
        [AllowedExtensions(Extensions = "png,jpg,jpeg,gif")]
        public IFormFile AvatarFile { get; set; }

        public string GetAvatarUrl()
        {
            var folderName = Path.Combine("Resources", "Images");
            var avatarUrl = Path.Combine(folderName, GetFileName());

            return avatarUrl;
        }

        public string GetFileName()
        {
            return AvatarFile != null ?
                new MailAddress(Email).User + Path.GetExtension(AvatarFile.FileName) :
                "default_avatar.png";
        }

        //public User GetUser()
        //{
        //    return new User()
        //    {
        //        Name = Name,
        //        Email = Email,
        //        Password = Password,
        //        DateOfBirth = DateOfBirth,
        //        Role = Role,
        //        AvatarUrl = $"img/avatar/{(AvatarFile != null ? new MailAddress(Email).User + Path.GetExtension(AvatarFile.FileName) : "img_avatar.png")}"
        //    };
        //}
    }
}
