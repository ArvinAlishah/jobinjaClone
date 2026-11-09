using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.Auth
{
    public class SignInRequestDto
    {
        
        [Required(ErrorMessage = "نام کاربری الزامی می باشد")]
        [MaxLength(10, ErrorMessage = "نام کاربری نمی تواند بیشتر از 10 کاراکتر باشد")]
        [MinLength(3, ErrorMessage = "نام کاربری نمی تواند کمتر از 3 کاراکتر باشد")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "کلمه عبور الزامی می باشد")]
        [MaxLength(20, ErrorMessage = "کلمه عبور نمی تواند بیشتر از 20 کاراکتر باشد")]
        [MinLength(8, ErrorMessage = "کلمه عبور نمی تواند کمتر از 8 کاراکتر باشد")]
        public string Password { get; set; } = null!;


        [Required(ErrorMessage = "ایمیل  الزامی می باشد")]
        [MaxLength(40, ErrorMessage = "ایمیل عبور نمی تواند بیشتر از 40 کاراکتر باشد")]
        [MinLength(8, ErrorMessage = "ایمیل عبور نمی تواند کمتر از 8 کاراکتر باشد")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "رول  الزامی می باشد")]
        public List<int> UserRoleId { get; set; } = null!;
    }

}
