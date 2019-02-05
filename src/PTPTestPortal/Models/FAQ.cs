using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace PTPTestPortal.Models
{
    public class FAQ
    {
        [Key]
        public int FAQID { get; set; }

        [Column(TypeName = "char(3)")]
        [DisplayName("WebSection ID")]
        public string webSectionID { get; set; }

        [DisplayName("Category")]
        public int CategoryID { get; set; }

        [StringLength(1000)]
        [DisplayName("Question")]
        public string question { get; set; }

        [DisplayName("Answer")]
        public string answer { get; set; }

        public int sOrder { get; set; }

        [Column(TypeName = "Datetime")]
        [DisplayName("Update Date")]
        public DateTime updatedOn { get; set; }

        [Column(TypeName = "char(3)")]
        [DisplayName("Featured Code")]
        public string featuredCode { get; set; }

        
        public FAQ()
        {
            this.webSectionID = "res";

        }
    }
}
