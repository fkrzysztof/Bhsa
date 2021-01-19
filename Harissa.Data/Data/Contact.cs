using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Harissa.Data.Data
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 4,ErrorMessage="Nazwa powinna zawierać od 4 do 20 znaków")]
        public string Name { get; set; }
    }
}
