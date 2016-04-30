using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Areas.Admin.Models.DTO
{
    public class CategoryVM : BaseVM
    {
        [Required(ErrorMessage ="Lütfen kategori ismi giriniz")]
        [Display(Name="Ad")]
        public string Name { get; set; }

        [Display(Name="Açıklama")]
        public string Description { get; set; }
    }
}